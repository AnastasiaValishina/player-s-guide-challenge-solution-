public class HealthPotion : IItem
{
    public string Name => "HEALTH POTION";

    public void Use(Battle battle, Character user)
    {
        user.HP += 10;
        Console.WriteLine($"{user.Name}'s HP was increased by 10.");
    }
}
