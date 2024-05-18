using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace GradeProject.Services
{
    public interface ICSharpExecutorService
    {
        string ExecuteCSharpCode(string code, List<string> inputs);
    }

    public class CSharpExecutorService : ICSharpExecutorService
    {
        public string ExecuteCSharpCode(string code, List<string> inputs)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return "No code provided.";
            }

            // Replace each Console.ReadLine() with the corresponding input value
            for (int i = 0; i < inputs.Count; i++)
            {
                code = ReplaceFirst(code, "Console.ReadLine()", $"\"{inputs[i]}\"");
            }

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

            // Define compilation options
            CSharpCompilationOptions compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

            // Add metadata references for all required assemblies
            MetadataReference[] references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .ToArray();

            // Compile the code
            CSharpCompilation compilation = CSharpCompilation.Create("DynamicCode")
                                                             .WithOptions(compilationOptions)
                                                             .AddReferences(references)
                                                             .AddSyntaxTrees(syntaxTree);

            // Generate the assembly
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

                    // Invoke the method
                    Type type = assembly.GetType("Program");
                    MethodInfo mainMethod = type.GetMethod("Main");
                    string output = CaptureConsoleOutput(() =>
                    {
                        mainMethod.Invoke(null, null);
                    });

                    return output;
                }
            }
        }

        // Helper method to replace the first occurrence of a substring
        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        // Helper method to capture console output
        private string CaptureConsoleOutput(Action action)
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                action.Invoke();
                return writer.ToString();
            }
        }
    }
}
