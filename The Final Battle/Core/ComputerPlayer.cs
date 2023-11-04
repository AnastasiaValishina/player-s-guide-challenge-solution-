


using System;

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

        if (character.Gear == null && battle.GetPartyFor(character).UnequippedGear.Count > 0 && random.NextDouble() < 0.5)
            return new EquipGearAction(battle.GetPartyFor(character).UnequippedGear[0]);

        List<Character> potentialTargets = battle.GetEnemyPartyFor(character).Characters;

        if (character.Gear != null)
        {
            return new AttackAction(character.Gear.Attack, potentialTargets[0]);
        }

        if (potentialTargets.Count > 0) 
            return new AttackAction(character.StandardAttack, potentialTargets[0]);

        return new DoNothingAction();
    }
}
