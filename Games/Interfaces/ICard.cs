public interface ICard
{
    CardColor Color { get; set; }
    int Index { get; set; }
    string Name();
    string Icon();
    string FullName();
    int Value();
}