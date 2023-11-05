
public class StoneAmarok : Character
{
    public StoneAmarok() : base(4)
    {
        DefenceModifier = new StoneArmor();
    }

    public override string Name => "STONE AMAROK";

    public override IAttack StandardAttack { get; } = new Bite();
}

public class Bite : IAttack
{
    public string Name => "BITE";

    public AttackData Create()
    {
        return new AttackData(1, 1, Damage.Normal);
    }
}

public class StoneArmor : IAttackModifier
{
    public string Name => "STONE ARMOR";

    public AttackData Modify(AttackData data)
    {
        if (data.Damage == 0) return data;

        Console.WriteLine($"{Name} reduced the attack by 1 point.");
        return data with { Damage = data.Damage - 1 };
    }
}