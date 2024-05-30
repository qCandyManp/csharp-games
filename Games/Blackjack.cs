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
        Console.Clear();
        Console.WriteLine("Starting Round...");

        // Make initial bet
        int bet = MakeBet();
        Console.Clear();

        CardDeck deck = new();

        // Deal cards
        Hand playerHand = new(deck.PickCard());
        Hand dealerHand = new(deck.PickCard());

        playerHand.AddCard(deck.PickCard());
        dealerHand.AddCard(deck.PickCard());

        PrintHands(playerHand, dealerHand);

        bool blackjack = IsBlackjack(playerHand);
        bool bust = IsBust(playerHand);
        bool stand = false;

        while (!blackjack && !bust && !stand)
        {
            Console.WriteLine("Hit (y) or Stand (n)?");
            string? input = Console.ReadLine();

            if (input == "y")
            {
                playerHand.AddCard(deck.PickCard());

                Console.Clear();
                PrintHands(playerHand, dealerHand);

                blackjack = IsBlackjack(playerHand);
                bust = IsBust(playerHand);
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

        Console.Clear();

        if (blackjack)
        {
            Console.WriteLine("Blackjack!");
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

        PrintHands(playerHand, dealerHand);

        if (IsBust(dealerHand))
        {
            Console.WriteLine("Dealer busts!");
            Console.WriteLine("You win!");
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
            Console.WriteLine("Next Round? (y/n)");
            string? input = Console.ReadLine();

            if (input == "y")
            {
                StartRound();
            }
            else
            {
                End();
            }
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
        PrintBalance();
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

    private static bool IsBlackjack(Hand hand)
    {
        return hand.GetValue() == 21;
    }

    private static bool IsBust(Hand hand)
    {
        return hand.GetValue() > 21;
    }

    private static void PrintHands(Hand playerHand, Hand dealerHand)
    {
        Console.WriteLine("Dealer's hand:");
        dealerHand.Print();

        Console.WriteLine("-----------------");

        Console.WriteLine("Your hand:");
        playerHand.Print();

    }
}