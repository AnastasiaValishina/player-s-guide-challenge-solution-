
public class QuickShot : IAttack
{
    public string Name => "QUICK SHOT";

    public AttackData Create()
    {
        return new AttackData(3, 0.5f);
    }
}
