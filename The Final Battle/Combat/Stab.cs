
public class Stab : IAttack
{
    public string Name => "STAB";

    public AttackData Create()
    {
        return new AttackData(1);
    }
}