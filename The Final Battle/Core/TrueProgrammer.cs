
public class TrueProgrammer : Character
{
    public override string Name { get; }

    public TrueProgrammer(string? playerName) : base(25)
    {
        Name = playerName;
        Gear = new Sword();
    }

    public override IAttack StandardAttack { get; } = new Punch();
}
