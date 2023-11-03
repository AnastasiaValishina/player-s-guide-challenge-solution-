public class TheUncodedOne : Character
{
    public override string Name => "THE UNCODED ONE";

    public override IAttack StandardAttack { get; } = new Unraveling();

    public TheUncodedOne() : base(15) { }
}
