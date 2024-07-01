namespace Fire_Emblem {
    public class SingleMinded : Skill {
        private int Bonus { get; set; }

        public SingleMinded(string name, string description) : base(name, description) {
            Bonus = 8;
        }

        public override void ApplyEffect(Battle battle, Character owner) {
            try
            {
                Character lastOpponent = FindLastOpponent(battle, owner);
                Character currentOpponent = GetCurrentOpponent(battle, owner);
                if (currentOpponent == lastOpponent) {
                    owner.AddTemporaryBonus("Atk", Bonus);
                }
            }
            catch (InvalidCombatStateException e)
            {
            }
        }

        private Character FindLastOpponent(Battle battle, Character owner) {
            var relevantCombats = battle.CombatHistory
                .Where(combat => combat.Attacker == owner || combat.Defender == owner);
    
            var opponents = relevantCombats
                .Select(combat => combat.Attacker == owner ? combat.Defender : combat.Attacker)
                .ToList();

            if (!opponents.Any())
                throw new InvalidCombatStateException("No previous opponents found for this character.");

            return opponents.Last();
        }


        private Character GetCurrentOpponent(Battle battle, Character owner) {
            if (battle.CurrentCombat._attacker == owner) {
                return battle.CurrentCombat._defender;
            } else if (battle.CurrentCombat._defender == owner) {
                return battle.CurrentCombat._attacker;
            }
            throw new InvalidCombatStateException("Cannot determine current opponent.");
        }
    }
}