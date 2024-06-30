namespace Fire_Emblem 
{
    public class Gentility : DamageAlterationSkill 
    {
        private double _damageReduction = -5.0;
        public Gentility(string name, string description) : base(name, description)
        {
            
        }

        public override void ApplyEffect(Battle battle, Character owner) 
        {
            _counterTimes++;
            if (_counterTimes % 2 == 0)
            {
                owner.AddTemporaryDamageAlteration("AbsoluteReduction", _damageReduction);
            }
        }
    }
}