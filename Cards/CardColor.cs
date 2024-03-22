class CardColor
{
    public static readonly string[] names = { "Hearts", "Diamonds", "Clubs", "Spades" };
    public static readonly string[] icons = { "♥", "♦", "♣", "♠" };
    public int Color { get; set; }
    public CardColor(int index)
    {
        if (index < 0 || index >= names.Length)
        {
            throw new ArgumentOutOfRangeException("index", "Index must be between 0 and 3");
        }

        Color = index;
    }

    public string Name()
    {
        return names[Color];
    }

    public string Icon()
    {
        return icons[Color];
    }

    public char ShortName()
    {
        return names[Color][0];
    }
}