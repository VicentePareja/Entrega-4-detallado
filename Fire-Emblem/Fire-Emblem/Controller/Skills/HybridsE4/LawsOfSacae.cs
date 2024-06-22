namespace Fire_Emblem;

public class LawsOfSacae : Skill
{
    private Character _owner;
    private Character _opponent;
    private Combat _combat;
    
    public LawsOfSacae( string name, string description ) : base( name, description )
    {
        
    }
    
    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (_owner == _combat._attacker)
        {
            GetBonuses();
        }
        if (SecondBonus())
        {
            _opponent.DisableCounterAttack();
        }
        
    }
    
    public void SetAttributes(Battle battle, Character owner)
    {
        _owner = owner;
        _combat = battle.CurrentCombat;
        if (_owner == _combat._attacker)
        {
            _opponent = _combat._defender;
        }
        else
        {
            _opponent = _combat._attacker;
        }
    }

    private void GetBonuses()
    {
        int bonus = 6;
        _owner.AddTemporaryBonus("Atk", bonus);
        _owner.AddTemporaryBonus("Spd", bonus);
        _owner.AddTemporaryBonus("Def", bonus);
        _owner.AddTemporaryBonus("Res", bonus);
    }

    private bool SecondBonus()
    {
        string weapon = _opponent.Weapon;
        bool isWeapon = weapon == "Sword" || weapon == "Lance" || weapon == "Axe";
        bool isFaster = _owner.GetEffectiveAttribute("Spd") >= _opponent.GetEffectiveAttribute("Spd") + 5;
        return isWeapon && isFaster;
    }
}