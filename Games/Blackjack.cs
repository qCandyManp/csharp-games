class Blackjack : IGame
{
    float balance = 100;

    public void Start()
    {
        Console.WriteLine("Starting Blackjack...");

        PrintBalance();

        StartRound();
    }

    public void StartRound()
    {
        Console.WriteLine("Starting Round...");

        // Make initial bet
        MakeBet();

        CardDeck deck = new CardDeck();

        // Deal cards
        Hand playerHand = new Hand(deck.PickCard());
        Hand dealerHand = new Hand(deck.PickCard());

        playerHand.AddCard(deck.PickCard());
        dealerHand.AddCard(deck.PickCard());

        // Print hands
        Console.WriteLine("Your hand:");
        playerHand.Print();

        if (balance <= 0)
        {
            Console.WriteLine("You're out of money!");
            End();
        }
    }

    public void End()
    {
        Console.WriteLine("Game Over!");
    }

    private void PrintBalance()
    {
        Console.WriteLine($"Balance: {balance}");
    }

    private void MakeBet()
    {
        Console.WriteLine("Enter your bet:");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int bet))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            MakeBet();
        }

        if (bet > balance)
        {
            Console.WriteLine("You don't have enough money for that bet.");
            MakeBet();
        }

        balance -= bet;

        Console.WriteLine($"Bet of {bet} placed.");
        PrintBalance();
    }
}