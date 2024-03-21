class CardColor
{
    public static readonly string[] colors = { "Hearts", "Diamonds", "Clubs", "Spades" };
    public string Color { get; }
    public CardColor(int index)
    {
        if (index < 0 || index >= colors.Length)
        {
            throw new ArgumentOutOfRangeException("index", "Index must be between 0 and 3");
        }

        Color = colors[index];
    }

    public string FullName()
    {
        return Color;
    }

    public string Icon()
    {
        return Color;
    }

    public char ShortName()
    {
        return Color[0];
    }
}