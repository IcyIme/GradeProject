using System.Threading.Tasks;
using GradeProject.Data.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace GradeProject
{
    public class QuizCardBase : ComponentBase
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        protected int questionIndex = 0;
        protected int score = 0;

        protected override Task OnInitializedAsync()
        {
            return LoadQuestionsAsync(); // Call the asynchronous method
        }

        protected void OptionSelected(string option)
        {
            if (option == Questions[questionIndex].Answer)
            {
                score++;
            }
            questionIndex++;
        }

        protected void RestartQuiz()
        {
            score = 0;
            questionIndex = 0;
        }

        private async Task LoadQuestionsAsync() // Change method signature to return Task
        {
            // Create questions synchronously
            Question q1 = new Question
            {
                QuestionTitle = "Ako sa deklaruje celočíselná premenná v C#?",
                Options = new List<string>() { "int x;", "integer x;", "x = int;", "int x = 5;" },
                Answer = "int x;"
            };

            Question q2 = new Question
            {
                QuestionTitle = "Ktoré kľúčové slovo sa používa na definovanie triedy v C#?",
                Options = new List<string>() { "class", "struct", "interface", "void" },
                Answer = "class"
            };

            Question q3 = new Question
            {
                QuestionTitle = "Čo znamená 'void' v deklarácii metódy?",
                Options = new List<string>() { "Vracia celé číslo", "Nevracia nič", "Vracia boolean", "Vracia objekt" },
                Answer = "Nevracia nič"
            };

            Question q4 = new Question
            {
                QuestionTitle = "Ako pridáte prvok na koniec zoznamu v C#?",
                Options = new List<string>() { "list.add()", "list.append()", "list.push()", "list.Add()" },
                Answer = "list.Add()"
            };

            Question q5 = new Question
            {
                QuestionTitle = "Aký je výstup nasledujúceho kódu: Console.WriteLine(5 > 3 ? 'Áno' : 'Nie')?",
                Options = new List<string>() { "Áno", "Nie", "Pravda", "Nepravda" },
                Answer = "Áno"
            };
            // Add questions to the list
            Questions.AddRange(new List<Question> { q1, q2, q3, q4, q5 });
        }
    }
}
