
public class BoneCrunch : IAttack
{
    private static readonly Random _random = new Random();
    public string Name => "BONE CRUNCH";

    public AttackData Create()
    {
        return new AttackData(_random.Next(2));
    }
}