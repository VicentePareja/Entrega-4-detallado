// SkillFactory.cs

using System.Net.Http.Headers;
using Fire_Emblem.NegateBonus;

namespace Fire_Emblem {
    public class SkillFactory : ISkillFactory {
        public Skill CreateSkill(string name, string description) {
            switch (name)
            {
                case "HP +15":
                    return new HPIncreaseSkill(name, description);
                case "Fair Fight":
                    return new FairFightSkill(name, description);
                case "Death Blow":
                    return new DeathBlow(name, description);
                case "Armored Blow":
                    return new ArmoredBlow(name, description);
                case "Darting Blow":
                    return new DartingBlow(name, description);
                case "Warding Blow":
                    return new WardingBlow(name, description);
                case "Sturdy Blow":
                    return new SturdyBlow(name, description);
                case "Steady Blow":
                    return new SteadyBlow(name, description);
                case "Bracing Blow":
                    return new BracingBlow(name, description);
                case "Deadly Blade":
                    return new DeadlyBladeSkill(name, description);
                case "Swift Sparrow":
                    return new SwiftSparrowSkill(name, description);
                case "Mirror Strike":
                    return new MirrorStrikeSkill(name, description);
                case "Swift Strike":
                    return new SwiftStrikeSkill(name, description);
                case "Brazen Atk/Spd":
                    return new BrazenAtkSpd(name, description);
                case "Brazen Atk/Def":
                    return new BrazenAtkDef(name, description);
                case "Brazen Atk/Res":
                    return new BrazenAtkRes(name, description);
                case "Brazen Spd/Def":
                    return new BrazenSpdDef(name, description);
                case "Brazen Spd/Res":
                    return new BrazenSpdRes(name, description);
                case "Brazen Def/Res":
                    return new BrazenDefRes(name, description);
                case "Fire Boost":
                    return new FireBoost(name, description);
                case "Wind Boost":
                    return new WindBoost(name, description);
                case "Earth Boost":
                    return new EarthBoost(name, description);
                case "Water Boost":
                    return new WaterBoost(name, description);
                case "Will to Win":
                    return new WillToWin(name, description);
                case "Perceptive":
                    return new Perceptive(name, description);
                case "Single-Minded":
                    return new SingleMinded(name, description);
                case "Tome Precision":
                    return new TomePrecision(name, description);
                case "Attack +6":
                    return new AttackPlusSix(name, description);
                case "Speed +5":
                    return new SpeedPlusFive(name, description);
                case "Defense +5":
                    return new DefensePlusFive(name, description);
                case "Resistance +5":
                    return new ResistancePlusFive(name, description);
                case "Atk/Def +5":
                    return new AtkDefPlusFive(name, description);
                case "Atk/Res +5":
                    return new AtkResPlusFive(name, description);
                case "Spd/Res +5":
                    return new SpdResPlusFive(name, description);
                case "Chaos Style":
                    return new ChaosStyle(name, description);
                case "Resolve":
                    return new Resolve(name, description);
                case "Wrath":
                    return new Wrath(name, description);
                case "Blinding Flash":
                    return new BlindingFlash(name, description);
                case "Not *Quite*":
                    return new NotQuite(name, description);
                case "Stunning Smile":
                    return new StunningSmile(name, description);
                case "Disarming Sigh":
                    return new DisarmingSigh(name, description);
                case "Charmer":
                    return new Charmer(name, description);
                case "Belief in Love":
                    return new BeliefInLove(name, description);
                case "Ignis":
                    return new Ignis(name, description);
                case "Luna":
                    return new Luna(name, description);
                case "Beorc's Blessing":
                    return new BeorcsBlessing(name, description);
                case "Agnea's Arrow":
                    return new AgneasArrow(name, description);
                case "Soulblade":
                    return new Soulblade(name, description);
                case "Sword Agility":
                    return new SwordAgility(name, description);
                case "Lance Power":
                    return new LancePower(name, description);
                case "Sword Power":
                    return new SwordPower(name, description);
                case "Bow Focus":
                    return new BowFocus(name, description);
                case "Lance Agility":
                    return new LanceAgility(name, description);
                case "Axe Power":
                    return new AxePower(name, description);
                case "Bow Agility":
                    return new BowAgility(name, description);
                case "Sword Focus":
                    return new SwordFocus(name, description);
                case "Close Def":
                    return new CloseDef(name, description);
                case "Distant Def":
                    return new DistantDef(name, description);
                case "Lull Atk/Spd":
                    return new LullAtkSpd(name, description);
                case "Lull Atk/Def":
                    return new LullAtkDef(name, description);
                case "Lull Atk/Res":
                    return new LullAtkRes(name, description);
                case "Lull Spd/Def":
                    return new LullSpdDef(name, description);
                case "Lull Spd/Res":
                    return new LullSpdRes(name, description);
                case "Lull Def/Res":
                    return new LullDefRes(name, description);
                case "Fort. Def/Res":
                    return new FortDefRes(name, description);
                case "Life and Death":
                    return new LifeAndDeath(name, description);
                case "Solid Ground":
                    return new SolidGround(name, description);
                case "Still Water":
                    return new StillWater(name, description);
                case "Dragonskin":
                    return new Dragonskin(name, description);
                case "Light and Dark":
                    return new LightAndDark(name, description);
                case "Sandstorm":
                    return new Sandstorm(name, description);
                case "Dragon Wall":
                    return new DragonWall(name, description);
                case "Golden Lotus":
                    return new GoldenLotus(name, description);
                case "Dodge":
                    return new Dodge(name, description);
                case "Gentility":
                    return new Gentility(name, description);
                case "Bow Guard":
                    return new BowGuard(name, description);
                case "Arms Shield":
                    return new ArmsShield(name, description);
                case "Axe Guard":
                    return new AxeGuard(name, description);
                case "Magic Guard":
                    return new MagicGuard(name, description);
                case "Lance Guard":
                    return new LanceGuard(name, description);
                case "Sympathetic":
                    return new Sympathetic(name, description);
                case "Back at You":
                    return new BackAtYou(name, description);
                case "Lunar Brace":
                    return new LunarBrace(name, description);
                case "Bravery":
                    return new Bravery(name, description);
                case "Bushido":
                    return new Bushido(name, description);
                case "Moon-Twin Wing":
                    return new MoonTwinWing(name, description);
                case "Blue Skies":
                    return new BlueSkies(name, description);
                case "Aegis Shield":
                    return new AegisShield(name, description);
                case "Remote Sparrow":
                    return new RemoteSparrow(name, description);
                case "Remote Mirror":
                    return new RemoteMirror(name, description);
                case "Remote Sturdy":
                    return new RemoteSturdy(name, description);
                case "Fierce Stance":
                    return new FierceStance(name, description);
                case "Darting Stance":
                    return new DartingStance(name, description);
                case "Steady Stance":
                    return new SteadyStance(name, description);
                case "Warding Stance":
                    return new WardingStance(name, description);
                case "Kestrel Stance":
                    return new KestrelStance(name, description);
                case "Sturdy Stance":
                    return new SturdyStance(name, description);
                case "Mirror Stance":
                    return new MirrorStance(name, description);
                case "Swift Stance":
                    return new SwiftStance(name, description);
                case "Bracing Stance":
                    return new BracingStance(name, description);
                case "Steady Posture":
                    return new SteadyPosture(name, description);
                case "Poetic Justice":
                    return new PoeticJustice(name, description);
                case "Laguz Friend":
                    return new LaguzFriend(name, description);
                case "Chivalry":
                    return new Chivalry(name, description);
                case "Dragon's Wrath":
                    return new DragonsWrath(name, description);
                case "Prescience":
                    return new Prescience(name, description);
                case "Extra Chivalry":
                    return new ExtraChivalry(name, description);
                case "Guard Bearing":
                    return new GuardBearing(name, description);
                case "Divine Recreation":
                    return new DivineRecreation(name, description);
                case "Windsweep":
                    return new Windsweep(name, description);
                case "Surprise Attack":
                    return new SurpriseAttack(name, description);
                case "Hliðskjálf":
                    return new Hliðskjálf(name, description);
                case "Null C-Disrupt":
                    return new NullCDisrupt(name, description);
                case "Sol":
                    return new Sol(name, description);
                case "Nosferatu":
                    return new Nosferatu(name, description);
                case "Solar Brace":
                    return new SolarBrace(name, description);
                case "Laws of Sacae":
                    return new LawsOfSacae(name, description);
                case "Eclipse Brace":
                    return new EclipseBrace(name, description);
                case "Resonance":
                    return new Resonance(name, description);
                case "Flare":
                    return new Flare(name, description);
                case "Fury":
                    return new Fury(name, description);
                case "Mystic Boost":
                    return new MysticBoost(name, description);
                case "Atk/Spd Push":
                    return new AtkSpdPush(name, description);
                case "Atk/Def Push":
                    return new AtkDefPush(name, description);
                case "Atk/Res Push":
                    return new AtkResPush(name, description);
                case "Spd/Def Push":
                    return new SpdDefPush(name, description);
                case "Spd/Res Push":
                    return new SpdResPush(name, description);
                case "Def/Res Push":
                    return new DefResPush(name, description);
                case "True Dragon Wall":
                    return new TrueDragonWall(name, description);
                case "Scendscale":
                    return new Scendscale(name, description);
                case "Mastermind":
                    return new MasterMind(name, description);
                case "Bewitching Tome":
                    return new BewitchingTome(name, description);
                case "Quick Riposte":
                    return new QuickRiposte(name, description);
                case "Follow-Up Ring":
                    return new FollowUpRing(name, description);
                case "Wary Fighter":
                    return new WaryFighter(name, description);
                case "Piercing Tribute":
                    return new PiercingTribute(name, description);
                case "Mjölnir": 
                    return new Mjölnir(name, description);
                case "Brash Assault":
                    return new BrashAssault(name, description);
                case "Melee Breaker":
                    return new MeleeBreaker(name, description);
                case "Range Breaker":
                    return new RangeBreaker(name, description);
                case "Pegasus Flight":
                    return new PegasusFlight(name, description);
                case "Wyvern Flight":
                    return new WyvernFlight(name, description);
                case "Null Follow-Up":
                    return new NullFollowUp(name, description);
                case "Sturdy Impact":
                    return new SturdyImpact(name, description);
                case "Mirror Impact":
                    return new MirrorImpact(name, description);
                case "Swift Impact":
                    return new SwiftImpact(name, description);
                case "Steady Impact":
                    return new SteadyImpact(name, description);
                case "Slick Fighter":
                    return new SlickFighter(name, description);
                case "Wily Fighter":
                    return new WilyFighter(name, description);
                case "Savvy Fighter":
                    return new SavvyFighter(name, description);
                case "Flow Force":
                    return new FlowForce(name, description);
                case "Flow Refresh":
                    return new FlowRefresh(name, description);
                case "Flow Feather":
                    return new FlowFeather(name, description);
            default:
                    return new GenericSkill(name, description);
            }
        }
    }
}