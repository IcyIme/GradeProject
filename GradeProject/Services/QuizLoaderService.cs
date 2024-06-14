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
            case "instalation":
                return AddInsQuestions();
                break;
            case "firstprogram":
                return AddFirstProgramQuestions();
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
            QuestionTitle = "Ako sa vyslovuje C#?",
            Options = new List<string>() { "C number", "C sharp", "C hashtag", "C pound" },
            Answer = "C sharp"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Aké vlastnosti má jazyk C#?",
            Options = new List<string>() { "Dynamická typovanie", "Objektovo orientovaný", "Špecifický pre web development", "Štruktúrovaný syntax" },
            Answer = "Objektovo orientovaný"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Kedy bol C# prvýkrát predstavený a ktorá spoločnosť ho vyvinula?",
            Options = new List<string>() { "V roku 1995, vyvinula ho spoločnosť Google", "V roku 2000, vyvinula ho spoločnosť Microsoft", "V roku 2010, vyvinula ho spoločnosť Apple", "V roku 1990, vyvinula ho spoločnosť IBM" },
            Answer = "V roku 2000, vyvinula ho spoločnosť Microsoft"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Aká je najnovšia verzia jazyka C# a čo prináša?",
            Options = new List<string>() { "C# 8, pridáva podporu pre asynchronous programming", "C# 10, pridáva nové dátové typy", "C# 12, pridáva nové funkcie a vylepšenia", "C# 6, pridáva podporu pre GUI vývoj" },
            Answer = "C# 12, pridáva nové funkcie a vylepšenia"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Aký je jeden dôvod, prečo sa učiť C#?",
            Options = new List<string>() { "Vysoká popularita", "Jednoduchosť syntaxe", "Možnosť použitia výhradne na mobilné aplikácie", "Vysoká cena kurzov" },
            Answer = "Vysoká popularita"
        };

        Question q6 = new Question
        {
            QuestionTitle = "Aké výhody prináša používanie jazyka C# pre vývoj softvéru?",
            Options = new List<string>() { "Univerzálnosť, bohatý ekosystém a vysoký dopyt na trhu práce", "Statické typovanie, komplexná matematická knižnica a webový framework", "Jednoduchá integrácia s operačnými systémami, široká podpora pre databázové systémy a vysoká škálovateľnosť", "Vysoká rýchlosť kompilácie, intuitívne API a jednoduchá distribúcia aplikácií" },
            Answer = "Univerzálnosť, bohatý ekosystém a vysoký dopyt na trhu práce"
        };

        // Add questions to the list
        return new List<Question> { q1, q2, q3, q4, q5 };
    }

    private List<Question> AddInsQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Nainstaloval si?",
            Options = new List<string>() { "Ano", "Nie"},
            Answer = "Ano"
        };

        return new List<Question> { q1 };
    }
    
    private List<Question> AddFirstProgramQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Čo je C#?",
            Options = new List<string> { "Programovací jazyk", "Operačný systém", "Textový editor", "Webový prehliadač" },
            Answer = "Programovací jazyk"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Aká je hlavná funkcia C# programu?",
            Options = new List<string> { "start", "main", "run", "execute" },
            Answer = "main"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Čo vypíše program: Console.WriteLine(\"Hello, World!\");",
            Options = new List<string> { "Hello, World!", "Hello World", "Hello", "World" },
            Answer = "Hello, World!"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Čo znamená 'static' v deklarácii metódy?",
            Options = new List<string> { "Metóda je volaná bez vytvorenia inštancie triedy", "Metóda nemôže byť volaná", "Metóda je volaná iba raz", "Metóda je volaná viacerými vláknami" },
            Answer = "Metóda je volaná bez vytvorenia inštancie triedy"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Aká trieda sa používa na výstup do konzoly?",
            Options = new List<string> { "System", "Console", "Output", "Print" },
            Answer = "Console"
        };

        return new List<Question> { q1, q2, q3, q4, q5 };
    }
}
