
public class Skeleton : Character
{
    public override string Name => "SKELETON";

    public override IAttack StandardAttack { get; } = new BoneCrunch();

    public Skeleton() : base(5) { }
}

public class BoneCrunch : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "BONE CRUNCH";

    public AttackData Create()
    {
        return new AttackData(_random.Next(3), 1, Damage.Normal);
    }
}


public class Dagger : IGear
{
    public string Name => "DAGGER";

    public IAttack Attack => new Stab();
}

public class Stab : IAttack
{
    public string Name => "STAB";

    public AttackData Create()
    {
        return new AttackData(1, 1, Damage.Normal);
    }
}
