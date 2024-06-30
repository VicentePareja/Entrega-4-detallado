namespace Fire_Emblem;

public class TrueDragonWall : Skill
{
    private Character _opponent;
    private Character _owner;
    private Combat _combat;
    private List<Character> _allies;
    private Player _ownerPlayer;
    private int _damageAfterCombat = -7;

    public TrueDragonWall(string name, string description) : base(name, description)
    {
    }

    public override void ApplyEffect(Battle battle, Character owner)
    {
        SetAttributes(battle, owner);
        if (_owner.Res > _opponent.Res)
        {
            AddFirstAttackDamageAlteration();
            AddFollowUpAttackDamageAlteration();
        }

        if (AllieUseMagic())
        {
            _owner.AddDamageAfterCombat(_damageAfterCombat);
        }
    }

    private void SetAttributes(Battle battle, Character owner)
    {
        _combat = battle.CurrentCombat;
        _owner = owner;
        if (_owner == _combat._attacker)
        {
            _opponent = _combat._defender;
        }
        else
        {
            _opponent = _combat._attacker;
        }

        GetPlayerOwner(battle);
        GetAliveAllies();
    }
    
    private void AddFirstAttackDamageAlteration()
    {
        int resDiference = _owner.Res - _opponent.Res;
        int damageAlteration = Math.Min((int)(resDiference * 6), 60);
        _owner.AddFirstAttackDamageAlteration("PercentageReduction", damageAlteration);
    }
    
    private void AddFollowUpAttackDamageAlteration()
    {
        
        int resDiference = _owner.Res - _opponent.Res;
        int damageAlteration = Math.Min((int)(resDiference * 4), 40);
        _owner.AddFollowUpDamageAlteration("PercentageReduction", damageAlteration);

    }
    
    private bool AllieUseMagic()
    {
        foreach (var allie in _allies)
        {
            if (allie.GetWeaponType() == "Magic")
            {
                return true;
            }
        }
        return false;
    }

    private void GetPlayerOwner(Battle battle)
    {
        List<Player> players = battle.GetPlayers();
        Team Player1Team = players[0].Team;

        if (Player1Team.Characters.Contains(_owner))
        {
            _ownerPlayer = players[0];
        }
        else
        {
            _ownerPlayer = players[1];
        }
    }

    private void GetAliveAllies()
    {
        _allies = new List<Character>();
        foreach (var allie in _ownerPlayer.Team.Characters)
        {
            if (allie != _owner)
            {
                _allies.Add(allie);
            }
        }
    }
    }