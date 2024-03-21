interface ICard
{
    CardColor Color { get; set; }
    string Name { get; set; }
    string Icon();
    string FullName();
    int Value();
}