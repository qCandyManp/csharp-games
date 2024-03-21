class Card : ICard
{
    public static readonly string[] names = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

    public CardColor Color { get; set; }
    public string Name { get; set; }

    public Card(int colorIndex, int nameIndex)
    {
        Color = new CardColor(colorIndex);
        Name = names[nameIndex];
    }

    public string FullName()
    {
        return $"{Name} of {Color}";
    }

    public string Icon()
    {
        return $"{Name[0]}{Color}";
    }

    public int Value()
    {
        int nameIndex = Array.IndexOf(names, Name);

        if (nameIndex == 0)
        {
            return 11;
        }

        if (nameIndex >= 9)
        {
            return 10;
        }

        return nameIndex + 1;
    }
}