public class AttackAction : IAction
{
    private readonly IAttack _attack;
    private readonly Character _target;

    public AttackAction(IAttack attack, Character target)
    {
        _attack = attack;
        _target = target;
    }

    public void Run(Battle battle, Character character)
    {
        Console.WriteLine($"{character.Name} used {_attack.Name} on {_target.Name}.");
        AttackData data = _attack.Create();
        _target.HP -= data.Damage;

        Console.WriteLine($"{_attack.Name} dealt {data.Damage} to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP}.");

        if (!_target.IsAlive())
        {
            battle.GetPartyFor(_target).Characters.Remove(_target);
            Console.WriteLine($"{_target.Name} was defeated!");
        }
    }
}

public record AttackData(int Damage);
