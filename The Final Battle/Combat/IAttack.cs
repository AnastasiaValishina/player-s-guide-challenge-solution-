public interface IAttack
{
    string Name { get; }
    AttackData Create();
}

public interface IAttackModifier
{
    string Name { get; }
    AttackData Modify(AttackData data);
}
