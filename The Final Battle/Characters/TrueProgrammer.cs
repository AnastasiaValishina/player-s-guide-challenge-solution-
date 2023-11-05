
public class TrueProgrammer : Character
{
    public override string Name { get; }

    public TrueProgrammer(string? playerName) : base(25)
    {
        Name = playerName;
        Gear = new Sword();
        DefenceModifier = new ObjectSight();
    }

    public override IAttack StandardAttack { get; } = new Punch();
}

public class ObjectSight : IAttackModifier
{
    public string Name => "OBJECT SIGHT";

    public AttackData Modify(AttackData data)
    {
        if (data.Damage == 0) return data;
        if (data.damageType == Damage.Decoding)
        {    
            Console.WriteLine($"{Name} reduced the attack by 2 point.");
            return data with { Damage = data.Damage - 2 };
        }
        return data;
    }
}
public class Sword : IGear
{
    public string Name => "SWORD";

    public IAttack Attack => new Slash();
}

public class Slash : IAttack
{
    public string Name => "SLASH";

    public AttackData Create()
    {
        return new AttackData(2, 1, Damage.Normal);
    }
}

