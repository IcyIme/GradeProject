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
            case "variables":
                return AddVariableTypeQuestions();
                break;
            case "operators":
                return AddOperatorQuestions();
                break;
            case "loopandif":
                return AddBranchingAndLoopQuestions();
                break;
            case "methods":
                //todo add quiz
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
    
    private List<Question> AddVariableTypeQuestions()
{
    Question q1 = new Question
    {
        QuestionTitle = "Ako deklarujeme premennú typu int v C#?",
        Options = new List<string>() { "int cislo;", "number cislo;", "integer cislo;", "int: cislo;" },
        Answer = "int cislo;"
    };

    Question q2 = new Question
    {
        QuestionTitle = "Ktorý z nasledujúcich typov je 64-bitové celé číslo so znamienkom?",
        Options = new List<string>() { "int", "long", "short", "byte" },
        Answer = "long"
    };

    Question q3 = new Question
    {
        QuestionTitle = "Ktorý typ premennej by ste použili na uloženie desatinného čísla s najvyššou presnosťou?",
        Options = new List<string>() { "float", "double", "decimal", "int" },
        Answer = "decimal"
    };

    Question q4 = new Question
    {
        QuestionTitle = "Čo bude výsledkom nasledujúceho kódu?\n\n\nint a = 10;\nint b = 20;\nint suma = a + b;\n",
        Options = new List<string>() { "10", "20", "30", "40" },
        Answer = "30"
    };

    Question q5 = new Question
    {
        QuestionTitle = "Ako deklarujeme a inicializujeme premennú typu string?",
        Options = new List<string>() { "string sprava;", "string sprava = 'Ahoj!';", "string sprava = \"Ahoj!\";", "char sprava = \"Ahoj!\";" },
        Answer = "string sprava = \"Ahoj!\";"
    };

    Question q6 = new Question
    {
        QuestionTitle = "Ktorý z nasledujúcich príkazov vykoná implicitnú konverziu?",
        Options = new List<string>() { "int a = 10; double b = a;", "double a = 10.5; int b = a;", "int a = 10; float b = a;", "float a = 10.5f; int b = a;" },
        Answer = "int a = 10; double b = a;"
    };

    Question q7 = new Question
    {
        QuestionTitle = "Akú hodnotu bude mať premenna `bool jePravda = (10 > 5);`?",
        Options = new List<string>() { "true", "false", "null", "undefined" },
        Answer = "true"
    };

    Question q8 = new Question
    {
        QuestionTitle = "Ktorý typ premennej by ste použili na uloženie jedného znaku?",
        Options = new List<string>() { "char", "string", "bool", "byte" },
        Answer = "char"
    };

    // Add questions to the list
    return new List<Question> { q1, q2, q3, q4, q5, q6, q7, q8 };
}
private List<Question> AddOperatorQuestions()
{
    Question q1 = new Question
    {
        QuestionTitle = "Aký je výsledok nasledujúceho výrazu: `int a = 10; int b = 3; int c = a % b;`?",
        Options = new List<string>() { "1", "2", "3", "0" },
        Answer = "1"
    };

    Question q2 = new Question
    {
        QuestionTitle = "Ktorý operátor sa používa na porovnanie rovnosti dvoch hodnôt?",
        Options = new List<string>() { "=", "==", "===", "!=" },
        Answer = "=="
    };

    Question q3 = new Question
    {
        QuestionTitle = "Aký bude výsledok nasledujúceho výrazu: `bool vysledok = (5 > 3) && (10 < 15);`?",
        Options = new List<string>() { "true", "false", "null", "undefined" },
        Answer = "true"
    };

    Question q4 = new Question
    {
        QuestionTitle = "Čo znamená operátor `!` v C#?",
        Options = new List<string>() { "Logické AND", "Logické OR", "Logické NOT", "Logické XOR" },
        Answer = "Logické NOT"
    };

    Question q5 = new Question
    {
        QuestionTitle = "Ktorý operátor sa používa na priradenie hodnoty premennej?",
        Options = new List<string>() { "+=", "==", "=", "!=" },
        Answer = "="
    };

    Question q6 = new Question
    {
        QuestionTitle = "Aký je výsledok nasledujúceho kódu?\n\n\nint x = 5;\nx *= 2;\n",
        Options = new List<string>() { "5", "10", "15", "2" },
        Answer = "10"
    };

    Question q7 = new Question
    {
        QuestionTitle = "Aký je výsledok nasledujúceho výrazu: `int x = 5; x++;`?",
        Options = new List<string>() { "4", "5", "6", "7" },
        Answer = "6"
    };

    Question q8 = new Question
    {
        QuestionTitle = "Čo bude výsledkom nasledujúceho výrazu?\n\n`\nbool a = true;\nbool b = false;\nbool vysledok = a || b;\n`",
        Options = new List<string>() { "true", "false", "null", "undefined" },
        Answer = "true"
    };

    // Add questions to the list
    return new List<Question> { q1, q2, q3, q4, q5, q6, q7, q8 };
}

private List<Question> AddBranchingAndLoopQuestions()
{
    Question q1 = new Question
    {
        QuestionTitle = "Čo je to if-else vetvenie v C#?",
        Options = new List<string>() 
        { 
            "Cyklus, ktorý sa vykonáva, kým je podmienka pravdivá",
            "Štruktúra, ktorá vykonáva rôzne časti kódu v závislosti od podmienky",
            "Štruktúra, ktorá umožňuje opakované vykonávanie časti kódu",
            "Štruktúra na prácu s kolekciami"
        },
        Answer = "Štruktúra, ktorá vykonáva rôzne časti kódu v závislosti od podmienky"
    };

    Question q2 = new Question
    {
        QuestionTitle = "Aký je rozdiel medzi while a do-while cyklom?",
        Options = new List<string>()
        {
            "While cyklus sa vykonáva aspoň raz, do-while cyklus nie",
            "Do-while cyklus sa vykonáva aspoň raz, while cyklus nie",
            "Oba sa vykonávajú aspoň raz",
            "Žiaden rozdiel, oba sú rovnaké"
        },
        Answer = "Do-while cyklus sa vykonáva aspoň raz, while cyklus nie"
    };

    Question q3 = new Question
    {
        QuestionTitle = "Čo sa stane, ak v switch-case vetvení žiadny case nesúhlasí?",
        Options = new List<string>()
        {
            "Kód sa zastaví s chybou",
            "Vykoná sa default blok, ak existuje",
            "Vykoná sa prvý case blok",
            "Kód sa opakuje od začiatku"
        },
        Answer = "Vykoná sa default blok, ak existuje"
    };

    Question q4 = new Question
    {
        QuestionTitle = "Aký je účel foreach cyklu v C#?",
        Options = new List<string>()
        {
            "Iteruje cez všetky prvky v kolekcii alebo poli",
            "Opakuje blok kódu určitý počet krát",
            "Vykonáva kód len ak je podmienka pravdivá",
            "Vykonáva kód aspoň raz"
        },
        Answer = "Iteruje cez všetky prvky v kolekcii alebo poli"
    };

    Question q5 = new Question
    {
        QuestionTitle = "Ako sa deklaruje for cyklus v C#?",
        Options = new List<string>()
        {
            "for (int i = 0; i < 10; i++)",
            "foreach (int i in collection)",
            "do { //code } while (condition)",
            "while (condition) { //code }"
        },
        Answer = "for (int i = 0; i < 10; i++)"
    };

    // Add questions to the list
    return new List<Question> { q1, q2, q3, q4, q5 };
}

}
