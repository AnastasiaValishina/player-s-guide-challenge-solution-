Console.Write("Name your character: ");
string playerName = Console.ReadLine();

IPlayer player1 = CreatePlayer("Select first player: 1 - human, 0 - computer. ");
IPlayer player2 = CreatePlayer("Select second player: 1 - human, 0 - computer. ");
Console.WriteLine();

Party heroes = new Party(player1);
TrueProgrammer trueProgrammer = new TrueProgrammer(playerName);
trueProgrammer.EquipGear(new Sword());
heroes.Characters.Add(trueProgrammer);

heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());
heroes.Items.Add(new HealthPotion());

List<Party> monsterParties = new List<Party> {CreateMonsterParty1(player2), CreateMonsterParty2(player2), CreateMonsterParty3(player2)};

for (int battleNumber = 0; battleNumber < monsterParties.Count; battleNumber++)
{
    Console.WriteLine();
    Console.WriteLine("=============== NEW Battle! ===============");

    Party monsters = monsterParties[battleNumber];
    Battle battle = new Battle(heroes, monsters);
    battle.Run();

    if (heroes.Characters.Count == 0) break;
}

Console.WriteLine("=============== GAME OVER! ===============");
if (heroes.Characters.Count > 0) 
    Console.WriteLine("You have defeated the Uncoded One's forces! You have won the battle!");
else 
    Console.WriteLine("You have been defeated. The Uncoded One has won.");

Party CreateMonsterParty1(IPlayer controllingPlayer)
{
    Party party = new Party(controllingPlayer);
    Skeleton skeleton = new Skeleton();
    skeleton.EquipGear(new Dagger());
    party.Characters.Add(skeleton);
    party.Items.Add(new HealthPotion());
    return party;
}

Party CreateMonsterParty2(IPlayer controllingPlayer)
{
    Party party = new Party(controllingPlayer);
    party.Characters.Add(new Skeleton());
    party.Characters.Add(new Skeleton());
    party.Items.Add(new HealthPotion());
    party.UnequippedGear.Add(new Dagger());
    party.UnequippedGear.Add(new Dagger());
    return party;
}

Party CreateMonsterParty3(IPlayer controllingPlayer)
{
    Party party = new Party(controllingPlayer);
    party.Characters.Add(new TheUncodedOne());
    party.Items.Add(new HealthPotion());
    return party;
}

IPlayer CreatePlayer(string text)
{
    Console.Write(text);
    int input = Convert.ToInt32(Console.ReadLine());
    return input switch
    {
        0 => new ComputerPlayer(),
        1 => new HumanPlayer()
    };
}
