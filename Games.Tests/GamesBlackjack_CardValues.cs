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

    [Fact]
    public void IsCardValueCorrect_InputIsAceAnd10_Return21()
    {
        // Arrange
        BlackjackHand hand = new(new(0, 0), new(0, 9));

        // Act
        int actual = hand.GetValue();

        // Assert
        Assert.Equal(21, actual);
    }

    [Fact]
    public void IsCardValueCorrect_InputIsAceAndKing_Return21()
    {
        // Arrange
        BlackjackHand hand = new(new(0, 0), new(0, 12));

        // Act
        int actual = hand.GetValue();

        // Assert
        Assert.Equal(21, actual);
    }

    [Fact]
    public void IsCardValueCorrect_InputIsAceAndQueen_Return21()
    {
        // Arrange
        BlackjackHand hand = new(new(0, 0), new(0, 11));

        // Act
        int actual = hand.GetValue();

        // Assert
        Assert.Equal(21, actual);
    }

    [Fact]
    public void IsCardValueCorrect_InputIsAceAndJack_Return21()
    {
        // Arrange
        BlackjackHand hand = new(new(0, 0), new(0, 10));

        // Act
        int actual = hand.GetValue();

        // Assert
        Assert.Equal(21, actual);
    }

    [Fact]
    public void IsCardValueCorrect_InputIs2AcesAnd8And8_Return18()
    {
        // Arrange
        BlackjackHand hand = new(new(0, 0), new(0, 7), new(0, 7), new(0, 0));

        // Act
        int actual = hand.GetValue();

        // Assert
        Assert.Equal(18, actual);
    }

}