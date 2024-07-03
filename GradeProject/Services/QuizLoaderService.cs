using GradeProject.Data.Models;
using Microsoft.AspNetCore.Components;

public interface IQuizLoaderService
{
    Task<List<Question>> LoadQuestionsAsync(string id, string course);
}

public class QuizLoaderService : IQuizLoaderService
{
    private NavigationManager NavigationManager { get; }

    public QuizLoaderService(NavigationManager navigationManager)
    {
        NavigationManager = navigationManager;
    }

    public async Task<List<Question>> LoadQuestionsAsync(string id, string course)
    {
        switch (course)
        {
            case "cs":
                switch (id)
                {
                    case "intro":
                        return AddIntroQuestions();
                        
                    case "instalation":
                        return AddInsQuestions();
                        
                    case "firstprogram":
                        return AddFirstProgramQuestions();
                        
                    case "variables":
                        return AddVariableTypeQuestions();
                        
                    case "operators":
                        return AddOperatorQuestions();
                    
                    case "loopandif":
                        return AddBranchingAndLoopQuestions();

                    case "methods":
                        return AddFunctionQuestions();

                    case "parameters":
                        return AddParameterAndReturnTypeQuestions();

                    case "recursion":
                        return AddRecursionQuestions();

                    case "array":
                        return AddArrayQuestions();

                    case "datatypes":
                        return AddCollectionsQuestions();

                    case "oop":
                        return AddOOPQuestions();

                    case "string":
                        return AddStringManipulationQuestions();

                    case "input":
                        return AddIOQuestions();

                    case "trycatch":
                        return AddExceptionHandlingQuestions();

                    case "async":
                        return AddAsyncProgrammingQuestions();

                    default:
                        NavigationManager.NavigateTo("/notfound");
                        break;
                } 
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

private List<Question> AddFunctionQuestions()
{
    Question q1 = new Question
    {
        QuestionTitle = "Čo je to funkcia (metóda) v C#?",
        Options = new List<string>() 
        { 
            "Premenná, ktorá uchováva hodnoty",
            "Blok kódu, ktorý vykonáva konkrétnu úlohu a môže byť volaný podľa potreby",
            "Typ údajov pre čísla s desatinnou čiarkou",
            "Operátor na porovnávanie hodnôt"
        },
        Answer = "Blok kódu, ktorý vykonáva konkrétnu úlohu a môže byť volaný podľa potreby"
    };

    Question q2 = new Question
    {
        QuestionTitle = "Ako sa definuje funkcia v C#?",
        Options = new List<string>()
        {
            "returnType NazovFunkcie(parametre) { // telo funkcie }",
            "int premenná = hodnota;",
            "public class MyClass { }",
            "if (podmienka) { // telo podmienky }"
        },
        Answer = "returnType NazovFunkcie(parametre) { // telo funkcie }"
    };

    Question q3 = new Question
    {
        QuestionTitle = "Čo znamená kľúčové slovo 'void' pri definovaní funkcie?",
        Options = new List<string>()
        {
            "Funkcia nevracia žiadnu hodnotu",
            "Funkcia vracia celočíselnú hodnotu",
            "Funkcia vracia reťazec",
            "Funkcia sa nikdy nevykoná"
        },
        Answer = "Funkcia nevracia žiadnu hodnotu"
    };

    Question q4 = new Question
    {
        QuestionTitle = "Ako zavoláte funkciu s názvom 'Scitaj', ktorá prijíma dva argumenty typu int?",
        Options = new List<string>()
        {
            "Scitaj(int a, int b);",
            "Scitaj(a, b);",
            "int vysledok = Scitaj(5, 3);",
            "return Scitaj(5, 3);"
        },
        Answer = "int vysledok = Scitaj(5, 3);"
    };

    Question q5 = new Question
    {
        QuestionTitle = "Čo je to preťaženie funkcie v C#?",
        Options = new List<string>()
        {
            "Definovanie viacerých funkcií s rovnakým názvom, ale rôznymi parametrami",
            "Volanie tej istej funkcie viackrát",
            "Používanie funkcie v inom projekte",
            "Deklarovanie globálnej premennej"
        },
        Answer = "Definovanie viacerých funkcií s rovnakým názvom, ale rôznymi parametrami"
    };

    // Add questions to the list
    return new List<Question> { q1, q2, q3, q4, q5 };
}
private List<Question> AddParameterAndReturnTypeQuestions()
{
    Question q1 = new Question
    {
        QuestionTitle = "Čo je to parameter vo funkcii v C#?",
        Options = new List<string>() 
        { 
            "Premenná, ktorá uchováva hodnoty",
            "Typ údajov pre čísla s desatinnou čiarkou",
            "Logický typ, ktorý môže obsahovať hodnoty true alebo false",
            "Vstupná hodnota, ktorá sa odovzdáva funkcii"
        },
        Answer = "Vstupná hodnota, ktorá sa odovzdáva funkcii"
    };

    Question q2 = new Question
    {
        QuestionTitle = "Ako sa definuje parameter s predvolenou hodnotou vo funkcii v C#?",
        Options = new List<string>()
        {
            "public void Vypis(string text = \"Ahoj\")",
            "public void Vypis(string text)",
            "public void Vypis(string text) = \"Ahoj\"",
            "public void Vypis(string = \"Ahoj\")"
        },
        Answer = "public void Vypis(string text = \"Ahoj\")"
    };

    Question q3 = new Question
    {
        QuestionTitle = "Čo znamená návratový typ funkcie v C#?",
        Options = new List<string>()
        {
            "Typ hodnoty, ktorú funkcia vracia",
            "Názov funkcie",
            "Počet parametrov funkcie",
            "Názov triedy, v ktorej je funkcia definovaná"
        },
        Answer = "Typ hodnoty, ktorú funkcia vracia"
    };

    Question q4 = new Question
    {
        QuestionTitle = "Ako zavoláte funkciu 'Scitaj', ktorá prijíma dva argumenty typu int a vracia int?",
        Options = new List<string>()
        {
            "Scitaj(int a, int b);",
            "Scitaj(a, b);",
            "int vysledok = Scitaj(5, 3);",
            "return Scitaj(5, 3);"
        },
        Answer = "int vysledok = Scitaj(5, 3);"
    };

    Question q5 = new Question
    {
        QuestionTitle = "Ako vrátiť viacero hodnôt z funkcie v C#?",
        Options = new List<string>()
        {
            "Pomocou kľúčového slova 'void'",
            "Pomocou 'tuples' alebo objektov",
            "Pomocou 'return' viackrát",
            "Nie je možné vrátiť viacero hodnôt z funkcie"
        },
        Answer = "Pomocou 'tuples' alebo objektov"
    };

    // Add questions to the list
    return new List<Question> { q1, q2, q3, q4, q5 };
}
private List<Question> AddRecursionQuestions()
{
    Question q1 = new Question
    {
        QuestionTitle = "Čo je to rekurzia v programovaní?",
        Options = new List<string>()
        {
            "Technika, pri ktorej funkcia volá inú funkciu",
            "Technika, pri ktorej funkcia volá samu seba",
            "Technika, pri ktorej sa používa cyklus",
            "Technika, pri ktorej sa používa viacnásobné priradenie"
        },
        Answer = "Technika, pri ktorej funkcia volá samu seba"
    };

    Question q2 = new Question
    {
        QuestionTitle = "Ktorá funkcia je správnym príkladom rekurzie?",
        Options = new List<string>()
        {
            "public int Add(int a, int b) { return a + b; }",
            "public int Faktorial(int n) { if (n == 0) return 1; return n * Faktorial(n - 1); }",
            "public void Print() { for (int i = 0; i < 10; i++) { Console.WriteLine(i); } }",
            "public int Multiply(int a, int b) { return a * b; }"
        },
        Answer = "public int Faktorial(int n) { if (n == 0) return 1; return n * Faktorial(n - 1); }"
    };

    Question q3 = new Question
    {
        QuestionTitle = "Čo je základný prípad v rekurzii?",
        Options = new List<string>()
        {
            "Prípad, kedy funkcia volá inú funkciu",
            "Prípad, kedy funkcia volá samu seba",
            "Prípad, kedy funkcia prestane volať samu seba",
            "Prípad, kedy funkcia používa cyklus"
        },
        Answer = "Prípad, kedy funkcia prestane volať samu seba"
    };

    Question q4 = new Question
    {
        QuestionTitle = "Ktorá z nasledujúcich funkcií počíta Fibonacciho číslo rekurzívne?",
        Options = new List<string>()
        {
            "public int Fibonacci(int n) { if (n <= 0) return 0; if (n == 1) return 1; return Fibonacci(n - 1) + Fibonacci(n - 2); }",
            "public int Fibonacci(int n) { int a = 0; int b = 1; for (int i = 2; i <= n; i++) { int c = a + b; a = b; b = c; } return b; }",
            "public int Fibonacci(int n) { return n * 2; }",
            "public int Fibonacci(int n) { if (n <= 1) return n; return n * Fibonacci(n - 1); }"
        },
        Answer = "public int Fibonacci(int n) { if (n <= 0) return 0; if (n == 1) return 1; return Fibonacci(n - 1) + Fibonacci(n - 2); }"
    };

    Question q5 = new Question
    {
        QuestionTitle = "Kedy je rekurzia neefektívna?",
        Options = new List<string>()
        {
            "Keď má funkcia veľa základných prípadov",
            "Keď má funkcia málo základných prípadov",
            "Keď sa rekurzívne volanie neustále opakuje a riešenie problému sa nekončí",
            "Keď funkcia používa veľa parametrov"
        },
        Answer = "Keď sa rekurzívne volanie neustále opakuje a riešenie problému sa nekončí"
    };

    // Add questions to the list
    return new List<Question> { q1, q2, q3, q4, q5 };
}
    private List<Question> AddArrayQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Čo je jednorozmerné pole?",
            Options = new List<string>()
        {
            "Pole s jedným riadkom a viacerými stĺpcami",
            "Pole s viacerými riadkami a jedným stĺpcom",
            "Lineárny zoznam prvkov rovnakého typu",
            "Pole s viacerými rozmermi"
        },
            Answer = "Lineárny zoznam prvkov rovnakého typu"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Ako deklarujete jednorozmerné pole celých čísel s 5 prvkami v C#?",
            Options = new List<string>()
        {
            "int[] pole = new int(5);",
            "int[5] pole;",
            "int[] pole = new int[5];",
            "int pole = new int[5];"
        },
            Answer = "int[] pole = new int[5];"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Ako priradíte hodnotu 10 prvému prvku poľa 'pole'?",
            Options = new List<string>()
        {
            "pole[1] = 10;",
            "pole[0] = 10;",
            "pole[10] = 0;",
            "pole = 10;"
        },
            Answer = "pole[0] = 10;"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Čo je dvojrozmerné pole?",
            Options = new List<string>()
        {
            "Pole s jedným riadkom",
            "Pole s jedným stĺpcom",
            "Tabuľka hodnôt s riadkami a stĺpcami",
            "Pole s tromi rozmermi"
        },
            Answer = "Tabuľka hodnôt s riadkami a stĺpcami"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Ako deklarujete dvojrozmerné pole s 2 riadkami a 3 stĺpcami v C#?",
            Options = new List<string>()
        {
            "int[,] matica = new int(2, 3);",
            "int[2, 3] matica;",
            "int[,] matica = new int[2, 3];",
            "int[,] matica = new int[3, 2];"
        },
            Answer = "int[,] matica = new int[2, 3];"
        };

        Question q6 = new Question
        {
            QuestionTitle = "Ako priradíte hodnotu 5 prvku v druhom riadku a prvom stĺpci dvojrozmerného poľa 'matica'?",
            Options = new List<string>()
        {
            "matica[0, 1] = 5;",
            "matica[1, 0] = 5;",
            "matica[1, 1] = 5;",
            "matica[0, 0] = 5;"
        },
            Answer = "matica[1, 0] = 5;"
        };

        Question q7 = new Question
        {
            QuestionTitle = "Čo sú zubaté polia?",
            Options = new List<string>()
        {
            "Polia s rôznou dĺžkou riadkov",
            "Polia s rovnakou dĺžkou riadkov",
            "Polia s viacerými rozmermi",
            "Polia s jedným rozmerom"
        },
            Answer = "Polia s rôznou dĺžkou riadkov"
        };

        Question q8 = new Question
        {
            QuestionTitle = "Ako deklarujete zubaté pole celých čísel v C#?",
            Options = new List<string>()
        {
            "int[][] zubatePole = new int[3];",
            "int[,] zubatePole = new int[3][];",
            "int[][] zubatePole = new int[3][];",
            "int[3][] zubatePole;"
        },
            Answer = "int[][] zubatePole = new int[3][];"
        };

        // Add questions to the list
        return new List<Question> { q1, q2, q3, q4, q5, q6, q7, q8 };
    }
    private List<Question> AddCollectionsQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Čo je `List<T>` v C#?",
            Options = new List<string>()
        {
            "Statická kolekcia prvkov rovnakého typu",
            "Dynamická kolekcia prvkov rôzneho typu",
            "Dynamická kolekcia prvkov rovnakého typu",
            "Statická kolekcia prvkov rôzneho typu"
        },
            Answer = "Dynamická kolekcia prvkov rovnakého typu"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Ako pridáte prvok do `List<int>` s názvom 'cisla'?",
            Options = new List<string>()
        {
            "cisla.Add(5);",
            "cisla.Append(5);",
            "cisla.Insert(5);",
            "cisla.Push(5);"
        },
            Answer = "cisla.Add(5);"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Čo je `Dictionary<TKey, TValue>` v C#?",
            Options = new List<string>()
        {
            "Kolekcia párov kľúč-hodnota",
            "Kolekcia hodnôt bez kľúčov",
            "Dynamická kolekcia bez kľúčov",
            "Statická kolekcia párov kľúč-hodnota"
        },
            Answer = "Kolekcia párov kľúč-hodnota"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Ako odstránite prvok so zadaným kľúčom z `Dictionary<string, int>` s názvom 'slovnik'?",
            Options = new List<string>()
        {
            "slovnik.Remove('kluc');",
            "slovnik.Delete('kluc');",
            "slovnik.Clear('kluc');",
            "slovnik.Pop('kluc');"
        },
            Answer = "slovnik.Remove('kluc');"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Aký typ kolekcie je `Queue<T>`?",
            Options = new List<string>()
        {
            "LIFO (Last-In-First-Out)",
            "FIFO (First-In-First-Out)",
            "Dynamická kolekcia bez poradia",
            "Statická kolekcia bez poradia"
        },
            Answer = "FIFO (First-In-First-Out)"
        };

        Question q6 = new Question
        {
            QuestionTitle = "Ako pridáte prvok do `Queue<int>` s názvom 'fronta'?",
            Options = new List<string>()
        {
            "fronta.Add(5);",
            "fronta.Push(5);",
            "fronta.Enqueue(5);",
            "fronta.Insert(5);"
        },
            Answer = "fronta.Enqueue(5);"
        };

        Question q7 = new Question
        {
            QuestionTitle = "Aký typ kolekcie je `Stack<T>`?",
            Options = new List<string>()
        {
            "FIFO (First-In-First-Out)",
            "LIFO (Last-In-First-Out)",
            "Dynamická kolekcia bez poradia",
            "Statická kolekcia bez poradia"
        },
            Answer = "LIFO (Last-In-First-Out)"
        };

        Question q8 = new Question
        {
            QuestionTitle = "Ako odstránite a získate vrchný prvok zo `Stack<int>` s názvom 'zasobnik'?",
            Options = new List<string>()
        {
            "zasobnik.Remove();",
            "zasobnik.Pop();",
            "zasobnik.Dequeue();",
            "zasobnik.Clear();"
        },
            Answer = "zasobnik.Pop();"
        };

        // Add questions to the list
        return new List<Question> { q1, q2, q3, q4, q5, q6, q7, q8 };
    }
    private List<Question> AddOOPQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Čo je trieda v C#?",
            Options = new List<string>() { "Šablóna alebo blueprint pre objekty", "Premenná", "Metóda", "Kolekcia dát" },
            Answer = "Šablóna alebo blueprint pre objekty"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Čo je objekt v C#?",
            Options = new List<string>() { "Inštancia triedy", "Premenná", "Metóda", "Kolekcia dát" },
            Answer = "Inštancia triedy"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Čo je konštruktor?",
            Options = new List<string>() { "Špeciálna metóda na inicializáciu objektov", "Šablóna alebo blueprint pre objekty", "Premenná", "Metóda na ukončenie programu" },
            Answer = "Špeciálna metóda na inicializáciu objektov"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Čo je zapúzdrenie (encapsulation)?",
            Options = new List<string>() { "Skrytie interných detailov objektu", "Dedenie vlastností a metód", "Použitie rovnakého mena pre rôzne metódy", "Vytváranie nových objektov" },
            Answer = "Skrytie interných detailov objektu"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Čo je dedičnosť (inheritance)?",
            Options = new List<string>() { "Kopírovanie kódu z jednej triedy do druhej", "Schopnosť jednej triedy dediť vlastnosti a metódy inej triedy", "Použitie rovnakého mena pre rôzne metódy", "Skrytie interných detailov objektu" },
            Answer = "Schopnosť jednej triedy dediť vlastnosti a metódy inej triedy"
        };

        Question q6 = new Question
        {
            QuestionTitle = "Čo je polymorfizmus?",
            Options = new List<string>() { "Schopnosť používať rovnaký kód pre rôzne objekty", "Vytváranie nových objektov", "Dedenie vlastností a metód", "Skrytie interných detailov objektu" },
            Answer = "Schopnosť používať rovnaký kód pre rôzne objekty"
        };

        return new List<Question> { q1, q2, q3, q4, q5, q6 };
    }
    private List<Question> AddStringManipulationQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Akú vlastnosť použijete na zistenie dĺžky reťazca v C#?",
            Options = new List<string>() { "Size", "Length", "Count", "Capacity" },
            Answer = "Length"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Akú metódu použijete na nahradenie podreťazca iným podreťazcom v C#?",
            Options = new List<string>() { "Replace", "Change", "Swap", "Substitute" },
            Answer = "Replace"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Ako sa volá technika, ktorá umožňuje vkladať premenné priamo do reťazca?",
            Options = new List<string>() { "String Concatenation", "String Interpolation", "String Formatting", "String Parsing" },
            Answer = "String Interpolation"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Ktorá z nasledujúcich metód vyhľadáva podreťazec v reťazci?",
            Options = new List<string>() { "Search", "Find", "IndexOf", "Locate" },
            Answer = "IndexOf"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Ako v C# vytvoríte prázdny reťazec?",
            Options = new List<string>() { "string prazdny = '';", "string prazdny = ' '", "string prazdny = \"\";", "string prazdny = null;" },
            Answer = "string prazdny = \"\";"
        };

        return new List<Question> { q1, q2, q3, q4, q5 };
    }
    private List<Question> AddIOQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Ktorá metóda sa používa na čítanie všetkého textu zo súboru v C#?",
            Options = new List<string>() { "ReadAll", "ReadText", "ReadFile", "ReadAllText" },
            Answer = "ReadAllText"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Akú metódu použijete na vypísanie textu na konzolu bez prechodu na nový riadok?",
            Options = new List<string>() { "Console.Write", "Console.WriteLine", "Console.Print", "Console.Output" },
            Answer = "Console.Write"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Ako načítate celé číslo z konzoly?",
            Options = new List<string>() { "int.Parse(Console.ReadLine())", "Convert.ToInt32(Console.ReadLine())", "int.Parse(Console.Read())", "a alebo b" },
            Answer = "a alebo b"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Aká je správna syntax na zápis viacerých riadkov do súboru v C#?",
            Options = new List<string>() { "File.WriteLines(\"subor.txt\", riadky)", "File.WriteAllLines(\"subor.txt\", riadky)", "File.WriteAllText(\"subor.txt\", riadky)", "File.AppendAllLines(\"subor.txt\", riadky)" },
            Answer = "File.WriteAllLines(\"subor.txt\", riadky)"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Ktorá z týchto metód je vhodná na čítanie jednotlivých riadkov textu zo súboru?",
            Options = new List<string>() { "ReadLines", "ReadAllLines", "ReadEachLine", "ReadLineByLine" },
            Answer = "ReadAllLines"
        };

        return new List<Question> { q1, q2, q3, q4, q5 };
    }
    private List<Question> AddExceptionHandlingQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Ktorý blok sa vykoná vždy, bez ohľadu na to, či bola vyvolaná výnimka?",
            Options = new List<string>() { "try", "catch", "finally", "none of the above" },
            Answer = "finally"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Ako sa volá výnimka vyvolaná pri pokuse o delenie nulou?",
            Options = new List<string>() { "DivideByZeroException", "NullReferenceException", "IndexOutOfRangeException", "ArithmeticException" },
            Answer = "DivideByZeroException"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Aká je správna syntax na zachytenie výnimky, keď index poľa je mimo rozsah?",
            Options = new List<string>() { "catch (ArrayIndexOutOfBoundsException ex)", "catch (IndexOutOfRangeException ex)", "catch (OutOfBoundsException ex)", "catch (Exception ex)" },
            Answer = "catch (IndexOutOfRangeException ex)"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Ktorá trieda je základnou triedou pre všetky výnimky v C#?",
            Options = new List<string>() { "Exception", "Error", "RuntimeException", "Throwable" },
            Answer = "Exception"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Aká je správna syntax na použitie bloku finally?",
            Options = new List<string>() { "finally { // code }", "final { // code }", "finalize { // code }", "lastly { // code }" },
            Answer = "finally { // code }"
        };

        return new List<Question> { q1, q2, q3, q4, q5 };
    }
    private List<Question> AddAsyncProgrammingQuestions()
    {
        Question q1 = new Question
        {
            QuestionTitle = "Čo umožňuje asynchronné programovanie v C#?",
            Options = new List<string>() { "Vykonávanie viacerých operácií súčasne bez blokovania hlavného vlákna", "Rýchlejšie kompilovanie kódu", "Zlepšenie čitateľnosti kódu", "Zjednodušenie práce s dátovými typmi" },
            Answer = "Vykonávanie viacerých operácií súčasne bez blokovania hlavného vlákna"
        };

        Question q2 = new Question
        {
            QuestionTitle = "Ako sa deklaruje asynchronná metóda v C#?",
            Options = new List<string>() { "Pomocou kľúčového slova async", "Pomocou kľúčového slova await", "Pomocou kľúčového slova async a await", "Pomocou kľúčového slova parallel" },
            Answer = "Pomocou kľúčového slova async"
        };

        Question q3 = new Question
        {
            QuestionTitle = "Čo robí kľúčové slovo await v asynchronnej metóde?",
            Options = new List<string>() { "Deklaruje asynchronnú metódu", "Spúšťa úlohu na novom vlákne", "Čaká na dokončenie asynchronnej operácie", "Vytvára nové vlákno" },
            Answer = "Čaká na dokončenie asynchronnej operácie"
        };

        Question q4 = new Question
        {
            QuestionTitle = "Ako sa v C# vytvára nové vlákno?",
            Options = new List<string>() { "Pomocou triedy Thread", "Pomocou triedy Task", "Pomocou kľúčového slova async", "Pomocou kľúčového slova await" },
            Answer = "Pomocou triedy Thread"
        };

        Question q5 = new Question
        {
            QuestionTitle = "Ktorá trieda umožňuje paralelné spracovanie úloh?",
            Options = new List<string>() { "Thread", "Task", "Parallel", "Async" },
            Answer = "Parallel"
        };

        return new List<Question> { q1, q2, q3, q4, q5 };
    }

}
