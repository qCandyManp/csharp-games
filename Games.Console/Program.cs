class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to my little console game collection!");
        Console.WriteLine("---------------------------------------------");

        string[] gameList = [
            "Blackjack",
        ];

        Console.WriteLine("Here are the games you can play:");
        for (int i = 0; i < gameList.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {gameList[i]}");
        }

        Console.WriteLine("Please enter the number of the game you want to play:");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int gameIndex) || gameList[gameIndex - 1] == null)
        {
            Console.WriteLine("Invalid input. Please enter a number from the list.");
            Main(args);
        }

        string gameName = gameList[gameIndex - 1];

        switch (gameName)
        {
            case "Blackjack":
                Console.Clear();
                Blackjack blackjack = new();
                blackjack.Start();
                break;
            default:
                break;
        }
    }
}