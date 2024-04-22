using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GradeProject.Data.Models;
using Microsoft.AspNetCore.Components;

public interface IQuizLoaderService
{
    Task<List<Question>> LoadQuestionsAsync(string id);
}

public class QuizLoaderService : IQuizLoaderService
{
    private NavigationManager NavigationManager { get; }

    public QuizLoaderService(NavigationManager navigationManager)
    {
        NavigationManager = navigationManager;
    }

    public async Task<List<Question>> LoadQuestionsAsync(string id)
    {

        switch (id)
        {
            case "intro":
                return AddIntroQuestions();
                break;

            default:
                NavigationManager.NavigateTo("/notfound");
                break;
        }

        return null;
    }

    private List<Question> AddIntroQuestions()
    {
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
        return new List<Question> { q1, q2, q3, q4, q5 };
    }
}
