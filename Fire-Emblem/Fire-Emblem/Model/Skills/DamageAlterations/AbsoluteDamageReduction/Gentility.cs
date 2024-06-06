namespace Fire_Emblem 
{
    public class Gentility : DamageAlterationSkill 
    {

        public Gentility(string name, string description) : base(name, description)
        {
            
        }

        public override void ApplyEffect(Battle battle, Character owner) 
        {
            _counterTimes++;
            if (_counterTimes % 2 == 0)
            {
                double damageReduction = -5.0;
                owner.AddTemporaryDamageAlteration("AbsoluteReduction", damageReduction);
            }
        }
    }
}