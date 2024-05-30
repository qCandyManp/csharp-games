public class BlackjackHand(params Card[] cards) : Hand(cards)
{
    public new int GetValue()
    {
        int value = 0;
        int aces = 0;

        foreach (Card card in Cards)
        {
            value += card.Value();

            if (card.Name() == "Ace")
            {
                aces++;
            }
        }

        if (value > 21)
        {
            while (aces > 0 && value > 21)
            {
                value -= 10;
                aces--;
            }
        }

        return value;
    }
}