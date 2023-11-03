


public class ComputerPlayer : IPlayer
{
    Random random = new Random();
    public IAction ChooseAction(Battle battle, Character character)
    {
        Thread.Sleep(500);

        bool hasPotion = battle.GetPartyFor(character).Items.Count > 0;
        bool isHPUnderThreshold = character.HP < character.MaxHP / 2;

        if (hasPotion && isHPUnderThreshold && random.NextDouble() < 0.25)
        {
            return new UseItemAction(battle.GetPartyFor(character).Items[0]);
        }

        List<Character> potentialTargets = battle.GetEnemyPartyFor(character).Characters;

        if (potentialTargets.Count > 0) 
            return new AttackAction(character.StandardAttack, potentialTargets[0]);

        return new DoNothingAction();
    }
}
