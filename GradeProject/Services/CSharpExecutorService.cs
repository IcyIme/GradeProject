using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace GradeProject.Services
{
    public interface ICSharpExecutorService
    {
        Task<string> ExecuteCSharpCodeAsync(string code, List<string> inputs, int timeoutMilliseconds = 5000);
    }

    public class CSharpExecutorService : ICSharpExecutorService
    {
        public async Task<string> ExecuteCSharpCodeAsync(string code, List<string> inputs, int timeoutMilliseconds = 5000)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return "No code provided.";
            }

            for (int i = 0; i < inputs.Count; i++)
            {
                code = ReplaceFirst(code, "Console.ReadLine()", $"\"{inputs[i]}\"");
            }

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            CSharpCompilationOptions compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

            MetadataReference[] references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .ToArray();

            CSharpCompilation compilation = CSharpCompilation.Create("DynamicCode")
                                                             .WithOptions(compilationOptions)
                                                             .AddReferences(references)
                                                             .AddSyntaxTrees(syntaxTree);

            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    var errors = result.Diagnostics.Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error)
                                                   .Select(diagnostic => diagnostic.GetMessage());
                    return $"Compilation failed: {string.Join(", ", errors)}";
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = Assembly.Load(ms.ToArray());

                    Type type = assembly.GetType("Program");
                    MethodInfo mainMethod = type.GetMethod("Main");

                    if (mainMethod == null)
                    {
                        return "No Main method found in the code.";
                    }

                    var cts = new CancellationTokenSource();
                    cts.CancelAfter(timeoutMilliseconds);

                    string output;
                    try
                    {
                        output = await CaptureConsoleOutputWithTimeoutAsync(() =>
                        {
                            mainMethod.Invoke(null, null);
                        }, cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        // Notify the Blazor page about the timeout
                        output = "Execution timed out.";
                    }

                    return output;
                }
            }
        }

        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        private async Task<string> CaptureConsoleOutputWithTimeoutAsync(Action action, CancellationToken cancellationToken)
        {
            using (var writer = new StringWriter())
            {
                TextWriter originalOut = Console.Out;
                Console.SetOut(writer);

                var task = Task.Run(action, cancellationToken);
                await Task.WhenAny(task, Task.Delay(Timeout.Infinite, cancellationToken));

                Console.SetOut(originalOut);
                if (task.IsCompleted)
                {
                    return writer.ToString();
                }
                else
                {
                    throw new OperationCanceledException();
                }
            }
        }
    }
}
