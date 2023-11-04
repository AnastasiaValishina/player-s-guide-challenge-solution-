
public class Dagger : IGear
{
    public string Name => "DAGGER";

    public IAttack Attack => new Stab();
}
