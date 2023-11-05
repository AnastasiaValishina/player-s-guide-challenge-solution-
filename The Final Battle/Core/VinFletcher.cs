
public class VinFletcher : Character
{
    public VinFletcher() : base(15)  
    {
        Gear = new VinsBow();
    }

    public override string Name => "VIN FLETCHER";

    public override IAttack StandardAttack { get; } = new Punch();
}
