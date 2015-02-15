using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Internals.Actors;

namespace AutoSkilled {
    public abstract class Skill {
        private Dictionary<string, SNOPower> skillDict;
        private Dictionary<string, int> runeDict;

        private SNOPower power;
        private int runeId;

        public Skill() {
            skillDict = new Dictionary<string, SNOPower>();
            runeDict = new Dictionary<string, int>();
            runeDict.Add("None", -1);

            // Barbarian Primary
            skillDict.Add("Bash", SNOPower.Barbarian_Bash);
            runeDict.Add("Clobber", 2);
            runeDict.Add("Onslaught", 0);
            runeDict.Add("Punish", 1);
            runeDict.Add("Instigation", 3);
            runeDict.Add("Pulverize", 4);

            skillDict.Add("Cleave", SNOPower.Barbarian_Cleave);
            runeDict.Add("Rupture", 4);
            runeDict.Add("ReapingSwing", 3);
            runeDict.Add("ScatteringBlast", 2);
            runeDict.Add("BroadSweep", 0);
            runeDict.Add("GatheringStorm", 1);

            skillDict.Add("Frenzy", SNOPower.Barbarian_Frenzy);
            runeDict.Add("Sidearm", 1);
            runeDict.Add("Triumph", 4);
            runeDict.Add("Vanguard", 2);
            runeDict.Add("Smite", 3);
            runeDict.Add("Maniac", 0);

            // Barbarian - Secondary
            skillDict.Add("HammerOfTheAncients", SNOPower.Barbarian_HammerOfTheAncients);
            runeDict.Add("RollingThunder", 1);
            runeDict.Add("Smash", 0);
            runeDict.Add("TheDevilsAnvil", 2);
            runeDict.Add("Thunderstrike", 4);
            runeDict.Add("Birthright", 3);

            skillDict.Add("Rend", SNOPower.Barbarian_Rend);
            runeDict.Add("Ravage", 1);
            runeDict.Add("BloodLust", 3);
            runeDict.Add("Lacerate", 0);
            runeDict.Add("Mutilate", 2);
            runeDict.Add("Bloodbath", 4);

            skillDict.Add("SeismicSlam", SNOPower.Barbarian_SeismicSlam);
            runeDict.Add("Stagger", 2);
            runeDict.Add("ShatteredGround", 0);
            runeDict.Add("Rumble", 1);
            runeDict.Add("StrengthFromEarth", 3);
            runeDict.Add("CrackingRift", 4);

            skillDict.Add("Whirlwind", SNOPower.Barbarian_Whirlwind);
            runeDict.Add("DustDevils", 1);
            runeDict.Add("Hurricane", 2);
            runeDict.Add("BloodFunnel", 4);
            runeDict.Add("WindShear", 3);
            runeDict.Add("VolcanicEruption", 0);

            // Barbarian - Defensive
            skillDict.Add("GroundStomp", SNOPower.Barbarian_GroundStomp);
            runeDict.Add("DeafeningCrash", 4);
            runeDict.Add("WrenchingSmash", 1);
            runeDict.Add("TremblingStomp", 0);
            runeDict.Add("FootOfTheMountain", 3);
            runeDict.Add("Avalanche", 2);

            skillDict.Add("Leap", SNOPower.Barbarian_Leap);
            runeDict.Add("IronImpact", 3);
            runeDict.Add("Launch", 2);
            runeDict.Add("TopplingImpact", 1);
            runeDict.Add("CallOfArreat", 0);
            runeDict.Add("BeathFromAbove", 4);

            skillDict.Add("Sprint", SNOPower.Barbarian_Sprint);
            runeDict.Add("Rush", 1);
            runeDict.Add("RunLikeTheWind", 2);
            runeDict.Add("Marathon", 0);
            runeDict.Add("Gangway", 4);
            runeDict.Add("ForcedMarch", 3);

            skillDict.Add("IgnorePain", SNOPower.Barbarian_IgnorePain);
            runeDict.Add("Bravado", 3);
            runeDict.Add("IronHide", 1);
            runeDict.Add("IgnoranceIsBliss", 4);
            runeDict.Add("MobRule", 2);
            runeDict.Add("ContemptForWeakness", 0);

            // Barbarian - Might
            skillDict.Add("AncientSpear", SNOPower.Barbarian_AncientSpear);
            runeDict.Add("GrapplingHooks", 1);
            runeDict.Add("Skirmish", 3);
            runeDict.Add("DreadSpear", 2);
            runeDict.Add("Harpoon", 0);
            runeDict.Add("RageFlip", 4);

            skillDict.Add("Revenge", SNOPower.Barbarian_Revenge);
            runeDict.Add("VengeanceIsMine", 3);
            runeDict.Add("BestServedCold", 4);
            runeDict.Add("Retribution", 0);
            runeDict.Add("Grudge", 2);
            runeDict.Add("Provocation", 1);

            skillDict.Add("FuriousCharge", SNOPower.Barbarian_FuriousCharge);
            runeDict.Add("BatteringRam", 0);
            runeDict.Add("MercilessAssault", 4);
            runeDict.Add("Stamina", 3);
            runeDict.Add("BullRush", 2);
            runeDict.Add("Dreadnought", 1);

            skillDict.Add("Overpower", SNOPower.Barbarian_Overpower);
            runeDict.Add("StormOfSteel", 1);
            runeDict.Add("KillingSpree", 0);
            runeDict.Add("CrushingAdvance", 4);
            runeDict.Add("Momentum", 3);
            runeDict.Add("Revel", 2);

            // Barbarian - Tactics
            skillDict.Add("WeaponThrow", SNOPower.Barbarian_WeaponThrow);
            runeDict.Add("MightyThrow", 0);
            runeDict.Add("Ricochet", 1);
            runeDict.Add("ThrowingHammer", 2);
            runeDict.Add("Stupefy", 4);
            runeDict.Add("DreadBomb", 3);

            skillDict.Add("ThreateningShout", SNOPower.Barbarian_ThreateningShout);
            runeDict.Add("Intimidate", 1);
            runeDict.Add("Falter", 3);
            runeDict.Add("GrimHarvest", 2);
            runeDict.Add("Demoralize", 0);
            runeDict.Add("Terrify", 4);

            skillDict.Add("BattleRage", SNOPower.Barbarian_BattleRage);
            runeDict.Add("MaraudersRage", 0);
            runeDict.Add("Ferocity", 1);
            runeDict.Add("SwordsToPloughshares", 2);
            runeDict.Add("IntoTheFray", 3);
            runeDict.Add("Bloodshed", 4);

            skillDict.Add("WarCry", SNOPower.Barbarian_WarCry);
            runeDict.Add("HardenedWrath", 0);
            runeDict.Add("Charge", 3);
            runeDict.Add("Invigorate", 4);
            runeDict.Add("VeteransWarning", 1);
            runeDict.Add("Impunity", 2);

            // Barbarian - Rage
            skillDict.Add("Earthquake", SNOPower.Barbarian_Earthquake);
            runeDict.Add("GiantsStride", 1);
            runeDict.Add("ChillingEarth", 2);
            runeDict.Add("TheMountainsCall", 3);
            runeDict.Add("Aftershocks", 0);
            runeDict.Add("PathOfFire", 4);

            skillDict.Add("CallOfTheAncients", SNOPower.Barbarian_CallOfTheAncients);
            runeDict.Add("TheCouncilRises", 1);
            runeDict.Add("DutyToTheClan", 3);
            runeDict.Add("KorlicsMight", 0);
            runeDict.Add("MadawcsMadness", 2);
            runeDict.Add("TalicsAnger", 4);

            skillDict.Add("WrathOfTheBerserker", SNOPower.Barbarian_WrathOfTheBerserker);
            runeDict.Add("ArreatsWail", 1);
            runeDict.Add("Insanity", 0);
            runeDict.Add("Slaughter", 4);
            runeDict.Add("StridingGiant", 2);
            runeDict.Add("ThriveOnChaos", 3);

            // Barbarian - Passives
            skillDict.Add("PoundOfFlesh", SNOPower.Barbarian_Passive_PoundOfFlesh);
            skillDict.Add("Ruthless", SNOPower.Barbarian_Passive_Ruthless);
            skillDict.Add("NervesOfSteel", SNOPower.Barbarian_Passive_NervesOfSteel);
            skillDict.Add("WeaponsMaster", SNOPower.Barbarian_Passive_WeaponsMaster);
            skillDict.Add("InspiringPresence", SNOPower.Barbarian_Passive_InspiringPresence);
            skillDict.Add("BerserkerRage", SNOPower.Barbarian_Passive_BerserkerRage);
            skillDict.Add("Bloodthirst", SNOPower.Barbarian_Passive_Bloodthirst);
            skillDict.Add("Animosity", SNOPower.Barbarian_Passive_Animosity);
            skillDict.Add("Superstition", SNOPower.Barbarian_Passive_Superstition);
            skillDict.Add("ToughAsNails", SNOPower.Barbarian_Passive_ToughAsNails);
            skillDict.Add("NoEscape", SNOPower.Barbarian_Passive_NoEscape);
            skillDict.Add("Relentless", SNOPower.Barbarian_Passive_Relentless);
            skillDict.Add("Brawler", SNOPower.Barbarian_Passive_Brawler);
            skillDict.Add("Juggernaut", SNOPower.Barbarian_Passive_Juggernaut);
            skillDict.Add("Unforgiving", SNOPower.Barbarian_Passive_Unforgiving);
            skillDict.Add("BoonOfBulKathos", SNOPower.Barbarian_Passive_BoonOfBulKathos);

            // Monk - Primary
            skillDict.Add("FistsOfThunder", SNOPower.Monk_FistsofThunder);
            runeDict.Add("Thunderclap", 0);
            runeDict.Add("LightningFlash", 4);
            runeDict.Add("StaticCharge", 2);
            runeDict.Add("Quickening", 3);
            runeDict.Add("BoundingLight", 1);

            skillDict.Add("DeadlyReach", SNOPower.Monk_DeadlyReach);
            runeDict.Add("PiercingTrident", 1);
            runeDict.Add("KeenEye", 4);
            runeDict.Add("ScatteredBlows", 2);
            runeDict.Add("StrikeFromBeyond", 3);
            runeDict.Add("Foresight", 0);

            skillDict.Add("CripplingWave", SNOPower.Monk_CripplingWave);
            runeDict.Add("Mangle", 0);
            runeDict.Add("Concussion", 2);
            runeDict.Add("RisingTide", 3);
            runeDict.Add("Tsunami", 1);
            runeDict.Add("BreakingWave", 4);

            skillDict.Add("WayOfTheHundredFists", SNOPower.Monk_WayOfTheHundredFists);
            runeDict.Add("HandsOfLightning", 1);
            runeDict.Add("BlazingFists", 2);
            runeDict.Add("FistsOfFury", 0);
            runeDict.Add("SpiritedSalvo", 3);
            runeDict.Add("WindforceFlurry", 4);

            // Monk - Secondary
            skillDict.Add("LashingTailKick", SNOPower.Monk_LashingTailKick);
            runeDict.Add("VultureClawKick", 0);
            runeDict.Add("SweepingArmada", 3);
            runeDict.Add("SpinningFlameKick", 1);
            runeDict.Add("ScorpionSting", 4);
            runeDict.Add("HandOfYtar", 2);

            skillDict.Add("TempestRush", SNOPower.Monk_TempestRush);
            runeDict.Add("NorthernBreeze", 3);
            runeDict.Add("Tailwind", 1);
            runeDict.Add("Flurry", 4);
            runeDict.Add("Slipstream", 2);
            runeDict.Add("Bluster", 0);

            skillDict.Add("WaveOfLight", SNOPower.Monk_WaveOfLight);
            runeDict.Add("WallOfLight", 0);
            runeDict.Add("ExplosiveLight", 1);
            runeDict.Add("EmpoweredWave", 3);
            runeDict.Add("BlindingLight", 4);
            runeDict.Add("PillarOfTheAncients", 2);

            // Monk - Defensive
            skillDict.Add("BlindingFlash", SNOPower.Monk_BlindingFlash);
            runeDict.Add("SelfReflection", 3);
            runeDict.Add("BlindedAndConfused", 2);
            runeDict.Add("BlindingEcho", 1);
            runeDict.Add("SearingLight", 4);
            runeDict.Add("FaithInTheLight", 0);

            skillDict.Add("BreathOfHeaven", SNOPower.Monk_BreathOfHeaven);
            runeDict.Add("CircleOfScorn", 0);
            runeDict.Add("CircleOfLife", 1);
            runeDict.Add("BlazingWrath", 2);
            runeDict.Add("InfusedWithLight", 3);
            runeDict.Add("PenitentFlame", 4);

            skillDict.Add("Serenity", SNOPower.Monk_Serenity);
            runeDict.Add("PeacefulRepose", 0);
            runeDict.Add("ReapWhatIsSown", 4);
            runeDict.Add("Tranquility", 3);
            runeDict.Add("Ascension", 2);
            runeDict.Add("InstantKarma", 1);

            skillDict.Add("InnerSanctuary", SNOPower.Monk_InnerSanctuary);
            runeDict.Add("SafeHaven", 3);
            runeDict.Add("SanctifiedGround", 4);
            runeDict.Add("Consecration", 1);
            runeDict.Add("CircleOfProtection", 2);
            runeDict.Add("ForbiddenPalace", 0);

            // Monk - Techniques
            skillDict.Add("DashingStrike", SNOPower.Monk_DashingStrike);
            runeDict.Add("WayOfTheFallingStar", 1);
            runeDict.Add("FlyingSideKick", 4);
            runeDict.Add("Quicksilver", 3);
            runeDict.Add("SoaringSkull", 0);
            runeDict.Add("BlindingSpeed", 2);

            skillDict.Add("ExplodingPalm", SNOPower.Monk_ExplodingPalm);
            runeDict.Add("TheFleshIsWeak", 2);
            runeDict.Add("StrongSpirit", 3);
            runeDict.Add("CreepingDemise", 1);
            runeDict.Add("ImpendingDoom", 0);
            runeDict.Add("EssenceBurn", 4);

            skillDict.Add("SweepingWind", SNOPower.Monk_SweepingWind);
            runeDict.Add("MasterOfWind", 4);
            runeDict.Add("BladeStorm", 0);
            runeDict.Add("FireStorm", 1);
            runeDict.Add("InnerStorm", 3);
            runeDict.Add("Cyclone", 2);

            // Monk - Focus
            skillDict.Add("CycloneStrike", SNOPower.Monk_CycloneStrike);
            runeDict.Add("EyeOfTheStorm", 3);
            runeDict.Add("Implosion", 1);
            runeDict.Add("Sunburst", 0);
            runeDict.Add("WallOfWind", 4);
            runeDict.Add("SoothingBreeze", 2);

            skillDict.Add("SevenSidedStrike", SNOPower.Monk_SevenSidedStrike);
            runeDict.Add("SuddenAssault", 0);
            runeDict.Add("SeveralSidedStrike", 1);
            runeDict.Add("Pandemonium", 2);
            runeDict.Add("SustainedAttack", 3);
            runeDict.Add("FulinatingOnslaught", 4);

            skillDict.Add("MysticAlly", SNOPower.Monk_MysticAlly);
            runeDict.Add("WaterAlly", 1);
            runeDict.Add("FireAlly", 0);
            runeDict.Add("AirAlly", 3);
            runeDict.Add("EternalAlly", 4);
            runeDict.Add("EarthAlly", 2);

            // Monk - Mantras
            skillDict.Add("MantraOfEvasion", SNOPower.Monk_MantraOfEvasion);
            runeDict.Add("HardTarget", 2);
            runeDict.Add("DivineProtection", 4);
            runeDict.Add("WindThroughTheReeds", 3);
            runeDict.Add("Perserverance", 1);
            runeDict.Add("Backlash", 0);

            skillDict.Add("MantraOfRetribution", SNOPower.Monk_MantraOfRetribution);
            runeDict.Add("Retaliation", 0);
            runeDict.Add("Transgression", 1);
            runeDict.Add("Indignation", 2);
            runeDict.Add("AgainstAllOdds", 3);
            runeDict.Add("CollateralDamage", 4);

            skillDict.Add("MantraOfHealing", SNOPower.Monk_MantraOfHealing);
            runeDict.Add("Sustenance", 0);
            runeDict.Add("CircularBreathing", 3);
            runeDict.Add("BoonOfInspiration", 1);
            runeDict.Add("HeavenlyBody", 2);
            runeDict.Add("TimeOfNeed", 4);

            skillDict.Add("MantraOfConviction", SNOPower.Monk_MantraOfConviction);
            runeDict.Add("Overawe", 0);
            runeDict.Add("Intimidation", 4);
            runeDict.Add("Dishearten", 2);
            runeDict.Add("Reclamation", 3);
            runeDict.Add("Submission", 1);

            // Monk - Passives
            skillDict.Add("Resolve", SNOPower.Monk_Passive_Resolve);
            skillDict.Add("FleetFooted", SNOPower.Monk_Passive_FleetFooted);
            skillDict.Add("ExaltedSoul", SNOPower.Monk_Passive_ExaltedSoul);
            skillDict.Add("Transcendence", SNOPower.Monk_Passive_Transcendence);
            skillDict.Add("ChantOfResonance", SNOPower.Monk_Passive_ChantOfResonance);
            skillDict.Add("SeizeTheInitiative", SNOPower.Monk_Passive_SeizeTheInitiative);
            skillDict.Add("TheGuardiansPath", SNOPower.Monk_Passive_TheGuardiansPath);
            skillDict.Add("SixthSense", SNOPower.Monk_Passive_SixthSense);
            skillDict.Add("Pacifism", SNOPower.Monk_Passive_Pacifism);
            skillDict.Add("BeaconOfYtar", SNOPower.Monk_Passive_BeaconOfYtar);
            skillDict.Add("GuidingLight", SNOPower.Monk_Passive_GuidingLight);
            skillDict.Add("OneWithEverything", SNOPower.Monk_Passive_OneWithEverything);
            skillDict.Add("CombinationStrike", SNOPower.Monk_Passive_CombinationStrike);
            skillDict.Add("NearDeathExperience", SNOPower.Monk_Passive_NearDeathExperience);

            // Demon Hunter - Primary
            skillDict.Add("HungeringArrow", SNOPower.DemonHunter_HungeringArrow);
            runeDict.Add("PuncturingArrow", 3);
            runeDict.Add("CinderArrow", 0);
            runeDict.Add("ShatterShot", 1);
            runeDict.Add("DevouringArrow", 2);
            runeDict.Add("SprayOfTeeth", 4);

            skillDict.Add("EntanglingShot", SNOPower.DemonHunter_EntanglingShot);
            runeDict.Add("ChainGang", 1);
            runeDict.Add("ShockCollar", 2);
            runeDict.Add("HeavyBurden", 0);
            runeDict.Add("JusticeIsServed", 3);
            runeDict.Add("BountyHunter", 4);

            skillDict.Add("BolaShot", SNOPower.DemonHunter_BolaShot);
            runeDict.Add("VolatileExplosives", 0);
            runeDict.Add("ThunderBall", 2);
            runeDict.Add("AcidStrike", 1);
            runeDict.Add("BitterPill", 3);
            runeDict.Add("ImminentDoom", 4);

            skillDict.Add("Grenades", SNOPower.DemonHunter_Grenades);
            runeDict.Add("Tinkerer", 3);
            runeDict.Add("ClusterGrenades", 1);
            runeDict.Add("FireBomb", 2);
            runeDict.Add("StunGrenades", 4);
            runeDict.Add("GasGrenades", 0);

            // Demon Hunter - Secondary
            skillDict.Add("Impale", SNOPower.DemonHunter_Impale);
            runeDict.Add("Impact", 1);
            runeDict.Add("ChemicalBurn", 2);
            runeDict.Add("Overpenetration", 0);
            runeDict.Add("Awareness", 3);
            runeDict.Add("GrievousWounds", 4);

            skillDict.Add("RapidFire", SNOPower.DemonHunter_RapidFire);
            runeDict.Add("WitheringFire", 3);
            runeDict.Add("WebShot", 4);
            runeDict.Add("FireSupport", 2);
            runeDict.Add("HighVelocity", 1);
            runeDict.Add("Bombardment", 0);

            skillDict.Add("Chakram", SNOPower.DemonHunter_Chakram);
            runeDict.Add("TwinChakrams", 0);
            runeDict.Add("Serpentine", 2);
            runeDict.Add("RazorDisk", 3);
            runeDict.Add("Boomerang", 1);
            runeDict.Add("ShurikenCloud", 4);

            skillDict.Add("ElementalArrow", SNOPower.DemonHunter_ElementalArrow);
            runeDict.Add("BallLightning", 1);
            runeDict.Add("FrostArrow", 0);
            runeDict.Add("ScreamingSkull", 2);
            runeDict.Add("LightningBolts", 4);
            runeDict.Add("NetherTentacles", 3);

            // Demon Hunter - Defensive
            skillDict.Add("Caltrops", SNOPower.DemonHunter_Caltrops);
            runeDict.Add("HookedSpines", 1);
            runeDict.Add("TorturousGround", 2);
            runeDict.Add("JaggedSpikes", 0);
            runeDict.Add("CarvedStakes", 3);
            runeDict.Add("BaitTheTrap", 4);

            skillDict.Add("SmokeScreen", SNOPower.DemonHunter_SmokeScreen);
            runeDict.Add("Displacement", 4);
            runeDict.Add("LingeringFog", 1);
            runeDict.Add("BreatheDeep", 2);
            runeDict.Add("SpecialRecipe", 3);
            runeDict.Add("ChokingGas", 0);

            skillDict.Add("ShadowPower", SNOPower.DemonHunter_ShadowPower);
            runeDict.Add("NightBane", 0);
            runeDict.Add("BloodMoon", 4);
            runeDict.Add("WellOfDarkness", 3);
            runeDict.Add("Gloom", 2);
            runeDict.Add("ShadowGuide", 1);

            // Demon Hunter - Hunting
            skillDict.Add("Vault", SNOPower.DemonHunter_Vault);
            runeDict.Add("ActionShot", 2);
            runeDict.Add("RattlingRoll", 4);
            runeDict.Add("Tumble", 3);
            runeDict.Add("Acrobatics", 1);
            runeDict.Add("TrailOfCinders", 0);

            skillDict.Add("Preparation", SNOPower.DemonHunter_Preparation);
            runeDict.Add("Invigoration", 1);
            runeDict.Add("Punishment", 0);
            runeDict.Add("BattleScars", 3);
            runeDict.Add("FocusedMind", 2);
            runeDict.Add("BackupPlan", 4);

            skillDict.Add("Companion", SNOPower.DemonHunter_Companion);
            runeDict.Add("SpiderCompanion", 0);
            runeDict.Add("BatCompanion", 3);
            runeDict.Add("BoarCompanion", 1);
            runeDict.Add("FerretCompanion", 4);
            runeDict.Add("WolfCompanion", 2);

            skillDict.Add("MarkedForDeath", SNOPower.DemonHunter_MarkedForDeath);
            runeDict.Add("Contagion", 1);
            runeDict.Add("ValleyOfDeath", 2);
            runeDict.Add("GrimReaper", 0);
            runeDict.Add("MortalEnemy", 3);
            runeDict.Add("DeathToll", 4);

            // Demon Hunter - Devices
            skillDict.Add("EvasiveFire", SNOPower.DemonHunter_EvasiveFire);
            runeDict.Add("Hardened", 0);
            runeDict.Add("PartingGift", 2);
            runeDict.Add("CoveringFire", 1);
            runeDict.Add("Displace", 4);
            runeDict.Add("Surge", 3);

            skillDict.Add("FanOfKnives", SNOPower.DemonHunter_FanOfKnives);
            runeDict.Add("CripplingRazors", 3);
            runeDict.Add("Retaliate", 4);
            runeDict.Add("HailOfKnives", 0);
            runeDict.Add("FanOfDaggers", 2);
            runeDict.Add("AssassinsKnives", 1);

            skillDict.Add("SpikeTrap", SNOPower.DemonHunter_SpikeTrap);
            runeDict.Add("EchoingBlast", 1);
            runeDict.Add("StickyTrap", 2);
            runeDict.Add("LongFuse", 0);
            runeDict.Add("LightningRod", 4);
            runeDict.Add("Scatter", 3);

            skillDict.Add("Sentry", SNOPower.DemonHunter_Sentry);
            runeDict.Add("SpitfireTurret", 2);
            runeDict.Add("VigilantWatcher", 1);
            runeDict.Add("ChainOfTorment", 0);
            runeDict.Add("AidStation", 3);
            runeDict.Add("GuardianTurret", 4);

            // Demon Hunter - Archery
            skillDict.Add("Strafe", SNOPower.DemonHunter_Strafe);
            runeDict.Add("Emberstrafe", 1);
            runeDict.Add("DriftingShadow", 3);
            runeDict.Add("StingingSteel", 4);
            runeDict.Add("RocketStorm", 2);
            runeDict.Add("Demolition", 0);

            skillDict.Add("Multishot", SNOPower.DemonHunter_Multishot);
            runeDict.Add("FireAtWill", 3);
            runeDict.Add("BurstFire", 1);
            runeDict.Add("SuppressionFire", 4);
            runeDict.Add("FullBroadside", 0);
            runeDict.Add("Arsenal", 2);

            skillDict.Add("ClusterArrow", SNOPower.DemonHunter_ClusterArrow);
            runeDict.Add("DazzlingArrow", 4);
            runeDict.Add("ShootingStars", 1);
            runeDict.Add("Maelstrom", 3);
            runeDict.Add("ClusterBombs", 2);
            runeDict.Add("LoadedForBear", 0);

            skillDict.Add("RainOfVengeance", SNOPower.DemonHunter_RainOfVengeance);
            runeDict.Add("DarkCloud", 1);
            runeDict.Add("BeastlyBombs", 0);
            runeDict.Add("Stampede", 4);
            runeDict.Add("Anathema", 2);
            runeDict.Add("FlyingStrike", 3);

            // Demon Hunter - Passives
            skillDict.Add("ThrillOfTheHunt", SNOPower.DemonHunter_Passive_ThrillOfTheHunt);
            skillDict.Add("TacticalAdvantage", SNOPower.DemonHunter_Passive_TacticalAdvantage);
            skillDict.Add("Vengeance", SNOPower.DemonHunter_Passive_Vengeance);
            skillDict.Add("SteadyAim", SNOPower.DemonHunter_Passive_SteadyAim);
            skillDict.Add("CullTheWeak", SNOPower.DemonHunter_Passive_CullTheWeak);
            skillDict.Add("NightStalker", SNOPower.DemonHunter_Passive_NightStalker);
            skillDict.Add("Brooding", SNOPower.DemonHunter_Passive_Brooding);
            skillDict.Add("HotPursuit", SNOPower.DemonHunter_Passive_HotPursuit);
            skillDict.Add("Archery", SNOPower.DemonHunter_Passive_Archery);
            skillDict.Add("NumbingTraps", SNOPower.DemonHunter_Passive_NumbingTraps);
            skillDict.Add("Perfectionist", SNOPower.DemonHunter_Passive_Perfectionist);
            skillDict.Add("CustomEngineering", SNOPower.DemonHunter_Passive_CustomEngineering);
            skillDict.Add("Grenadier", SNOPower.DemonHunter_Passive_Grenadier);
            skillDict.Add("Sharpshooter", SNOPower.DemonHunter_Passive_Sharpshooter);
            skillDict.Add("Ballistics", SNOPower.DemonHunter_Passive_Ballistics);

            // Witch Doctor - Primary
            skillDict.Add("PoisonDart", SNOPower.Witchdoctor_PoisonDart);
            runeDict.Add("Splinters", 1);
            runeDict.Add("NumbingDart", 2);
            runeDict.Add("SpinedDart", 3);
            runeDict.Add("FlamingDart", 0);
            runeDict.Add("SnakeToTheFace", 4);

            skillDict.Add("CorpseSpiders", SNOPower.Witchdoctor_CorpseSpider);
            runeDict.Add("LeapingSpiders", 2);
            runeDict.Add("SpiderQueen", 1);
            runeDict.Add("Widowmakers", 3);
            runeDict.Add("MedusaSpiders", 4);
            runeDict.Add("BlazingSpiders", 0);

            skillDict.Add("PlagueOfToads", SNOPower.Witchdoctor_PlagueOfToads);
            runeDict.Add("ExplosiveToads", 0);
            runeDict.Add("ToadOfHugeness", 2);
            runeDict.Add("RainOfToads", 1);
            runeDict.Add("AddlingToads", 4);
            runeDict.Add("ToadAffinity", 3);

            skillDict.Add("Firebomb", SNOPower.Witchdoctor_Firebomb);
            runeDict.Add("FlashFire", 4);
            runeDict.Add("RollTheBones", 1);
            runeDict.Add("FirePit", 2);
            runeDict.Add("Pyrogeist", 3);
            runeDict.Add("GhostBomb", 0);

            // Witch Doctor - Secondary
            skillDict.Add("GraspOfTheDead", SNOPower.Witchdoctor_GraspOfTheDead);
            runeDict.Add("UnbreakableGrasp", 2);
            runeDict.Add("GropingEels", 0);
            runeDict.Add("DeathIsLife", 4);
            runeDict.Add("DesperateGrasp", 3);
            runeDict.Add("RainOfCorpses", 1);

            skillDict.Add("Firebats", SNOPower.Witchdoctor_Firebats);
            runeDict.Add("DireBats", 0);
            runeDict.Add("VampireBats", 3);
            runeDict.Add("PlagueBats", 2);
            runeDict.Add("HungryBats", 1);
            runeDict.Add("CloudOfBats", 4);

            skillDict.Add("Haunt", SNOPower.Witchdoctor_Haunt);
            runeDict.Add("ConsumingSpirit", 0);
            runeDict.Add("ResentfulSpirit", 4);
            runeDict.Add("LingeringSpirit", 1);
            runeDict.Add("GraspingSpirit", 2);
            runeDict.Add("DrainingSpirit", 3);

            skillDict.Add("LocustSwarm", SNOPower.Witchdoctor_Locust_Swarm);
            runeDict.Add("Pestilence", 1);
            runeDict.Add("DevouringSwarm", 3);
            runeDict.Add("CloudOfInsects", 2);
            runeDict.Add("DiseasedSwarm", 4);
            runeDict.Add("SearingLocusts", 0);

            // Witch Doctor - Defensive
            skillDict.Add("SummonZombieDogs", SNOPower.Witchdoctor_SummonZombieDog);
            runeDict.Add("RabidDogs", 2);
            runeDict.Add("FinalGift", 3);
            runeDict.Add("LifeLink", 1);
            runeDict.Add("BurningDogs", 0);
            runeDict.Add("LeechingBeasts", 4);

            skillDict.Add("Horrify", SNOPower.Witchdoctor_Horrify);
            runeDict.Add("Phobia", 2);
            runeDict.Add("Stalker", 4);
            runeDict.Add("FaceOfDeath", 1);
            runeDict.Add("FrighteningAspect", 0);
            runeDict.Add("RuthlessTerror", 3);

            skillDict.Add("SpiritWalk", SNOPower.Witchdoctor_SpiritWalk);
            runeDict.Add("Jaunt", 1);
            runeDict.Add("HonoredGuest", 3);
            runeDict.Add("UmbralShock", 2);
            runeDict.Add("Severance", 0);
            runeDict.Add("HealingJourney", 4);

            skillDict.Add("Hex", SNOPower.Witchdoctor_Hex);
            runeDict.Add("HedgeMagic", 3);
            runeDict.Add("Jinx", 4);
            runeDict.Add("AngryChicken", 1);
            runeDict.Add("PainfulTransformation", 0);
            runeDict.Add("UnstableForm", 2);

            // Witch Doctor - Terror
            skillDict.Add("SoulHarvest", SNOPower.Witchdoctor_SoulHarvest);
            runeDict.Add("SwallowYourSoul", 3);
            runeDict.Add("Siphon", 0);
            runeDict.Add("Languish", 2);
            runeDict.Add("SoulToWaste", 1);
            runeDict.Add("VengefulSpirit", 4);

            skillDict.Add("Sacrifice", SNOPower.Witchdoctor_Sacrifice);
            runeDict.Add("BlackBlood", 2);
            runeDict.Add("NextOfKin", 4);
            runeDict.Add("Pride", 3);
            runeDict.Add("ForTheMaster", 1);
            runeDict.Add("ProvokeThePack", 0);

            skillDict.Add("MassConfusion", SNOPower.Witchdoctor_MassConfusion);
            runeDict.Add("UnstableRealm", 3);
            runeDict.Add("Devolution", 4);
            runeDict.Add("MassHysteria", 1);
            runeDict.Add("Paranoia", 0);
            runeDict.Add("MassHallucination", 2);

            // Witch Doctor - Decay
            skillDict.Add("ZombieCharger", SNOPower.Witchdoctor_ZombieCharger);
            runeDict.Add("LeperousZombie", 2);
            runeDict.Add("Undeath", 3);
            runeDict.Add("WaveOfZombies", 1);
            runeDict.Add("ExplosiveBeast", 4);
            runeDict.Add("ZombieBears", 0);

            skillDict.Add("SpiritBarage", SNOPower.Witchdoctor_SpiritBarrage);
            runeDict.Add("TheSpiritIsWilling", 3);
            runeDict.Add("WellOfSouls", 1);
            runeDict.Add("Phantasm", 2);
            runeDict.Add("Phlebotomize", 0);
            runeDict.Add("Manitou", 4);

            skillDict.Add("AcidCloud", SNOPower.Witchdoctor_AcidCloud);
            runeDict.Add("AcidRain", 1);
            runeDict.Add("LobBlobBomb", 2);
            runeDict.Add("SlowBurn", 3);
            runeDict.Add("KissOfDeath", 4);
            runeDict.Add("CorpseBomb", 0);

            skillDict.Add("WallOfZombies", SNOPower.Witchdoctor_WallOfZombies);
            runeDict.Add("Barricade", 1);
            runeDict.Add("UnrelentingGrip", 3);
            runeDict.Add("Creepers", 0);
            runeDict.Add("PileOn", 4);
            runeDict.Add("DeadRush", 2);

            // Witch Doctor - Voodoo
            skillDict.Add("Gargantuan", SNOPower.Witchdoctor_Gargantuan);
            runeDict.Add("Humongoid", 1);
            runeDict.Add("RestlessGiant", 0);
            runeDict.Add("WrathfulProtector", 3);
            runeDict.Add("BigStinker", 2);
            runeDict.Add("Bruiser", 4);

            skillDict.Add("BigBadVoodoo", SNOPower.Witchdoctor_BigBadVoodoo);
            runeDict.Add("JungleDrums", 1);
            runeDict.Add("RainDance", 3);
            runeDict.Add("SlamDance", 0);
            runeDict.Add("GhostTrance", 2);
            runeDict.Add("BoogieMan", 4);

            skillDict.Add("FetishArmy", SNOPower.Witchdoctor_FetishArmy);
            runeDict.Add("FetishAmbush", 0);
            runeDict.Add("DevotedFollowing", 3);
            runeDict.Add("LegionOfDaggers", 1);
            runeDict.Add("TikiTorchers", 2);
            runeDict.Add("HeadHunters", 4);

            // Witch Doctor - Passives
            skillDict.Add("JungleFortitude", SNOPower.Witchdoctor_Passive_JungleFortitude);
            skillDict.Add("CircleOfLife", SNOPower.Witchdoctor_Passive_CircleOfLife);
            skillDict.Add("SpiritualAttunement", SNOPower.Witchdoctor_Passive_SpiritualAttunement);
            skillDict.Add("GruesomeFeast", SNOPower.Witchdoctor_Passive_GruesomeFeast);
            skillDict.Add("BloodRitual", SNOPower.Witchdoctor_Passive_BloodRitual);
            skillDict.Add("BadMedicine", SNOPower.Witchdoctor_Passive_BadMedicine);
            skillDict.Add("ZombieHandler", SNOPower.Witchdoctor_Passive_ZombieHandler);
            skillDict.Add("PierceTheVeil", SNOPower.Witchdoctor_Passive_PierceTheVeil);
            skillDict.Add("SpiritVessel", SNOPower.Witchdoctor_Passive_SpiritVessel);
            skillDict.Add("FetishSycophants", SNOPower.Witchdoctor_Passive_FetishSycophants);
            skillDict.Add("RushOfEssence", SNOPower.Witchdoctor_Passive_RushOfEssence);
            skillDict.Add("VisionQuest", SNOPower.Witchdoctor_Passive_VisionQuest);
            skillDict.Add("FierceLoyalty", SNOPower.Witchdoctor_Passive_FierceLoyalty);
            skillDict.Add("GraveInjustice", SNOPower.Witchdoctor_Passive_GraveInjustice);
            skillDict.Add("TribalRites", SNOPower.Witchdoctor_Passive_TribalRites);

            // Wizard - Primary
            skillDict.Add("MagicMissile", SNOPower.Wizard_MagicMissile);
            runeDict.Add("ChargedBlast", 0);
            runeDict.Add("Split", 1);
            runeDict.Add("PenetratingBlast", 2);
            runeDict.Add("Attunement", 3);
            runeDict.Add("Seeker", 4);

            skillDict.Add("ShockPulse", SNOPower.Wizard_ShockPulse);
            runeDict.Add("ExplosiveBolts", 4);
            runeDict.Add("FireBolts", 0);
            runeDict.Add("PiercingOrb", 2);
            runeDict.Add("LightningAffinity", 3);
            runeDict.Add("LivingLightning", 1);

            skillDict.Add("SpectralBlade", SNOPower.Wizard_SpectralBlade);
            runeDict.Add("DeepCuts", 0);
            runeDict.Add("ImpactfulBlades", 2);
            runeDict.Add("SiphoningBlade", 3);
            runeDict.Add("HealingBlades", 4);
            runeDict.Add("ThrownBlade", 1);

            skillDict.Add("Electrocute", SNOPower.Wizard_Electrocute);
            runeDict.Add("ChainLightning", 1);
            runeDict.Add("ForkedLightning", 4);
            runeDict.Add("LightningBlast", 0);
            runeDict.Add("SurgeOfPower", 3);
            runeDict.Add("ArcLightning", 2);

            // Wizard - Secondary
            skillDict.Add("RayOfFrost", SNOPower.Wizard_RayOfFrost);
            runeDict.Add("Numb", 2);
            runeDict.Add("SnowBlast", 0);
            runeDict.Add("ColdBlood", 3);
            runeDict.Add("SleetStorm", 1);
            runeDict.Add("BlackIce", 4);

            skillDict.Add("ArcaneOrb", SNOPower.Wizard_ArcaneOrb);
            runeDict.Add("Obliteration", 0);
            runeDict.Add("ArcaneOrbit", 2);
            runeDict.Add("ArcaneNova", 1);
            runeDict.Add("TapTheSource", 3);
            runeDict.Add("CelestialOrb", 4);

            skillDict.Add("ArcaneTorrent", SNOPower.Wizard_ArcaneTorrent);
            runeDict.Add("Diruption", 0);
            runeDict.Add("DeathBlossom", 4);
            runeDict.Add("ArcaneMines", 2);
            runeDict.Add("PowerStone", 3);
            runeDict.Add("Cascade", 1);

            skillDict.Add("Disintegrate", SNOPower.Wizard_Disintegrate);
            runeDict.Add("Convergence", 1);
            runeDict.Add("ChaosNexus", 3);
            runeDict.Add("Volatility", 4);
            runeDict.Add("Entropy", 2);
            runeDict.Add("Intensify", 0);

            // Wizard - Defensive
            skillDict.Add("FrostNova", SNOPower.Wizard_FrostNova);
            runeDict.Add("Shatter", 1);
            runeDict.Add("ColdSnap", 3);
            runeDict.Add("FrozenMist", 2);
            runeDict.Add("DeepFreeze", 4);
            runeDict.Add("BoneChill", 0);

            skillDict.Add("DiamondSkin", SNOPower.Wizard_DiamondSkin);
            runeDict.Add("CrystalShell", 2);
            runeDict.Add("Prism", 3);
            runeDict.Add("MirrorSkin", 0);
            runeDict.Add("EnduringSkin", 1);
            runeDict.Add("DiamondShards", 4);

            skillDict.Add("SlowTime", SNOPower.Wizard_SlowTime);
            runeDict.Add("Miasma", 1);
            runeDict.Add("TimeWarp", 0);
            runeDict.Add("TimeShell", 2);
            runeDict.Add("Perpetuity", 3);
            runeDict.Add("StretchTime", 4);

            skillDict.Add("Teleport", SNOPower.Wizard_Teleport);
            runeDict.Add("SafePassage", 2);
            runeDict.Add("Wormhole", 4);
            runeDict.Add("Reversal", 3);
            runeDict.Add("Fracture", 1);
            runeDict.Add("Calamity", 0);

            // Wizard - Force
            skillDict.Add("WaveOfForce", SNOPower.Wizard_WaveOfForce);
            runeDict.Add("ImpactfulWave", 4);
            runeDict.Add("ForceAffinity", 3);
            runeDict.Add("ForcefulWave", 0);
            runeDict.Add("TeleportingWave", 2);
            runeDict.Add("ExplodingWave", 1);

            skillDict.Add("EnergyTwister", SNOPower.Wizard_EnergyTwister);
            runeDict.Add("MistralBreeze", 3);
            runeDict.Add("GaleForce", 0);
            runeDict.Add("RagingStorm", 1);
            runeDict.Add("WickedWind", 4);
            runeDict.Add("StromChaser", 2);

            skillDict.Add("Hydra", SNOPower.Wizard_Hydra);
            runeDict.Add("ArcaneHydra", 4);
            runeDict.Add("LightningHydra", 1);
            runeDict.Add("VenomHydra", 2);
            runeDict.Add("FrostHydra", 0);
            runeDict.Add("MammothHydra", 3);

            skillDict.Add("Meteor", SNOPower.Wizard_Meteor);
            runeDict.Add("MoltenImpact", 0);
            runeDict.Add("StarPact", 3);
            runeDict.Add("MeteorShower", 1);
            runeDict.Add("Comet", 2);
            runeDict.Add("Liquefy", 4);

            skillDict.Add("Blizzard", SNOPower.Wizard_Blizzard);
            runeDict.Add("GraspingChill", 2);
            runeDict.Add("FrozenSolid", 4);
            runeDict.Add("Snowbound", 3);
            runeDict.Add("StarkWinter", 1);
            runeDict.Add("UnrelentingStorm", 0);

            // Wizard - Conjuration
            skillDict.Add("IceArmor", SNOPower.Wizard_IceArmor);
            runeDict.Add("ChillingAura", 1);
            runeDict.Add("Crystallize", 3);
            runeDict.Add("JaggedIce", 0);
            runeDict.Add("IceReflect", 4);
            runeDict.Add("FrozenStorm", 2);

            skillDict.Add("StormArmor", SNOPower.Wizard_StormArmor);
            runeDict.Add("ReactiveArmor", 2);
            runeDict.Add("PowerOfTheStorm", 3);
            runeDict.Add("ThunderStorm", 0);
            runeDict.Add("Scramble", 1);
            runeDict.Add("ShockingAspect", 4);

            skillDict.Add("MagicWeapon", SNOPower.Wizard_MagicWeapon);
            runeDict.Add("Electrify", 1);
            runeDict.Add("ForceWeapon", 2);
            runeDict.Add("Conduit", 3);
            runeDict.Add("Venom", 0);
            runeDict.Add("BloodMagic", 4);

            skillDict.Add("Familiar", SNOPower.Wizard_Familiar);
            runeDict.Add("Sparkflint", 0);
            runeDict.Add("Vigoron", 2);
            runeDict.Add("AncientGuardian", 4);
            runeDict.Add("Arcanot", 3);
            runeDict.Add("Cannoneer", 1);

            skillDict.Add("EnergyArmor", SNOPower.Wizard_EnergyArmor);
            runeDict.Add("Absorption", 3);
            runeDict.Add("PinpointBarrier", 4);
            runeDict.Add("EnergyTap", 1);
            runeDict.Add("ForceArmor", 2);
            runeDict.Add("PrismaticArmor", 0);

            // Wizard - Mastery
            skillDict.Add("ExplosiveBlast", SNOPower.Wizard_ExplosiveBlast);
            runeDict.Add("Unleashed", 3);
            runeDict.Add("TimeBomb", 2);
            runeDict.Add("ShortFuse", 0);
            runeDict.Add("Obliterate", 1);
            runeDict.Add("ChainReaction", 4);

            skillDict.Add("MirrorImage", SNOPower.Wizard_MirrorImage);
            runeDict.Add("Simulacrum", 2);
            runeDict.Add("Duplicates", 1);
            runeDict.Add("MockingDemise", 4);
            runeDict.Add("ExtensionOfWill", 3);
            runeDict.Add("MirrorMimics", 0);

            skillDict.Add("Archon", SNOPower.Wizard_Archon);
            runeDict.Add("ArcaneDestruction", 4);
            runeDict.Add("Teleport", 2);
            runeDict.Add("PurePower", 3);
            runeDict.Add("SlowTime", 1);
            runeDict.Add("ImprovedArchon", 0);

            // Wizard - Passives
            skillDict.Add("PowerHungry", SNOPower.Wizard_Passive_PowerHungry);
            skillDict.Add("Blur", SNOPower.Wizard_Passive_Blur);
            skillDict.Add("Evocation", SNOPower.Wizard_Passive_Evocation);
            skillDict.Add("GlassCannon", SNOPower.Wizard_Passive_GlassCannon);
            skillDict.Add("Prodigy", SNOPower.Wizard_Passive_Prodigy);
            skillDict.Add("AstralPresence", SNOPower.Wizard_Passive_AstralPresence);
            skillDict.Add("Illusionist", SNOPower.Wizard_Passive_Illusionist);
            skillDict.Add("ColdBlooded", SNOPower.Wizard_Passive_ColdBlooded);
            skillDict.Add("Conflagration", SNOPower.Wizard_Passive_Conflagration);
            skillDict.Add("Paralysis", SNOPower.Wizard_Passive_Paralysis);
            skillDict.Add("GalvanizingWard", SNOPower.Wizard_Passive_GalvanizingWard);
            skillDict.Add("TemporalFlux", SNOPower.Wizard_Passive_TemporalFlux);
            skillDict.Add("CriticalMass", SNOPower.Wizard_Passive_CriticalMass);
            skillDict.Add("ArcaneDynamo", SNOPower.Wizard_Passive_ArcaneDynamo);
            skillDict.Add("UnstableAnomaly", SNOPower.Wizard_Passive_UnstableAnomaly);
        }

        public abstract bool activate();

        public abstract void setSlotByString(string slotString);

        public void setSnoPowerByString(string skillString) {
            this.setSnoPower(skillDict[skillString]);
        }

        public void setRuneIdByString(string runeString) {
            this.setRuneId(runeDict[runeString]);
        }

        public SNOPower getSnoPower() {
            return this.power;
        }

        public void setSnoPower(SNOPower snoPower) {
            this.power = snoPower;
        }

        public int getRuneId() {
            return this.runeId;
        }

        public void setRuneId(int runeId) {
            this.runeId = runeId;
        }
    }
}

/* Code                                 Name                     Class       Rune 0                  Rune 1                  Rune 2                  Rune 3                  Rune 4                  
wizard_electrocute                      Electrocute              Wizard      Lightning Blast         Chain Lightning         Arc Lightning           Surge of Power          Forked Lightning        
wizard_slowtime                         Slow Time                Wizard      Time Warp               Miasma                  Time Shell              Perpetuity              Stretch Time            
witchdoctor_gargantuan                  Gargantuan               WitchDoctor Restless Giant          Humongoid               Big Stinker             Wrathful Protector      Bruiser                 
witchdoctor_hex                         Hex                      WitchDoctor Painful Transformation  Angry Chicken           Unstable Form           Hedge Magic             Jinx                    
wizard_arcaneorb                        Arcane Orb               Wizard      Obliteration            Arcane Nova             Arcane Orbit            Tap the Source          Celestial Orb           
wizard_blizzard                         Blizzard                 Wizard      Unrelenting Storm       Stark Winter            Grasping Chill          Snowbound               Frozen Solid            
wizard_frostnova                        Frost Nova               Wizard      Bone Chill              Shatter                 Frozen Mist             Cold Snap               Deep Freeze             
wizard_hydra                            Hydra                    Wizard      Frost Hydra             Lightning Hydra         Venom Hydra             Mammoth Hydra           Arcane Hydra            
wizard_magicmissile                     Magic Missile            Wizard      Charged Blast           Split                   Penetrating Blast       Attunement              Seeker                  
wizard_shockpulse                       Shock Pulse              Wizard      Fire Bolts              Living Lightning        Piercing Orb            Lightning Affinity      Explosive Bolts         
wizard_waveofforce                      Wave of Force            Wizard      Forceful Wave           Exploding Wave          Teleporting Wave        Force Affinity          Impactful Wave          
witchdoctor_firebomb                    Firebomb                 WitchDoctor Ghost Bomb              Roll the Bones          Fire Pit                Pyrogeist               Flash Fire              
witchdoctor_massconfusion               Mass Confusion           WitchDoctor Paranoia                Mass Hysteria           Mass Hallucination      Unstable Realm          Devolution              
witchdoctor_soulharvest                 Soul Harvest             WitchDoctor Siphon                  Soul to Waste           Languish                Swallow Your Soul       Vengeful Spirit         
witchdoctor_horrify                     Horrify                  WitchDoctor Frightening Aspect      Face of Death           Phobia                  Ruthless Terror         Stalker                 
monk_breathofheaven                     Breath of Heaven         Monk        Circle of Scorn         Circle of Life          Blazing Wrath           Infused with Light      Penitent Flame          
witchdoctor_graspofthedead              Grasp of the Dead        WitchDoctor Groping Eels            Rain of Corpses         Unbreakable Grasp       Desperate Grasp         Death Is Life           
wizard_meteor                           Meteor                   Wizard      Molten Impact           Meteor Shower           Comet                   Star Pact               Liquefy                 
monk_mantraofretribution                Mantra of Retribution    Monk        Retaliation             Transgression           Indignation             Against All Odds        Collateral Damage       
monk_mantraofhealing                    Mantra of Healing        Monk        Sustenance              Boon of Inspiration     Heavenly Body           Circular Breathing      Time of Need            
witchdoctor_corpsespider                Corpse Spiders           WitchDoctor Blazing Spiders         Spider Queen            Leaping Spiders         Widowmakers             Medusa Spiders          
witchdoctor_locust_swarm                Locust Swarm             WitchDoctor Searing Locusts         Pestilence              Cloud of Insects        Devouring Swarm         Diseased Swarm          
barbarian_ancientspear                  Ancient Spear            Barbarian   Harpoon                 Grappling Hooks         Dread Spear             Skirmish                Rage Flip               
witchdoctor_acidcloud                   Acid Cloud               WitchDoctor Corpse Bomb             Acid Rain               Lob Blob Bomb           Slow Burn               Kiss of Death           
barbarian_rend                          Rend                     Barbarian   Lacerate                Ravage                  Mutilate                Blood Lust              Bloodbath               
wizard_spectralblade                    Spectral Blade           Wizard      Deep Cuts               Thrown Blade            Impactful Blades        Siphoning Blade         Healing Blades          
witchdoctor_fetisharmy                  Fetish Army              WitchDoctor Fetish Ambush           Legion of Daggers       Tiki Torchers           Devoted Following       Head Hunters            
wizard_icearmor                         Ice Armor                Wizard      Jagged Ice              Chilling Aura           Frozen Storm            Crystallize             Ice Reflect             
witchdoctor_zombiecharger               Zombie Charger           WitchDoctor Zombie Bears            Wave of Zombies         Leperous Zombie         Undeath                 Explosive Beast         
wizard_stormarmor                       Storm Armor              Wizard      Thunder Storm           Scramble                Reactive Armor          Power of the Storm      Shocking Aspect         
demonhunter_spiketrap                   Spike Trap               DemonHunter Long Fuse               Echoing Blast           Sticky Trap             Scatter                 Lightning Rod           
wizard_diamondskin                      Diamond Skin             Wizard      Mirror Skin             Enduring Skin           Crystal Shell           Prism                   Diamond Shards          
demonhunter_entanglingshot              Entangling Shot          DemonHunter Heavy Burden            Chain Gang              Shock Collar            Justice is Served       Bounty Hunter           
wizard_magicweapon                      Magic Weapon             Wizard      Venom                   Electrify               Force Weapon            Conduit                 Blood Magic             
wizard_energytwister                    Energy Twister           Wizard      Gale Force              Raging Storm            Storm Chaser            Mistral Breeze          Wicked Wind             
demonhunter_fanofknives                 Fan of Knives            DemonHunter Hail of Knives          Assassin's Knives       Fan of Daggers          Crippling Razors        Retaliate               
demonhunter_bolashot                    Bola Shot                DemonHunter Volatile Explosives     Acid Strike             Thunder Ball            Bitter Pill             Imminent Doom           
demonhunter_multishot                   Multishot                DemonHunter Full Broadside          Burst Fire              Arsenal                 Fire at Will            Suppression Fire        
barbarian_frenzy                        Frenzy                   Barbarian   Maniac                  Sidearm                 Vanguard                Smite                   Triumph                 
barbarian_sprint                        Sprint                   Barbarian   Marathon                Rush                    Run Like the Wind       Forced March            Gangway                 
barbarian_battlerage                    Battle Rage              Barbarian   Marauder's Rage         Ferocity                Swords to Ploughshares  Into the Fray           Bloodshed               
barbarian_threateningshout              Threatening Shout        Barbarian   Demoralize              Intimidate              Grim Harvest            Falter                  Terrify                 
barbarian_bash                          Bash                     Barbarian   Onslaught               Punish                  Clobber                 Instigation             Pulverize               
barbarian_groundstomp                   Ground Stomp             Barbarian   Trembling Stomp         Wrenching Smash         Avalanche               Foot of the Mountain    Deafening Crash         
barbarian_ignorepain                    Ignore Pain              Barbarian   Contempt for Weakness   Iron Hide               Mob Rule                Bravado                 Ignorance is Bliss      
barbarian_wrathoftheberserker           Wrath of the Berserker   Barbarian   Insanity                Arreat's Wail           Striding Giant          Thrive on Chaos         Slaughter               
barbarian_hammeroftheancients           Hammer of the Ancients   Barbarian   Smash                   Rolling Thunder         The Devil's Anvil       Birthright              Thunderstrike           
barbarian_calloftheancients             Call of the Ancients     Barbarian   Korlic's Might          The Council Rises       Madawc's Madness        Duty to the Clan        Talic's Anger           
barbarian_cleave                        Cleave                   Barbarian   Broad Sweep             Gathering Storm         Scattering Blast        Reaping Swing           Rupture                 
barbarian_warcry                        War Cry                  Barbarian   Hardened Wrath          Veteran's Warning       Impunity                Charge!                 Invigorate              
witchdoctor_haunt                       Haunt                    WitchDoctor Consuming Spirit        Lingering Spirit        Grasping Spirit         Draining Spirit         Resentful Spirit        
demonhunter_grenades                    Grenades                 DemonHunter Gas Grenades            Cluster Grenades        Fire Bomb               Tinkerer                Stun Grenades           
barbarian_seismicslam                   Seismic Slam             Barbarian   Shattered Ground        Rumble                  Stagger                 Strength from Earth     Cracking Rift           
wizard_energyarmor                      Energy Armor             Wizard      Prismatic Armor         Energy Tap              Force Armor             Absorption              Pinpoint Barrier        
wizard_explosiveblast                   Explosive Blast          Wizard      Short Fuse              Obliterate              Time Bomb               Unleashed               Chain Reaction          
wizard_disintegrate                     Disintegrate             Wizard      Intensify               Convergence             Entropy                 Chaos Nexus             Volatility              
wizard_rayoffrost                       Ray of Frost             Wizard      Snow Blast              Sleet Storm             Numb                    Cold Blood              Black Ice               
barbarian_leap                          Leap                     Barbarian   Call of Arreat          Toppling Impact         Launch                  Iron Impact             Death from Above        
barbarian_weaponthrow                   Weapon Throw             Barbarian   Mighty Throw            Ricochet                Throwing Hammer         Dread Bomb              Stupefy                 
monk_mantraofconviction                 Mantra of Conviction     Monk        Overawe                 Submission              Dishearten              Reclamation             Intimidation            
monk_fistsofthunder                     Fists of Thunder         Monk        Thunderclap             Bounding Light          Static Charge           Quickening              Lightning Flash         
monk_deadlyreach                        Deadly Reach             Monk        Foresight               Piercing Trident        Scattered Blows         Strike from Beyond      Keen Eye                
monk_waveoflight                        Wave of Light            Monk        Wall of Light           Explosive Light         Pillar of the Ancients  Empowered Wave          Blinding Light          
monk_sweepingwind                       Sweeping Wind            Monk        Blade Storm             Fire Storm              Cyclone                 Inner Storm             Master of Wind          
monk_dashingstrike                      Dashing Strike           Monk        Soaring Skull           Way of the Falling Star Blinding Speed          Quicksilver             Flying Side Kick        
monk_serenity                           Serenity                 Monk        Peaceful Repose         Instant Karma           Ascension               Tranquility             Reap What Is Sown       
barbarian_whirlwind                     Whirlwind                Barbarian   Volcanic Eruption       Dust Devils             Hurricane               Wind Shear              Blood Funnel            
monk_cripplingwave                      Crippling Wave           Monk        Mangle                  Tsunami                 Concussion              Rising Tide             Breaking Wave           
monk_sevensidedstrike                   Seven-Sided Strike       Monk        Sudden Assault          Several-Sided Strike    Pandemonium             Sustained Attack        Fulminating Onslaught   
monk_wayofthehundredfists               Way of the Hundred Fists Monk        Fists of Fury           Hands of Lightning      Blazing Fists           Spirited Salvo          Windforce Flurry        
monk_innersanctuary                     Inner Sanctuary          Monk        Forbidden Palace        Consecration            Circle of Protection    Safe Haven              Sanctified Ground       
monk_explodingpalm                      Exploding Palm           Monk        Impending Doom          Creeping Demise         The Flesh is Weak       Strong Spirit           Essence Burn            
barbarian_furiouscharge                 Furious Charge           Barbarian   Battering Ram           Dreadnought             Bull Rush               Stamina                 Merciless Assault       
wizard_mirrorimage                      Mirror Image             Wizard      Mirror Mimics           Duplicates              Simulacrum              Extension of Will       Mocking Demise          
barbarian_earthquake                    Earthquake               Barbarian   Aftershocks             Giant's Stride          Chilling Earth          The Mountain's Call     Path of Fire            
wizard_familiar                         Familiar                 Wizard      Sparkflint              Cannoneer               Vigoron                 Arcanot                 Ancient Guardian        
witchdoctor_sacrifice                   Sacrifice                WitchDoctor Provoke the Pack        For the Master          Black Blood             Pride                   Next of Kin             
witchdoctor_summonzombiedog             Summon Zombie Dogs       WitchDoctor Burning Dogs            Life Link               Rabid Dogs              Final Gift              Leeching Beasts         
witchdoctor_poisondart                  Poison Dart              WitchDoctor Flaming Dart            Splinters               Numbing Dart            Spined Dart             Snake to the Face       
witchdoctor_firebats                    Firebats                 WitchDoctor Dire Bats               Hungry Bats             Plague Bats             Vampire Bats            Cloud of Bats           
witchdoctor_spiritwalk                  Spirit Walk              WitchDoctor Severance               Jaunt                   Umbral Shock            Honored Guest           Healing Journey         
witchdoctor_plagueoftoads               Plague of Toads          WitchDoctor Explosive Toads         Rain of Toads           Toad of Hugeness        Toad Affinity           Addling Toads           
witchdoctor_spiritbarrage               Spirit Barrage           WitchDoctor Phlebotomize            Well of Souls           Phantasm                The Spirit Is Willing   Manitou                 
barbarian_revenge                       Revenge                  Barbarian   Retribution             Provocation             Grudge                  Vengeance Is Mine       Best Served Cold        
demonhunter_vault                       Vault                    DemonHunter Trail of Cinders        Acrobatics              Action Shot             Tumble                  Rattling Roll           
monk_lashingtailkick                    Lashing Tail Kick        Monk        Vulture Claw Kick       Spinning Flame Kick     Hand of Ytar            Sweeping Armada         Scorpion Sting          
witchdoctor_bigbadvoodoo                Big Bad Voodoo           WitchDoctor Slam Dance              Jungle Drums            Ghost Trance            Rain Dance              Boogie Man              
monk_tempestrush                        Tempest Rush             Monk        Bluster                 Tailwind                Slipstream              Northern Breeze         Flurry                  
monk_mystically                         Mystic Ally              Monk        Fire Ally               Water Ally              Earth Ally              Air Ally                Eternal Ally            
demonhunter_preparation                 Preparation              DemonHunter Punishment              Invigoration            Focused Mind            Battle Scars            Backup Plan             
demonhunter_chakram                     Chakram                  DemonHunter Twin Chakrams           Boomerang               Serpentine              Razor Disk              Shuriken Cloud          
demonhunter_clusterarrow                Cluster Arrow            DemonHunter Loaded for Bear         Shooting Stars          Cluster Bombs           Maelstrom               Dazzling Arrow          
demonhunter_hungeringarrow              Hungering Arrow          DemonHunter Cinder Arrow            Shatter Shot            Devouring Arrow         Puncturing Arrow        Spray of Teeth          
demonhunter_caltrops                    Caltrops                 DemonHunter Jagged Spikes           Hooked Spines           Torturous Ground        Carved Stakes           Bait the Trap           
demonhunter_sentry                      Sentry                   DemonHunter Chain of Torment        Vigilant Watcher        Spitfire Turret         Aid Station             Guardian Turret         
demonhunter_smokescreen                 Smoke Screen             DemonHunter Choking Gas             Lingering Fog           Breathe Deep            Special Recipe          Displacement            
demonhunter_markedfordeath              Marked for Death         DemonHunter Grim Reaper             Contagion               Valley of Death         Mortal Enemy            Death Toll              
demonhunter_shadowpower                 Shadow Power             DemonHunter Night Bane              Shadow Glide            Gloom                   Well of Darkness        Blood Moon              
demonhunter_rainofvengeance             Rain of Vengeance        DemonHunter Beastly Bombs           Dark Cloud              Anathema                Flying Strike           Stampede                
demonhunter_rapidfire                   Rapid Fire               DemonHunter Bombardment             High Velocity           Fire Support            Withering Fire          Web Shot                
demonhunter_elementalarrow              Elemental Arrow          DemonHunter Frost Arrow             Ball Lightning          Screaming Skull         Nether Tentacles        Lightning Bolts         
demonhunter_impale                      Impale                   DemonHunter Overpenetration         Impact                  Chemical Burn           Awareness               Grievous Wounds         
demonhunter_companion                   Companion                DemonHunter Spider Companion        Boar Companion          Wolf Companion          Bat Companion           Ferret Companion        
demonhunter_strafe                      Strafe                   DemonHunter Demolition              Emberstrafe             Rocket Storm            Drifting Shadow         Stinging Steel          
demonhunter_evasivefire                 Evasive Fire             DemonHunter Hardened                Covering Fire           Parting Gift            Surge                   Displace                
wizard_arcanetorrent                    Arcane Torrent           Wizard      Disruption              Cascade                 Arcane Mines            Power Stone             Death Blossom           
witchdoctor_wallofzombies               Wall of Zombies          WitchDoctor Creepers                Barricade               Dead Rush               Unrelenting Grip        Pile On                 
wizard_archon                           Archon                   Wizard      Improved Archon         Slow Time               Teleport                Pure Power              Arcane Destruction      
wizard_archon_arcanestrike              Arcane Strike            Wizard                                                                                                                              
wizard_archon_disintegrationwave        Disintegration Wave      Wizard                                                                                                                              
wizard_archon_slowtime                  Slow Time                Wizard                                                                                                                              
monk_blindingflash                      Blinding Flash           Monk        Faith in the Light      Blinding Echo           Blinded and Confused    Self Reflection         Searing Light           
demonhunter_passive_vengeance           Vengeance                DemonHunter                                                                                                                         
demonhunter_passive_sharpshooter        Sharpshooter             DemonHunter                                                                                                                         
demonhunter_passive_culltheweak         Cull the Weak            DemonHunter                                                                                                                         
demonhunter_passive_perfectionist       Perfectionist            DemonHunter                                                                                                                         
demonhunter_passive_ballistics          Ballistics               DemonHunter                                                                                                                         
demonhunter_passive_hotpursuit          Hot Pursuit              DemonHunter                                                                                                                         
monk_passive_chantofresonance           Chant of Resonance       Monk                                                                                                                                
monk_passive_neardeathexperience        Near Death Experience    Monk                                                                                                                                
monk_passive_guidinglight               Guiding Light            Monk                                                                                                                                
barbarian_overpower                     Overpower                Barbarian   Killing Spree           Storm of Steel          Revel                   Momentum                Crushing Advance        
demonhunter_passive_steadyaim           Steady Aim               DemonHunter                                                                                                                         
wizard_archon_arcaneblast               Arcane Blast             Wizard                                                                                                                              
wizard_archon_teleport                  Teleport                 Wizard                                                                                                                              
wizard_teleport                         Teleport                 Wizard      Calamity                Fracture                Safe Passage            Reversal                Wormhole                
monk_mantraofevasion                    Mantra of Evasion        Monk        Backlash                Perseverance            Hard Target             Wind through the Reeds  Divine Protection       
barbarian_passive_boonofbulkathos       Boon of Bul-Kathos       Barbarian                                                                                                                           
barbarian_passive_noescape              No Escape                Barbarian                                                                                                                           
barbarian_passive_brawler               Brawler                  Barbarian                                                                                                                           
barbarian_passive_ruthless              Ruthless                 Barbarian                                                                                                                           
barbarian_passive_berserkerrage         Berserker Rage           Barbarian                                                                                                                           
barbarian_passive_poundofflesh          Pound of Flesh           Barbarian                                                                                                                           
barbarian_passive_bloodthirst           Bloodthirst              Barbarian                                                                                                                           
barbarian_passive_animosity             Animosity                Barbarian                                                                                                                           
barbarian_passive_unforgiving           Unforgiving              Barbarian                                                                                                                           
barbarian_passive_relentless            Relentless               Barbarian                                                                                                                           
barbarian_passive_superstition          Superstition             Barbarian                                                                                                                           
barbarian_passive_inspiringpresence     Inspiring Presence       Barbarian                                                                                                                           
barbarian_passive_juggernaut            Juggernaut               Barbarian                                                                                                                           
barbarian_passive_toughasnails          Tough as Nails           Barbarian                                                                                                                           
barbarian_passive_weaponsmaster         Weapons Master           Barbarian                                                                                                                           
wizard_passive_blur                     Blur                     Wizard                                                                                                                              
wizard_passive_glasscannon              Glass Cannon             Wizard                                                                                                                              
wizard_passive_astralpresence           Astral Presence          Wizard                                                                                                                              
wizard_passive_evocation                Evocation                Wizard                                                                                                                              
wizard_passive_unstableanomaly          Unstable Anomaly         Wizard                                                                                                                              
wizard_passive_temporalflux             Temporal Flux            Wizard                                                                                                                              
wizard_passive_powerhungry              Power Hungry             Wizard                                                                                                                              
wizard_passive_prodigy                  Prodigy                  Wizard                                                                                                                              
wizard_passive_galvanizingward          Galvanizing Ward         Wizard                                                                                                                              
wizard_passive_illusionist              Illusionist              Wizard                                                                                                                              
witchdoctor_passive_zombiehandler       Zombie Handler           WitchDoctor                                                                                                                         
witchdoctor_passive_rushofessence       Rush of Essence          WitchDoctor                                                                                                                         
witchdoctor_passive_bloodritual         Blood Ritual             WitchDoctor                                                                                                                         
witchdoctor_passive_spiritualattunement Spiritual Attunement     WitchDoctor                                                                                                                         
witchdoctor_passive_circleoflife        Circle of Life           WitchDoctor                                                                                                                         
witchdoctor_passive_gruesomefeast       Gruesome Feast           WitchDoctor                                                                                                                         
witchdoctor_passive_tribalrites         Tribal Rites             WitchDoctor                                                                                                                         
demonhunter_passive_customengineering   Custom Engineering       DemonHunter                                                                                                                         
witchdoctor_passive_piercetheveil       Pierce the Veil          WitchDoctor                                                                                                                         
witchdoctor_passive_fierceloyalty       Fierce Loyalty           WitchDoctor                                                                                                                         
demonhunter_passive_grenadier           Grenadier                DemonHunter                                                                                                                         
wizard_passive_arcanedynamo             Arcane Dynamo            Wizard                                                                                                                              
monk_passive_exaltedsoul                Exalted Soul             Monk                                                                                                                                
monk_passive_fleetfooted                Fleet Footed             Monk                                                                                                                                
witchdoctor_passive_visionquest         Vision Quest             WitchDoctor                                                                                                                         
monk_passive_beaconofytar               Beacon of Ytar           Monk                                                                                                                                
monk_passive_transcendence              Transcendence            Monk                                                                                                                                
monk_passive_sixthsense                 Sixth Sense              Monk                                                                                                                                
monk_passive_seizetheinitiative         Seize the Initiative     Monk                                                                                                                                
monk_passive_onewitheverything          One With Everything      Monk                                                                                                                                
demonhunter_passive_archery             Archery                  DemonHunter                                                                                                                         
monk_passive_theguardianspath           The Guardian's Path      Monk                                                                                                                                
monk_passive_pacifism                   Pacifism                 Monk                                                                                                                                
demonhunter_passive_brooding            Brooding                 DemonHunter                                                                                                                         
demonhunter_passive_thrillofthehunt     Thrill of the Hunt       DemonHunter                                                                                                                         
monk_passive_resolve                    Resolve                  Monk                                                                                                                                
barbarian_passive_nervesofsteel         Nerves Of Steel          Barbarian                                                                                                                           
witchdoctor_passive_badmedicine         Bad Medicine             WitchDoctor                                                                                                                         
witchdoctor_passive_junglefortitude     Jungle Fortitude         WitchDoctor                                                                                                                         
wizard_passive_conflagration            Conflagration            Wizard                                                                                                                              
wizard_passive_criticalmass             Critical Mass            Wizard                                                                                                                              
witchdoctor_passive_graveinjustice      Grave Injustice          WitchDoctor                                                                                                                         
demonhunter_passive_nightstalker        Night Stalker            DemonHunter                                                                                                                         
demonhunter_passive_tacticaladvantage   Tactical Advantage       DemonHunter                                                                                                                         
demonhunter_passive_numbingtraps        Numbing Traps            DemonHunter                                                                                                                         
monk_passive_combinationstrike          Combination Strike       Monk                                                                                                                                
witchdoctor_passive_spiritvessel        Spirit Vessel            WitchDoctor                                                                                                                         
witchdoctor_passive_fetishsycophants    Fetish Sycophants        WitchDoctor                                                                                                                         
monk_cyclonestrike                      Cyclone Strike           Monk        Sunburst                Implosion               Soothing Breeze         Eye of the Storm        Wall of Wind            
wizard_passive_coldblooded              Cold Blooded             Wizard                                                                                                                              
wizard_passive_paralysis                Paralysis                Wizard */
