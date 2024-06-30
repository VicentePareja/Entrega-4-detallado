namespace Fire_Emblem;

public class RemoteMirror : DamageAlterationSkill
{
    private Combat _combat;
    private Character _owner;
    private Character _opponent;
    private int _atkBonus = 7;
    private int _resBonus = 10;
    private int _percentageReduction = 30;
    public RemoteMirror(string name, string description) : base(name, description)
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
        _opponent = (_combat._attacker == _owner) ? _combat._defender : _combat._attacker;
    }
    
    private bool IsBonusApplicable()
    {
        return _combat._attacker == _owner && _counterTimes % 2 == 1;
    }
    
    private void ApplyBonus()
    {
        _owner.AddTemporaryBonus("Atk", _atkBonus);
        _owner.AddTemporaryBonus("Res", _resBonus);
    }
    
    private bool IsDamageAlteration()
    {
        return _combat._attacker == _owner && _counterTimes % 2 == 0;
    }
    
    private void ApplyDamageAlterations()
    {
        _owner.MultiplyFirstAttackDamageAlterations("PercentageReduction", _percentageReduction);
    }
}