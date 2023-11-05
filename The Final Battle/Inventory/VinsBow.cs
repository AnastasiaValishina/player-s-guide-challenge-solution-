
public class VinsBow : IGear
{
    public string Name => "VIN'S BOW";

    public IAttack Attack => new QuickShot();
}
