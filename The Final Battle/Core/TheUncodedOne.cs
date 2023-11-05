public class TheUncodedOne : Character
{
    public override string Name => "THE UNCODED ONE";

    public override IAttack StandardAttack { get; } = new Unraveling();

    public TheUncodedOne() : base(15) { }
}

public class Unraveling : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "UNRAVELING";

    public AttackData Create()
    {
        return new AttackData(_random.Next(5), 1, Damage.Decoding);
    }
}
