class Blackjack : IGame
{
    float balance = 100;
    public void Start()
    {
        Console.WriteLine("Starting Blackjack");
    }

    public void StartRound()
    {
        Console.WriteLine("Starting Blackjack Round");
    }

    public void End()
    {
        Console.WriteLine("Ending Blackjack");
    }

    private void PrintBalance()
    {
        Console.WriteLine($"Balance: {balance}");
    }
}