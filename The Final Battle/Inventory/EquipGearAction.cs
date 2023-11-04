


public class EquipGearAction : IAction
{
    private readonly IGear _gear;

    public EquipGearAction(IGear gear) => _gear = gear;

    public void Run(Battle battle, Character actor)
    {
        if (actor.Gear != null) 
        {
            battle.GetPartyFor(actor).UnequippedGear.Add(actor.Gear);
        }
        actor.EquipGear(_gear);
        battle.GetPartyFor(actor).UnequippedGear.Remove(_gear);

        Console.WriteLine($"{actor.Name} has equipped {_gear.Name}");        
    }
}
