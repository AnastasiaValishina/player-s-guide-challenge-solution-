public class AttackAction : IAction
{
    private readonly IAttack _attack;
    private readonly Character _target;
    private readonly Random _random = new Random();

    public AttackAction(IAttack attack, Character target)
    {
        _attack = attack;
        _target = target;
    }

    public void Run(Battle battle, Character character)
    {
        Console.WriteLine($"{character.Name} used {_attack.Name} on {_target.Name}.");
        AttackData data = _attack.Create();

        if (_random.NextDouble() > data.SuccessProbability)
        {
            Console.WriteLine($"{character.Name} missed!");
            return;
        }

        if (_target.DefenceModifier != null)        
            data = _target.DefenceModifier.Modify(data);        

        _target.HP -= data.Damage;

        Console.WriteLine($"{_attack.Name} dealt {data.Damage} to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.HP}/{_target.MaxHP}.");


        if (!_target.IsAlive())
        {
            if (_target.Gear != null)
            {
                battle.GetPartyFor(character).UnequippedGear.Add(_target.Gear);
                Console.WriteLine($"Your party acquired {_target.Gear.Name}"); 
            }
            battle.GetPartyFor(_target).Characters.Remove(_target);
            Console.WriteLine($"{_target.Name} was defeated!");
        }
    }
}
public record AttackData(int Damage, float SuccessProbability);
