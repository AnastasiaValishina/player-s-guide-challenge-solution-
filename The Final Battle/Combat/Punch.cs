
public class Punch : IAttack
{
    public string Name => "PUNCH";

    public AttackData Create()
    {
        return new AttackData(1, 1);
    }
}
