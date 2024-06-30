namespace Fire_Emblem;

public class RemoteSparrow : DamageAlterationSkill
{
    
    private int _counterTimes = 0;
    private Combat _combat;
    private Character _owner;
    private int _atkBonus = 7;
    private int _spdBonus = 7;
    private int _percentageReduction = 30;
    public RemoteSparrow(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (IsBonusApplicable())
        {
            ApplyBonus();
        }
        if (IsDamageAlteration())
        {
            ApplyDamageAlterations();
        }
    }
    
    private void SetAttributes(Battle battle, Character owner)
    {
        _counterTimes++;
        _owner = owner;
        _combat = battle.CurrentCombat;
    }
    
    private bool IsBonusApplicable()
    {
        return _combat._attacker == _owner && _counterTimes % 2 == 1;
    }
    
    private void ApplyBonus()
    {
        _owner.AddTemporaryBonus("Atk", _atkBonus);
        _owner.AddTemporaryBonus("Spd", _spdBonus);
    }
    
    private bool IsDamageAlteration()
    {
        return _combat._attacker == _owner && _counterTimes % 2 == 0;
    }
    
    private void ApplyDamageAlterations()
    {
        _owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", _percentageReduction);;
    }
}