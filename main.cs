start:
Console.Clear();
Console.WriteLine("Welcome to Stroop!");

Console.WriteLine("\nPlease choose an option!");
Console.WriteLine("1 - Play");
Console.WriteLine("2 - How to play");

Console.Write("\nChoose an option:");
string input = Console.ReadLine();

if (input == "2")
{
    Console.Clear();
    Console.WriteLine("HOW TO PLAY!");
    Console.WriteLine("\nA text will appear that is a color,");
    Console.WriteLine("the text itself will be a random color");
    Console.WriteLine("you need to press N if the text color");
    Console.WriteLine("doesn't match the text itself.");
    Console.WriteLine("you need to press Y if the text color");
    Console.WriteLine("matches the text.");
    Console.WriteLine("You have a limited time depending on your difficulty.");

    Console.WriteLine("\nPress any key to go back to menu...");

    do { while (!Console.KeyAvailable) { } } while (Console.ReadKey(true).Key == ConsoleKey.Escape);

    goto start;
}
else if (input == "1")
{
    int difficulty = 0;

    Console.WriteLine("Please choose a difficulty !");
    Console.WriteLine("\n3 - Very hard");
    Console.WriteLine("2 - Medium");
    Console.WriteLine("1 - Easy");

    Console.Write("\nChoose an option:");
    string DifficultyInput = Console.ReadLine();

    if (DifficultyInput == "1")
    {
        difficulty = 3000;
    }
    else if (DifficultyInput == "2")
    {
        difficulty = 2000;
    }
    else if (DifficultyInput == "3")
    {
        difficulty = 1000;
    }

    Console.WriteLine("Press any key to start!");

    do { while (!Console.KeyAvailable) { } } while (Console.ReadKey(true).Key == ConsoleKey.Escape);

    int score = 0;
    Console.Clear();
    Console.WriteLine("Press Y or N!");

    while (true)
    {
        string[] colors = { "Red", "Green", "Blue" };
        Random rand = new Random();
        int RandomNum = rand.Next(colors.Length);

        int[] ForegroundColors = { 12, 10, 9 };
        Random randForeground = new Random();
        int RandomForeground = randForeground.Next(colors.Length);

        Console.ForegroundColor = (ConsoleColor)ForegroundColors[RandomForeground];
        Console.WriteLine(colors[RandomNum]);

        bool answerGiven = false;
        ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();

        Timer timer = new Timer((state) =>
        {
            if (!answerGiven)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lost!");
                Console.WriteLine("Your score is " + score);
                Console.WriteLine("Press any key to restart.");
                do { while (!Console.KeyAvailable) { } } while (Console.ReadKey(true).Key == ConsoleKey.Escape);
                Console.ResetColor();
            }
        }, null, difficulty, Timeout.Infinite);

        while (!answerGiven)
        {
            KeyInfo = Console.ReadKey(true);

            if (KeyInfo.Key == ConsoleKey.Y || KeyInfo.Key == ConsoleKey.N)
            {
                timer.Dispose();
                answerGiven = true;
            }
        }

        if (KeyInfo.Key == ConsoleKey.Y && Console.ForegroundColor.ToString() == colors[RandomNum] ||
            KeyInfo.Key == ConsoleKey.N && Console.ForegroundColor.ToString() != colors[RandomNum])
        {
            Console.Clear();
            Console.WriteLine("Perfect!");
            score++;
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost!");
            Console.WriteLine("Your score is " + score);
            Console.WriteLine("Press any key to restart.");
            do { while (!Console.KeyAvailable) { } } while (Console.ReadKey(true).Key == ConsoleKey.Escape);
            Console.ResetColor();
            
            goto start;
        }
    }
}
