using Xunit;
using Games;

namespace Games.Tests.Blackjack;

public class GamesBlackjack_CardValues
{
    [Fact]
    public void IsCardValueCorrect_InputIs2Aces_Return12()
    {
        // Arrange
        BlackjackHand hand = new(new(0, 0), new(0, 0));

        // Act
        int actual = hand.GetValue();

        // Assert
        Assert.Equal(12, actual);
    }
}