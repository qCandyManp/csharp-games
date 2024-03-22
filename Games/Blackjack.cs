class Blackjack : IGame
{
    int balance = 100;

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
        int bet = MakeBet();

        CardDeck deck = new CardDeck();

        // Deal cards
        Hand playerHand = new Hand(deck.PickCard());
        Hand dealerHand = new Hand(deck.PickCard());

        playerHand.AddCard(deck.PickCard());
        dealerHand.AddCard(deck.PickCard());

        // Print hands
        Console.WriteLine("Dealer's hand:");
        dealerHand.Print();

        Console.WriteLine("Your hand:");
        playerHand.Print();

        bool blackjack = playerHand.GetValue() == 21;
        bool bust = playerHand.GetValue() > 21;
        bool stand = false;

        while (!blackjack && !bust && !stand)
        {
            Console.WriteLine("Hit (y) or Stand (n)?");
            string? input = Console.ReadLine();

            if (input == "y")
            {
                playerHand.AddCard(deck.PickCard());
                playerHand.Print();

                blackjack = playerHand.GetValue() == 21;
                bust = playerHand.GetValue() > 21;
            }
            else if (input == "n")
            {
                stand = true;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter (y) for hit or (n) for stand.");
            }
        }

        if (blackjack)
        {
            Console.WriteLine("Blackjack!");
            End();
        }

        if (bust)
        {
            Console.WriteLine("Bust!");
        }

        // Dealer's turn
        while (dealerHand.GetValue() < 17)
        {
            dealerHand.AddCard(deck.PickCard());
        }

        Console.WriteLine("Dealer's hand:");
        dealerHand.Print();

        if (dealerHand.GetValue() > 21)
        {
            Console.WriteLine("Dealer busts!");
            balance += bet * 2;
        }
        else if (dealerHand.GetValue() > playerHand.GetValue())
        {
            Console.WriteLine("Dealer wins!");
        }
        else if (dealerHand.GetValue() < playerHand.GetValue())
        {
            Console.WriteLine("You win!");
            balance += bet * 2;
        }
        else
        {
            Console.WriteLine("It's a tie!");
            balance += bet;
        }

        if (balance <= 0)
        {
            Console.WriteLine("You're out of money!");
            End();
        }
        else
        {
            Console.WriteLine("Round over.");
            StartRound();
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

    private int MakeBet()
    {
        Console.WriteLine("Enter your bet:");
        string? input = Console.ReadLine();

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

        return bet;
    }
}