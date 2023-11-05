public class Unraveling : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "UNRAVELING";

    public AttackData Create()
    {
        return new AttackData(_random.Next(3), 1);
    }
}