

public class Skeleton : Character
{
    public override string Name => "SKELETON";

    public override IAttack StandardAttack { get; } = new BoneCrunch();

    public Skeleton() : base(5) { }

}
