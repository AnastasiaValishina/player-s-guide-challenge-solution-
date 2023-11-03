

public class Party
{
    public IPlayer Player { get; }
    public List<Character> Characters { get; } = new List<Character>();

    public List<IItem> Items { get; } = new List<IItem>();

    public Party(IPlayer player)
    {
        Player = player;   
    }
}
