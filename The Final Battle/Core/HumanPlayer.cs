


public class HumanPlayer : IPlayer
{
    public IAction ChooseAction(Battle battle, Character character)
    {
        List<MenuItem> menuItems = CreateMenuItems(battle, character);

        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine($"{i} - {menuItems[i].Description}.");
        }

        Console.WriteLine("What do you want to do?");
        int menuIndex = Convert.ToInt32(Console.ReadLine());

        if (menuItems[menuIndex].Enabled) 
            return menuItems[menuIndex].Action!;

        return new DoNothingAction(); 
    }

    private List<MenuItem> CreateMenuItems(Battle battle, Character character)
    {
        Party currentParty = battle.GetPartyFor(character);
        Party otherParty = battle.GetEnemyPartyFor(character);

        List<MenuItem> menuItems = new List<MenuItem>();

        if (character.Gear != null)
        {
            IGear gear = character.Gear;
            IAttack specialAttack = gear.Attack;
            if (otherParty.Characters.Count > 0)
                menuItems.Add(new MenuItem($"Special Attack ({specialAttack.Name} with {gear.Name})", new AttackAction(specialAttack, otherParty.Characters[0])));
            else
                menuItems.Add(new MenuItem($"Special Attack ({specialAttack.Name} with {gear.Name})", null));
        }

        if (otherParty.Characters.Count > 0)
        {
            menuItems.Add(new MenuItem($"Standard Attack ({character.StandardAttack.Name})", new AttackAction(character.StandardAttack, otherParty.Characters[0]))); 
        }
        else
        {
            menuItems.Add(new MenuItem($"Standard Attack ({character.StandardAttack.Name})", null));
        }

        if (currentParty.Items.Count > 0)
        {
            menuItems.Add(new MenuItem("Use Health Potion", new UseItemAction(currentParty.Items[0])));
        }

        foreach (var gear in currentParty.UnequippedGear) 
        {
            menuItems.Add(new MenuItem($"Equip gear {gear.Name}", new EquipGearAction(gear)));
        }

        menuItems.Add(new MenuItem("Do Nothing", new DoNothingAction()));

        return menuItems;
    }
}

public record MenuItem(string Description, IAction? Action)
{
    public bool Enabled => Action != null;
}