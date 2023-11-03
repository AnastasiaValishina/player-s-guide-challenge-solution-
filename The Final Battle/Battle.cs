public class Battle
{
    private Party _heroes;
    private Party _monsters;

    public Battle (Party heroes, Party monsters)
    {
        _heroes = heroes;
        _monsters = monsters;
    }

    public void Run()
    {
        while (!IsOver())
        {
            foreach (Party party in new[] { _heroes, _monsters })
            {
                foreach(Character character in party.Characters)
                {
                    ShowBattleInfo();
                    Console.WriteLine($"It is {character.Name}'s turn...");
                    party.Player.ChooseAction(this, character).Run(this, character);
                    
                    if (IsOver()) break;
                }
                if (IsOver()) break;
            }           
        }
    }

    public Party GetEnemyPartyFor(Character character)
    {
        return _heroes.Characters.Contains(character) ? _monsters : _heroes;
    }

    public Party GetPartyFor(Character character)
    {
        return _heroes.Characters.Contains(character) ? _heroes : _monsters;
    }

    private void ShowBattleInfo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine("New Round!");
        foreach (Character hero in _heroes.Characters)
        {
            Console.WriteLine($"{hero.Name} ({hero.HP}/{hero.MaxHP})");
        }
        Console.WriteLine($"-------------------- VS -------------------");

        foreach(Character monster in _monsters.Characters)
        {
            Console.WriteLine($"{monster.Name, 40} ({monster.HP}/{monster.MaxHP})");
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private bool IsOver()
    {
        return _heroes.Characters.Count == 0 || _monsters.Characters.Count == 0;
    }
}
