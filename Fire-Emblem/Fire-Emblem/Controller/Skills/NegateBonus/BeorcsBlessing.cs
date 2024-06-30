namespace Fire_Emblem.NegateBonus
{
    public class BeorcsBlessing : Skill
    {

        public BeorcsBlessing(string name, string description) : base(name, description)
        {
        }

        public override void ApplyEffect(Battle battle, Character owner)
        {
            Character opponent = GetOpponent(owner, battle);
            opponent.DisableAllBonuses();
        }

        private Character GetOpponent(Character owner, Battle battle)
        {
            Combat combat = battle.CurrentCombat;
            if (owner == combat._attacker)
            {
                return combat._defender;
            }
            else
            {
                return combat._attacker;
            }
        }
    }
}