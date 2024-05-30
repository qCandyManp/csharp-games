using Xunit;

public class UnitTestBlackjack
{
    /**
     * HandValues
     *
     * This test will check if the values of the cardhands are calculated right.
     */
    [Fact]
    public void HandValues()
    {
        BlackjackHand hand = new([
            new(0, 0) // Ace of Hearts
        ]);

        Assert.Equal(11, hand.GetValue());

        hand.AddCard(new(0, 12)); // King of Hearts

        Assert.Equal(21, hand.GetValue());

        hand.AddCard(new(0, 11)); // Queen of Hearts

        Assert.Equal(21, hand.GetValue());

        hand.RemoveCard(0); // Remove Ace of Hearts

        Assert.Equal(20, hand.GetValue());

        hand.AddCard(new(0, 10)); // Jack of Hearts

        Assert.Equal(30, hand.GetValue());
    }
}