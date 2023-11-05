
public class VinFletcher : Character
{
    public VinFletcher() : base(15)  
    {
        Gear = new VinsBow();
    }

    public override string Name => "VIN FLETCHER";

    public override IAttack StandardAttack { get; } = new Punch();
}

public class VinsBow : IGear
{
    public string Name => "VIN'S BOW";

    public IAttack Attack => new QuickShot();
}


public class QuickShot : IAttack
{
    public string Name => "QUICK SHOT";

    public AttackData Create()
    {
        return new AttackData(3, 0.5f, Damage.Normal);
    }
}


