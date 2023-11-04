public interface IItem
{
    string Name { get; }
    void Use(Battle battle, Character user);
}
