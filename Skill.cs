using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Game.Internals.Actors;

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
            runeDict.Add("Frostbite", 0);
            runeDict.Add("Onslaught", 1);
            runeDict.Add("Punish", 2);
            runeDict.Add("Instigation", 3);
            runeDict.Add("Pulverize", 4);

            skillDict.Add("Cleave", SNOPower.Barbarian_Cleave);
            runeDict.Add("Rupture", 0);
            runeDict.Add("ReapingSwing", 1);
            runeDict.Add("ScatteringBlast", 2);
            runeDict.Add("BroadSweep", 3);
            runeDict.Add("GatheringStorm", 4);

            skillDict.Add("Frenzy", SNOPower.Barbarian_Frenzy);
            runeDict.Add("Sidearm", 0);
            runeDict.Add("Berserk", 1);
            runeDict.Add("Vanguard", 2);
            runeDict.Add("Smite", 3);
            runeDict.Add("Maniac", 4);

            skillDict.Add("WeaponThrow", SNOPower.X1_Barbarian_WeaponThrow);
            runeDict.Add("MightyThrow", 0);
            runeDict.Add("Ricochet", 1);
            runeDict.Add("ThrowingHammer", 2);
            runeDict.Add("Stupefy", 3);
            runeDict.Add("BalancedWeapon", 4);

            // Barbarian - Secondary
            skillDict.Add("HammerOfTheAncients", SNOPower.Barbarian_HammerOfTheAncients);
            runeDict.Add("RollingThunder", 0);
            runeDict.Add("Smash", 1);
            runeDict.Add("TheDevilsAnvil", 2);
            runeDict.Add("Thunderstrike", 3);
            runeDict.Add("Birthright", 4);

            skillDict.Add("Rend", SNOPower.Barbarian_Rend);
            runeDict.Add("Ravage", 0);
            runeDict.Add("BloodLust", 2);
            runeDict.Add("Lacerate", 3);
            runeDict.Add("Mutilate", 4);
            runeDict.Add("Bloodbath", 5);

            skillDict.Add("SeismicSlam", SNOPower.Barbarian_SeismicSlam);
            runeDict.Add("Stagger", 0);
            runeDict.Add("ShatteredGround", 1);
            runeDict.Add("Rumble", 2);
            runeDict.Add("StrengthFromEarth", 3);
            runeDict.Add("Permafrost", 4);

            skillDict.Add("Whirlwind", SNOPower.Barbarian_Whirlwind);
            runeDict.Add("DustDevils", 0);
            runeDict.Add("Hurricane", 1);
            runeDict.Add("BloodFunnel", 2);
            runeDict.Add("WindShear", 3);
            runeDict.Add("VolcanicEruption", 4);

            skillDict.Add("AncientSpear", SNOPower.X1_Barbarian_AncientSpear);
            runeDict.Add("Ranseur", 0);
            runeDict.Add("Harpoon", 1);
            runeDict.Add("JaggedEdge", 2);
            runeDict.Add("BoulderToss", 3);
            runeDict.Add("RageFlip", 4);

            // Barbarian - Defensive
            skillDict.Add("GroundStomp", SNOPower.Barbarian_GroundStomp);
            runeDict.Add("DeafeningCrash", 0);
            runeDict.Add("WrenchingSmash", 1);
            runeDict.Add("TremblingStomp", 2);
            runeDict.Add("FootOfTheMountain", 3);
            runeDict.Add("JarringSlam", 4);

            skillDict.Add("Leap", SNOPower.Barbarian_Leap);
            runeDict.Add("IronImpact", 0);
            runeDict.Add("Launch", 1);
            runeDict.Add("TopplingImpact", 2);
            runeDict.Add("CallOfArreat", 3);
            runeDict.Add("DeathFromAbove", 4);

            skillDict.Add("Sprint", SNOPower.Barbarian_Sprint);
            runeDict.Add("Rush", 0);
            runeDict.Add("RunLikeTheWind", 1);
            runeDict.Add("Marathon", 2);
            runeDict.Add("Gangway", 3);
            runeDict.Add("ForcedMarch", 4);

            skillDict.Add("IgnorePain", SNOPower.Barbarian_IgnorePain);
            runeDict.Add("Bravado", 0);
            runeDict.Add("IronHide", 1);
            runeDict.Add("IgnoranceIsBliss", 2);
            runeDict.Add("MobRule", 3);
            runeDict.Add("ContemptForWeakness", 4);

            // Barbarian - Might
            skillDict.Add("Overpower", SNOPower.Barbarian_Overpower);
            runeDict.Add("StormOfSteel", 0);
            runeDict.Add("KillingSpree", 1);
            runeDict.Add("CrushingAdvance", 2);
            runeDict.Add("Momentum", 3);
            runeDict.Add("Revel", 4);

            skillDict.Add("Revenge", SNOPower.Barbarian_Revenge);
            runeDict.Add("BloodLaw", 0);
            runeDict.Add("BestServedCold", 1);
            runeDict.Add("Retribution", 2);
            runeDict.Add("Grudge", 3);
            runeDict.Add("Provocation", 4);

            skillDict.Add("FuriousCharge", SNOPower.Barbarian_FuriousCharge);
            runeDict.Add("BatteringRam", 0);
            runeDict.Add("MercilessAssault", 1);
            runeDict.Add("Stamina", 2);
            runeDict.Add("ColdRush", 3);
            runeDict.Add("Dreadnought", 4);

            skillDict.Add("Avalanche", SNOPower.X1_Barbarian_Avalanche_v2);
            runeDict.Add("Volcano", 0);
            runeDict.Add("Lahar", 1);
            runeDict.Add("SnowCappedMountain", 2);
            runeDict.Add("TectonicRift", 3);
            runeDict.Add("Glacier", 4);

            // Barbarian - Tactics
            skillDict.Add("ThreateningShout", SNOPower.Barbarian_ThreateningShout);
            runeDict.Add("Intimidate", 0);
            runeDict.Add("Falter", 1);
            runeDict.Add("GrimHarvest", 2);
            runeDict.Add("Demoralize", 3);
            runeDict.Add("Terrify", 4);

            skillDict.Add("BattleRage", SNOPower.Barbarian_BattleRage);
            runeDict.Add("MaraudersRage", 0);
            runeDict.Add("Ferocity", 1);
            runeDict.Add("SwordsToPloughshares", 2);
            runeDict.Add("IntoTheFray", 3);
            runeDict.Add("Bloodshed", 4);

            skillDict.Add("WarCry", SNOPower.X1_Barbarian_WarCry_v2);
            runeDict.Add("HardenedWrath", 0);
            runeDict.Add("Charge", 1);
            runeDict.Add("Invigorate", 2);
            runeDict.Add("VeteransWarning", 3);
            runeDict.Add("Impunity", 4);

            // Barbarian - Rage
            skillDict.Add("Earthquake", SNOPower.Barbarian_Earthquake);
            runeDict.Add("GiantsStride", 0);
            runeDict.Add("ChillingEarth", 1);
            runeDict.Add("TheMountainsCall", 2);
            runeDict.Add("MoltenFury", 3);
            runeDict.Add("CaveIn", 4);

            skillDict.Add("CallOfTheAncients", SNOPower.Barbarian_CallOfTheAncients);
            runeDict.Add("TheCouncilRises", 0);
            runeDict.Add("DutyToTheClan", 1);
            runeDict.Add("AncientsBlessing", 2);
            runeDict.Add("AncientsFury", 3);
            runeDict.Add("TogetherAsOne", 4);

            skillDict.Add("WrathOfTheBerserker", SNOPower.Barbarian_WrathOfTheBerserker);
            runeDict.Add("ArreatsWail", 0);
            runeDict.Add("Insanity", 1);
            runeDict.Add("Slaughter", 2);
            runeDict.Add("StridingGiant", 3);
            runeDict.Add("ThriveOnChaos", 4);

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
            skillDict.Add("EarthenMight", SNOPower.X1_Barbarian_Passive_EarthenMight);
            skillDict.Add("Rampage", SNOPower.X1_Barbarian_Passive_Rampage);
            skillDict.Add("SwordAndBoard", SNOPower.X1_Barbarian_Passive_SwordAndBoard);

            // Monk - Primary
            skillDict.Add("FistsOfThunder", SNOPower.Monk_FistsofThunder);
            runeDict.Add("Thunderclap", 0);
            runeDict.Add("WindBlast", 1);
            runeDict.Add("StaticCharge", 2);
            runeDict.Add("Quickening", 3);
            runeDict.Add("BoundingLight", 4);

            skillDict.Add("DeadlyReach", SNOPower.Monk_DeadlyReach);
            runeDict.Add("PiercingTrident", 0);
            runeDict.Add("SearingGrasp", 1);
            runeDict.Add("ScatteredBlows", 2);
            runeDict.Add("StrikeFromBeyond", 3);
            runeDict.Add("Foresight", 4);

            skillDict.Add("CripplingWave", SNOPower.Monk_CripplingWave);
            runeDict.Add("Mangle", 0);
            runeDict.Add("Concussion", 1);
            runeDict.Add("RisingTide", 2);
            runeDict.Add("Tsunami", 3);
            runeDict.Add("BreakingWave", 4);

            skillDict.Add("WayOfTheHundredFists", SNOPower.Monk_WayOfTheHundredFists);
            runeDict.Add("HandsOfLightning", 0);
            runeDict.Add("BlazingFists", 1);
            runeDict.Add("FistsOfFury", 2);
            runeDict.Add("Assimilation", 3);
            runeDict.Add("WindforceFlurry", 4);

            // Monk - Secondary
            skillDict.Add("LashingTailKick", SNOPower.Monk_LashingTailKick);
            runeDict.Add("VultureClawKick", 0);
            runeDict.Add("SweepingArmada", 1);
            runeDict.Add("SpinningFlameKick", 2);
            runeDict.Add("ScorpionSting", 3);
            runeDict.Add("HandOfYtar", 4);

            skillDict.Add("TempestRush", SNOPower.Monk_TempestRush);
            runeDict.Add("NorthernBreeze", 0);
            runeDict.Add("Tailwind", 1);
            runeDict.Add("Flurry", 2);
            runeDict.Add("ElectricField", 3);
            runeDict.Add("Bluster", 4);

            skillDict.Add("WaveOfLight", SNOPower.Monk_WaveOfLight);
            runeDict.Add("WallOfLight", 0);
            runeDict.Add("ExplosiveLight", 1);
            runeDict.Add("EmpoweredWave", 2);
            runeDict.Add("ShatteringLight", 3);
            runeDict.Add("PillarOfTheAncients", 4);

            // Monk - Defensive
            skillDict.Add("BlindingFlash", SNOPower.Monk_BlindingFlash);
            runeDict.Add("SelfReflection", 0);
            runeDict.Add("MystifyingLight", 1);
            runeDict.Add("ReplenishingLight", 2);
            runeDict.Add("SearingLight", 3);
            runeDict.Add("FaithInTheLight", 4);

            skillDict.Add("BreathOfHeaven", SNOPower.Monk_BreathOfHeaven);
            runeDict.Add("CircleOfScorn", 0);
            runeDict.Add("CircleOfLife", 1);
            runeDict.Add("BlazingWrath", 2);
            runeDict.Add("InfusedWithLight", 3);
            runeDict.Add("Zephyr", 4);

            skillDict.Add("Serenity", SNOPower.Monk_Serenity);
            runeDict.Add("PeacefulRepose", 0);
            runeDict.Add("UnwelcomeDisturbance", 1);
            runeDict.Add("Tranquility", 2);
            runeDict.Add("Ascension", 3);
            runeDict.Add("InstantKarma", 4);

            skillDict.Add("InnerSanctuary", SNOPower.X1_Monk_InnerSanctuary);
            runeDict.Add("SanctifiedGround", 0);
            runeDict.Add("SafeHaven", 1);
            runeDict.Add("TempleOfProtection", 2);
            runeDict.Add("Intervene", 3);
            runeDict.Add("ForbiddenPalace", 4);

            // Monk - Techniques
            skillDict.Add("DashingStrike", SNOPower.X1_Monk_DashingStrike);
            runeDict.Add("WayOfTheFallingStar", 0);
            runeDict.Add("BlindingSpeed", 1);
            runeDict.Add("Quicksilver", 2);
            runeDict.Add("Radiance", 3);
            runeDict.Add("Barrage", 4);

            skillDict.Add("ExplodingPalm", SNOPower.Monk_ExplodingPalm);
            runeDict.Add("TheFleshIsWeak", 2);
            runeDict.Add("StrongSpirit", 3);
            runeDict.Add("CreepingDemise", 1);
            runeDict.Add("ImpendingDoom", 0);
            runeDict.Add("EssenceBurn", 4);

            skillDict.Add("SweepingWind", SNOPower.Monk_SweepingWind);
            runeDict.Add("MasterOfWind", 0);
            runeDict.Add("BladeStorm", 1);
            runeDict.Add("FireStorm", 2);
            runeDict.Add("InnerStorm", 3);
            runeDict.Add("Cyclone", 4);

            // Monk - Focus
            skillDict.Add("CycloneStrike", SNOPower.Monk_CycloneStrike);
            runeDict.Add("EyeOfTheStorm", 0);
            runeDict.Add("Implosion", 1);
            runeDict.Add("Sunburst", 2);
            runeDict.Add("WallOfWind", 3);
            runeDict.Add("SoothingBreeze", 4);

            skillDict.Add("SevenSidedStrike", SNOPower.Monk_SevenSidedStrike);
            runeDict.Add("SuddenAssault", 0);
            runeDict.Add("Incinerate", 1);
            runeDict.Add("Pandemonium", 2);
            runeDict.Add("SustainedAttack", 3);
            runeDict.Add("FulinatingOnslaught", 4);

            skillDict.Add("MysticAlly", SNOPower.X1_Monk_MysticAlly_v2);
            runeDict.Add("WaterAlly", 0);
            runeDict.Add("FireAlly", 1);
            runeDict.Add("AirAlly", 2);
            runeDict.Add("EnduringAlly", 3);
            runeDict.Add("EarthAlly", 4);

            skillDict.Add("Epiphany", SNOPower.X1_Monk_Epiphany);
            runeDict.Add("DesertShroud", 0);
            runeDict.Add("Ascendance", 1);
            runeDict.Add("SoothingMist", 2);
            runeDict.Add("Insight", 3);
            runeDict.Add("InnerFire", 4);

            // Monk - Mantras
            skillDict.Add("MantraOfEvasion", SNOPower.X1_Monk_MantraOfEvasion_v2);
            runeDict.Add("HardTarget", 0);
            runeDict.Add("DivineProtection", 1);
            runeDict.Add("WindThroughTheReeds", 2);
            runeDict.Add("Perserverance", 3);
            runeDict.Add("Agility", 4);

            skillDict.Add("MantraOfRetribution", SNOPower.X1_Monk_MantraOfRetribution_v2);
            runeDict.Add("Retaliation", 0);
            runeDict.Add("Transgression", 1);
            runeDict.Add("Indignation", 2);
            runeDict.Add("AgainstAllOdds", 3);
            runeDict.Add("CollateralDamage", 4);

            skillDict.Add("MantraOfHealing", SNOPower.X1_Monk_MantraOfHealing_v2);
            runeDict.Add("Sustenance", 0);
            runeDict.Add("CircularBreathing", 1);
            runeDict.Add("BoonOfInspiration", 2);
            runeDict.Add("HeavenlyBody", 3);
            runeDict.Add("TimeOfNeed", 4);

            skillDict.Add("MantraOfConviction", SNOPower.X1_Monk_MantraOfConviction_v2);
            runeDict.Add("Overawe", 0);
            runeDict.Add("Intimidation", 1);
            runeDict.Add("Dishearten", 2);
            runeDict.Add("Annihilation", 3);
            runeDict.Add("Submission", 4);

            // Monk - Passives
            skillDict.Add("BeaconOfYtar", SNOPower.Monk_Passive_BeaconOfYtar);
            skillDict.Add("ChantOfResonance", SNOPower.Monk_Passive_ChantOfResonance);
            skillDict.Add("CombinationStrike", SNOPower.Monk_Passive_CombinationStrike);
            skillDict.Add("ExaltedSoul", SNOPower.Monk_Passive_ExaltedSoul);
            skillDict.Add("FleetFooted", SNOPower.Monk_Passive_FleetFooted);
            skillDict.Add("GuidingLight", SNOPower.Monk_Passive_GuidingLight);
            skillDict.Add("NearDeathExperience", SNOPower.Monk_Passive_NearDeathExperience);
            skillDict.Add("Resolve", SNOPower.Monk_Passive_Resolve);
            skillDict.Add("SeizeTheInitiative", SNOPower.Monk_Passive_SeizeTheInitiative);
            skillDict.Add("SixthSense", SNOPower.Monk_Passive_SixthSense);
            skillDict.Add("TheGuardiansPath", SNOPower.Monk_Passive_TheGuardiansPath);
            skillDict.Add("Transcendence", SNOPower.Monk_Passive_Transcendence);
            skillDict.Add("Momentum", SNOPower.X1_Monk_Passive_Momentum);
            skillDict.Add("MythicRhythm", SNOPower.X1_Monk_Passive_MythicRhythm);
            skillDict.Add("Unity", SNOPower.X1_Monk_Passive_Unity);
            skillDict.Add("Harmony", SNOPower.p1_Monk_Passive_Harmony);
            skillDict.Add("RelentlessAssault", SNOPower.p1_Monk_Passive_RelentlessAssault);
            skillDict.Add("Provocation", SNOPower.p1_Monk_Passive_Provocation);
         
            // Demon Hunter - Primary
            skillDict.Add("HungeringArrow", SNOPower.DemonHunter_HungeringArrow);
            runeDict.Add("PuncturingArrow", 0);
            runeDict.Add("SerratedArrow", 1);
            runeDict.Add("ShatterShot", 2);
            runeDict.Add("DevouringArrow", 3);
            runeDict.Add("SprayOfTeeth", 4);

            skillDict.Add("EntanglingShot", SNOPower.X1_DemonHunter_EntanglingShot);
            runeDict.Add("ChainGang", 0);
            runeDict.Add("ShockCollar", 1);
            runeDict.Add("HeavyBurden", 2);
            runeDict.Add("JusticeIsServed", 3);
            runeDict.Add("BountyHunter", 4);

            skillDict.Add("Bolas", SNOPower.DemonHunter_Bolas);
            runeDict.Add("VolatileExplosives", 0);
            runeDict.Add("ThunderBall", 1);
            runeDict.Add("FreezingStrike", 2);
            runeDict.Add("BitterPill", 3);
            runeDict.Add("ImminentDoom", 4);

            skillDict.Add("EvasiveFire", SNOPower.X1_DemonHunter_EvasiveFire);
            runeDict.Add("Hardened", 0);
            runeDict.Add("PartingGift", 1);
            runeDict.Add("CoveringFire", 2);
            runeDict.Add("Focus", 3);
            runeDict.Add("Surge", 4);

            skillDict.Add("Grenades", SNOPower.DemonHunter_Grenades);
            runeDict.Add("Tinkerer", 0);
            runeDict.Add("ClusterGrenades", 1);
            runeDict.Add("GrenadeCache", 2);
            runeDict.Add("StunGrenade", 3);
            runeDict.Add("ColdGrenade", 4);

            // Demon Hunter - Secondary
            skillDict.Add("Impale", SNOPower.DemonHunter_Impale);
            runeDict.Add("Impact", 0);
            runeDict.Add("ChemicalBurn", 1);
            runeDict.Add("Overpenetration", 2);
            runeDict.Add("DHRicochet", 3); //duplicate
            runeDict.Add("GrievousWounds", 4);

            skillDict.Add("RapidFire", SNOPower.DemonHunter_RapidFire);
            runeDict.Add("WitheringFire", 0);
            runeDict.Add("FrostShots", 1);
            runeDict.Add("FireSupport", 2);
            runeDict.Add("HighVelocity", 3);
            runeDict.Add("Bombardment", 4);

            skillDict.Add("Chakram", SNOPower.DemonHunter_Chakram);
            runeDict.Add("TwinChakrams", 0);
            runeDict.Add("Serpentine", 1);
            runeDict.Add("RazorDisk", 2);
            runeDict.Add("Boomerang", 3);
            runeDict.Add("ShurikenCloud", 4);

            skillDict.Add("ElementalArrow", SNOPower.DemonHunter_ElementalArrow);
            runeDict.Add("BallLightning", 0);
            runeDict.Add("FrostArrow", 1);
            runeDict.Add("ImmolationArrow", 2);
            runeDict.Add("LightningBolts", 3);
            runeDict.Add("NetherTentacles", 4);

            // Demon Hunter - Defensive
            skillDict.Add("Caltrops", SNOPower.DemonHunter_Caltrops);
            runeDict.Add("HookedSpines", 0);
            runeDict.Add("TorturousGround", 1);
            runeDict.Add("JaggedSpikes", 2);
            runeDict.Add("CarvedStakes", 3);
            runeDict.Add("BaitTheTrap", 4);

            skillDict.Add("SmokeScreen", SNOPower.DemonHunter_SmokeScreen);
            runeDict.Add("Displacement", 0);
            runeDict.Add("LingeringFog", 1);
            runeDict.Add("HealingVapors", 2);
            runeDict.Add("SpecialRecipe", 3);
            runeDict.Add("VanishingPowder", 4);

            skillDict.Add("ShadowPower", SNOPower.DemonHunter_ShadowPower);
            runeDict.Add("NightBane", 0);
            runeDict.Add("BloodMoon", 1);
            runeDict.Add("WellOfDarkness", 2);
            runeDict.Add("Gloom", 3);
            runeDict.Add("ShadowGlide", 4);

            // Demon Hunter - Hunting
            skillDict.Add("Vault", SNOPower.DemonHunter_Vault);
            runeDict.Add("ActionShot", 0);
            runeDict.Add("RattlingRoll", 1);
            runeDict.Add("Tumble", 2);
            runeDict.Add("Acrobatics", 3);
            runeDict.Add("TrailOfCinders", 4);

            skillDict.Add("Preparation", SNOPower.DemonHunter_Preparation);
            runeDict.Add("Invigoration", 0);
            runeDict.Add("Punishment", 1);
            runeDict.Add("BattleScars", 2);
            runeDict.Add("FocusedMind", 3);
            runeDict.Add("BackupPlan", 4);

            skillDict.Add("Companion", SNOPower.X1_DemonHunter_Companion);
            runeDict.Add("SpiderCompanion", 0);
            runeDict.Add("BatCompanion", 1);
            runeDict.Add("BoarCompanion", 2);
            runeDict.Add("FerretCompanion", 3);
            runeDict.Add("WolfCompanion", 4);

            skillDict.Add("MarkedForDeath", SNOPower.DemonHunter_MarkedForDeath);
            runeDict.Add("Contagion", 0);
            runeDict.Add("ValleyOfDeath", 1);
            runeDict.Add("GrimReaper", 2);
            runeDict.Add("MortalEnemy", 3);
            runeDict.Add("DeathToll", 4);

            // Demon Hunter - Devices
            skillDict.Add("FanOfKnives", SNOPower.DemonHunter_FanOfKnives);
            runeDict.Add("PinpointAccuracy", 0);
            runeDict.Add("BladedArmor", 1);
            runeDict.Add("KnivesExpert", 2);
            runeDict.Add("FanOfDaggers", 3);
            runeDict.Add("AssassinsKnives", 4);

            skillDict.Add("SpikeTrap", SNOPower.DemonHunter_SpikeTrap);
            runeDict.Add("EchoingBlast", 0);
            runeDict.Add("StickyTrap", 1);
            runeDict.Add("LongFuse", 2);
            runeDict.Add("LightningRod", 3);
            runeDict.Add("Scatter", 4);

            skillDict.Add("Sentry", SNOPower.DemonHunter_Sentry);
            runeDict.Add("SpitfireTurret", 0);
            runeDict.Add("ImpalingBolt", 1);
            runeDict.Add("ChainOfTorment", 2);
            runeDict.Add("PolarStation", 3);
            runeDict.Add("GuardianTurret", 4);

            skillDict.Add("Vengeance", SNOPower.X1_DemonHunter_Vengeance);
            runeDict.Add("PersonalMortor", 0);
            runeDict.Add("DarkHeart", 1);
            runeDict.Add("SideCannons", 2);
            runeDict.Add("Seethe", 3);
            runeDict.Add("FromTheShadows", 4);

            // Demon Hunter - Archery
            skillDict.Add("Strafe", SNOPower.DemonHunter_Strafe);
            runeDict.Add("IcyTrail", 0);
            runeDict.Add("DriftingShadow", 1);
            runeDict.Add("StingingSteel", 2);
            runeDict.Add("RocketStorm", 3);
            runeDict.Add("Demolition", 4);

            skillDict.Add("Multishot", SNOPower.DemonHunter_Multishot);
            runeDict.Add("FireAtWill", 0);
            runeDict.Add("BurstFire", 1);
            runeDict.Add("SuppressionFire", 2);
            runeDict.Add("FullBroadside", 3);
            runeDict.Add("Arsenal", 4);

            skillDict.Add("ClusterArrow", SNOPower.DemonHunter_ClusterArrow);
            runeDict.Add("DazzlingArrow", 0);
            runeDict.Add("ShootingStars", 1);
            runeDict.Add("Maelstrom", 2);
            runeDict.Add("ClusterBombs", 3);
            runeDict.Add("LoadedForBear", 4);

            skillDict.Add("RainOfVengeance", SNOPower.DemonHunter_RainOfVengeance);
            runeDict.Add("DarkCloud", 0);
            runeDict.Add("Shade", 1);
            runeDict.Add("Stampede", 2);
            runeDict.Add("Anathema", 3);
            runeDict.Add("FlyingStrike", 4);

            // Demon Hunter - Passives
            skillDict.Add("ThrillOfTheHunt", SNOPower.DemonHunter_Passive_ThrillOfTheHunt);
            skillDict.Add("TacticalAdvantage", SNOPower.DemonHunter_Passive_TacticalAdvantage);
            skillDict.Add("BloodVengeance", SNOPower.DemonHunter_Passive_Vengeance);
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
            skillDict.Add("Ambush", SNOPower.X1_DemonHunter_Passive_Ambush);
            skillDict.Add("Awareness", SNOPower.X1_DemonHunter_Passive_Awareness);
            skillDict.Add("SingleOut", SNOPower.X1_DemonHunter_Passive_SingleOut);

            // Witch Doctor - Primary
            skillDict.Add("PoisonDart", SNOPower.Witchdoctor_PoisonDart);
            runeDict.Add("Splinters", 0);
            runeDict.Add("NumbingDart", 1);
            runeDict.Add("SpinedDart", 2);
            runeDict.Add("FlamingDart", 3);
            runeDict.Add("SnakeToTheFace", 4);

            skillDict.Add("CorpseSpiders", SNOPower.Witchdoctor_CorpseSpider);
            runeDict.Add("LeapingSpiders", 0);
            runeDict.Add("SpiderQueen", 1);
            runeDict.Add("Widowmakers", 2);
            runeDict.Add("MedusaSpiders", 3);
            runeDict.Add("BlazingSpiders", 4);

            skillDict.Add("PlagueOfToads", SNOPower.Witchdoctor_PlagueOfToads);
            runeDict.Add("ExplosiveToads", 0);
            runeDict.Add("PiercingToads", 1);
            runeDict.Add("RainOfToads", 2);
            runeDict.Add("AddlingToads", 3);
            runeDict.Add("ToadAffinity", 4);

            skillDict.Add("Firebomb", SNOPower.Witchdoctor_Firebomb);
            runeDict.Add("FlashFire", 0);
            runeDict.Add("RollTheBones", 1);
            runeDict.Add("FirePit", 2);
            runeDict.Add("Pyrogeist", 3);
            runeDict.Add("GhostBomb", 4);

            // Witch Doctor - Secondary
            skillDict.Add("GraspOfTheDead", SNOPower.Witchdoctor_GraspOfTheDead);
            runeDict.Add("UnbreakableGrasp", 0);
            runeDict.Add("GropingEels", 1);
            runeDict.Add("DeathIsLife", 2);
            runeDict.Add("DesperateGrasp", 3);
            runeDict.Add("RainOfCorpses", 4);

            skillDict.Add("Firebats", SNOPower.Witchdoctor_Firebats);
            runeDict.Add("DireBats", 0);
            runeDict.Add("VampireBats", 1);
            runeDict.Add("PlagueBats", 2);
            runeDict.Add("HungryBats", 3);
            runeDict.Add("CloudOfBats", 4);

            skillDict.Add("Haunt", SNOPower.Witchdoctor_Haunt);
            runeDict.Add("ConsumingSpirit", 0);
            runeDict.Add("ResentfulSpirits", 1);
            runeDict.Add("LingeringSpirit", 2);
            runeDict.Add("PoisonedSpirit", 3);
            runeDict.Add("DrainingSpirit", 4);

            skillDict.Add("LocustSwarm", SNOPower.Witchdoctor_Locust_Swarm);
            runeDict.Add("Pestilence", 0);
            runeDict.Add("DevouringSwarm", 1);
            runeDict.Add("CloudOfInsects", 2);
            runeDict.Add("DiseasedSwarm", 3);
            runeDict.Add("SearingLocusts", 4);

            // Witch Doctor - Defensive
            skillDict.Add("SummonZombieDogs", SNOPower.Witchdoctor_SummonZombieDog);
            runeDict.Add("RabidDogs", 0);
            runeDict.Add("FinalGift", 1);
            runeDict.Add("LifeLink", 2);
            runeDict.Add("BurningDogs", 3);
            runeDict.Add("LeechingBeasts", 4);

            skillDict.Add("Horrify", SNOPower.Witchdoctor_Horrify);
            runeDict.Add("Phobia", 0);
            runeDict.Add("Stalker", 1);
            runeDict.Add("FaceOfDeath", 2);
            runeDict.Add("FrighteningAspect", 3);
            runeDict.Add("RuthlessTerror", 4);

            skillDict.Add("SpiritWalk", SNOPower.Witchdoctor_SpiritWalk);
            runeDict.Add("Jaunt", 0);
            runeDict.Add("HonoredGuest", 1);
            runeDict.Add("UmbralShock", 2);
            runeDict.Add("Severance", 3);
            runeDict.Add("HealingJourney", 4);

            skillDict.Add("Hex", SNOPower.Witchdoctor_Hex);
            runeDict.Add("HedgeMagic", 0);
            runeDict.Add("Jinx", 1);
            runeDict.Add("AngryChicken", 2);
            runeDict.Add("ToadOfHugeness", 3);
            runeDict.Add("UnstableForm", 4);

            // Witch Doctor - Terror
            skillDict.Add("SoulHarvest", SNOPower.Witchdoctor_SoulHarvest);
            runeDict.Add("SwallowYourSoul", 0);
            runeDict.Add("Siphon", 1);
            runeDict.Add("Languish", 2);
            runeDict.Add("SoulToWaste", 3);
            runeDict.Add("VengefulSpirit", 4);

            skillDict.Add("Sacrifice", SNOPower.Witchdoctor_Sacrifice);
            runeDict.Add("BlackBlood", 0);
            runeDict.Add("NextOfKin", 1);
            runeDict.Add("Pride", 2);
            runeDict.Add("ForTheMaster", 3);
            runeDict.Add("ProvokeThePack", 4);

            skillDict.Add("MassConfusion", SNOPower.Witchdoctor_MassConfusion);
            runeDict.Add("UnstableRealm", 0);
            runeDict.Add("Devolution", 1);
            runeDict.Add("MassHysteria", 2);
            runeDict.Add("Paranoia", 3);
            runeDict.Add("MassHallucination", 4);

            // Witch Doctor - Decay
            skillDict.Add("ZombieCharger", SNOPower.Witchdoctor_ZombieCharger);
            runeDict.Add("PileOn", 0);
            runeDict.Add("Undeath", 1);
            runeDict.Add("LumberingCold", 2);
            runeDict.Add("ExplosiveBeast", 3);
            runeDict.Add("ZombieBears", 4);

            skillDict.Add("SpiritBarage", SNOPower.Witchdoctor_SpiritBarrage);
            runeDict.Add("TheSpiritIsWilling", 0);
            runeDict.Add("WellOfSouls", 1);
            runeDict.Add("Phantasm", 2);
            runeDict.Add("Phlebotomize", 3);
            runeDict.Add("Manitou", 4);

            skillDict.Add("AcidCloud", SNOPower.Witchdoctor_AcidCloud);
            runeDict.Add("AcidRain", 0);
            runeDict.Add("LobBlobBomb", 1);
            runeDict.Add("SlowBurn", 2);
            runeDict.Add("KissOfDeath", 3);
            runeDict.Add("CorpseBomb", 4);

            skillDict.Add("WallOfZombies", SNOPower.Witchdoctor_WallOfZombies);
            runeDict.Add("Barricade", 0);
            runeDict.Add("UnrelentingGrip", 1);
            runeDict.Add("Creepers", 2);
            runeDict.Add("WreckingCrew", 3);
            runeDict.Add("OffensiveLine", 4);

            // Witch Doctor - Voodoo
            skillDict.Add("Gargantuan", SNOPower.Witchdoctor_Gargantuan);
            runeDict.Add("Humongoid", 0);
            runeDict.Add("RestlessGiant", 1);
            runeDict.Add("WrathfulProtector", 2);
            runeDict.Add("BigStinker", 3);
            runeDict.Add("Bruiser", 4);

            skillDict.Add("BigBadVoodoo", SNOPower.Witchdoctor_BigBadVoodoo);
            runeDict.Add("JungleDrums", 0);
            runeDict.Add("RainDance", 1);
            runeDict.Add("SlamDance", 2);
            runeDict.Add("GhostTrance", 3);
            runeDict.Add("BoogieMan", 4);

            skillDict.Add("FetishArmy", SNOPower.Witchdoctor_FetishArmy);
            runeDict.Add("FetishAmbush", 0);
            runeDict.Add("DevotedFollowing", 1);
            runeDict.Add("LegionOfDaggers", 2);
            runeDict.Add("TikiTorchers", 3);
            runeDict.Add("HeadHunters", 4);

            // Witch Doctor - Passives
            skillDict.Add("JungleFortitude", SNOPower.Witchdoctor_Passive_JungleFortitude);
            skillDict.Add("CircleOfLife", SNOPower.Witchdoctor_Passive_CircleOfLife);
            skillDict.Add("CreepingDeath", SNOPower.Witchdoctor_Passive_CreepingDeath);
            skillDict.Add("SpiritualAttunement", SNOPower.Witchdoctor_Passive_SpiritualAttunement);
            skillDict.Add("MidnightFeast", SNOPower.Witchdoctor_Passive_MidnightFeast);
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
            skillDict.Add("PhysicalAttunement", SNOPower.Witchdoctor_Passive_PhysicalAttunement);
            skillDict.Add("TribalRites", SNOPower.Witchdoctor_Passive_TribalRites);

            // Wizard - Primary
            skillDict.Add("MagicMissile", SNOPower.Wizard_MagicMissile);
            runeDict.Add("ChargedBlast", 0);
            runeDict.Add("GlacialSpike", 1);
            runeDict.Add("Split", 2);
            runeDict.Add("Seeker", 3);
            runeDict.Add("Conflagrate", 4);

            skillDict.Add("ShockPulse", SNOPower.Wizard_ShockPulse);
            runeDict.Add("ExplosiveBolts", 0);
            runeDict.Add("FireBolts", 1);
            runeDict.Add("PiercingOrb", 2);
            runeDict.Add("PowerAffinity", 3);
            runeDict.Add("LivingLightning", 4);

            skillDict.Add("SpectralBlade", SNOPower.Wizard_SpectralBlade);
            runeDict.Add("FlameBlades", 0);
            runeDict.Add("SiphoningBlade", 1);
            runeDict.Add("ThrownBlade", 2);
            runeDict.Add("BarrierBlades", 3);
            runeDict.Add("IceBlades", 4);

            skillDict.Add("Electrocute", SNOPower.Wizard_Electrocute);
            runeDict.Add("ChainLightning", 0);
            runeDict.Add("ForkedLightning", 1);
            runeDict.Add("LightningBlast", 2);
            runeDict.Add("SurgeOfPower", 3);
            runeDict.Add("ArcLightning", 4);

            // Wizard - Secondary
            skillDict.Add("RayOfFrost", SNOPower.Wizard_RayOfFrost);
            runeDict.Add("ColdBlood", 0);
            runeDict.Add("Numb", 1);
            runeDict.Add("BlackIce", 2);
            runeDict.Add("SleetStorm", 3);
            runeDict.Add("SnowBlast", 4);

            skillDict.Add("ArcaneOrb", SNOPower.Wizard_ArcaneOrb);
            runeDict.Add("Obliteration", 0);
            runeDict.Add("ArcaneOrbit", 1);
            runeDict.Add("Spark", 2);
            runeDict.Add("Scorch", 3);
            runeDict.Add("FrozenOrb", 4);

            skillDict.Add("ArcaneTorrent", SNOPower.Wizard_ArcaneTorrent);
            runeDict.Add("FlameWard", 0);
            runeDict.Add("DeathBlossom", 1);
            runeDict.Add("ArcaneMines", 2);
            runeDict.Add("StaticDischarge", 3);
            runeDict.Add("Cascade", 4);

            skillDict.Add("Disintegrate", SNOPower.Wizard_Disintegrate);
            runeDict.Add("Convergence", 0);
            runeDict.Add("Volatility", 1);
            runeDict.Add("Entropy", 2);
            runeDict.Add("ChaosNexus", 3);
            runeDict.Add("Intensify", 4);

            // Wizard - Defensive
            skillDict.Add("FrostNova", SNOPower.Wizard_FrostNova);
            runeDict.Add("Shatter", 0);
            runeDict.Add("ColdSnap", 1);
            runeDict.Add("FrozenMist", 2);
            runeDict.Add("DeepFreeze", 3);
            runeDict.Add("BoneChill", 4);

            skillDict.Add("DiamondSkin", SNOPower.Wizard_DiamondSkin);
            runeDict.Add("CrystalShell", 0);
            runeDict.Add("Prism", 1);
            runeDict.Add("SleekShell", 2);
            runeDict.Add("EnduringSkin", 3);
            runeDict.Add("DiamondShards", 4);

            skillDict.Add("SlowTime", SNOPower.Wizard_SlowTime);
            runeDict.Add("TimeShell", 0);
            runeDict.Add("TimeAndSpace", 1);
            runeDict.Add("TimeWarp", 2);
            runeDict.Add("PointOfNoReturn", 3);
            runeDict.Add("StretchTime", 4);

            skillDict.Add("Teleport", SNOPower.Wizard_Teleport);
            runeDict.Add("SafePassage", 0);
            runeDict.Add("Wormhole", 1);
            runeDict.Add("Reversal", 2);
            runeDict.Add("Fracture", 3);
            runeDict.Add("Calamity", 4);

            // Wizard - Force
            skillDict.Add("WaveOfForce", SNOPower.Wizard_WaveOfForce);
            runeDict.Add("ImpactfulWave", 0);
            runeDict.Add("DebilitatingForce", 1);
            runeDict.Add("ArcaneAttunement", 2);
            runeDict.Add("StaticPulse", 3);
            runeDict.Add("HeatWave", 4);

            skillDict.Add("EnergyTwister", SNOPower.Wizard_EnergyTwister);
            runeDict.Add("MistralBreeze", 0);
            runeDict.Add("GaleForce", 1);
            runeDict.Add("RagingStorm", 2);
            runeDict.Add("WickedWind", 3);
            runeDict.Add("StormChaser", 4);

            skillDict.Add("Hydra", SNOPower.Wizard_Hydra);
            runeDict.Add("ArcaneHydra", 0);
            runeDict.Add("LightningHydra", 1);
            runeDict.Add("BlazingHydra", 2);
            runeDict.Add("FrostHydra", 3);
            runeDict.Add("MammothHydra", 4);

            skillDict.Add("Meteor", SNOPower.Wizard_Meteor);
            runeDict.Add("ThunderCrash", 0);
            runeDict.Add("StarPact", 1);
            runeDict.Add("Comet", 2);
            runeDict.Add("MeteorShower", 3);
            runeDict.Add("MoltenImpact", 4);

            skillDict.Add("Blizzard", SNOPower.Wizard_Blizzard);
            runeDict.Add("LightningStorm", 0);
            runeDict.Add("FrozenSolid", 1);
            runeDict.Add("Snowbound", 2);
            runeDict.Add("Apocalypse", 3);
            runeDict.Add("UnrelentingStorm", 4);

            // Wizard - Conjuration
            skillDict.Add("IceArmor", SNOPower.Wizard_IceArmor);
            runeDict.Add("ChillingAura", 0);
            runeDict.Add("Crystallize", 1);
            runeDict.Add("JaggedIce", 2);
            runeDict.Add("IceReflect", 3);
            runeDict.Add("FrozenStorm", 4);

            skillDict.Add("StormArmor", SNOPower.Wizard_StormArmor);
            runeDict.Add("ReactiveArmor", 0);
            runeDict.Add("PowerOfTheStorm", 1);
            runeDict.Add("ThunderStorm", 2);
            runeDict.Add("Scramble", 3);
            runeDict.Add("ShockingAspect", 4);

            skillDict.Add("MagicWeapon", SNOPower.Wizard_MagicWeapon);
            runeDict.Add("Electrify", 0);
            runeDict.Add("ForceWeapon", 1);
            runeDict.Add("Conduit", 2);
            runeDict.Add("Ignite", 3);
            runeDict.Add("Deflection", 4);

            skillDict.Add("Familiar", SNOPower.Wizard_Familiar);
            runeDict.Add("Sparkflint", 0);
            runeDict.Add("Icicle", 1);
            runeDict.Add("AncientGuardian", 2);
            runeDict.Add("Arcanot", 3);
            runeDict.Add("Cannoneer", 4);

            skillDict.Add("EnergyArmor", SNOPower.Wizard_EnergyArmor);
            runeDict.Add("Absorption", 0);
            runeDict.Add("PinpointBarrier", 1);
            runeDict.Add("EnergyTap", 2);
            runeDict.Add("ForceArmor", 3);
            runeDict.Add("PrismaticArmor", 4);

            // Wizard - Mastery
            skillDict.Add("ExplosiveBlast", SNOPower.Wizard_ExplosiveBlast);
            runeDict.Add("Unleashed", 0);
            runeDict.Add("Flash", 1);
            runeDict.Add("ShortFuse", 2);
            runeDict.Add("Obliterate", 3);
            runeDict.Add("ChainReaction", 4);

            skillDict.Add("MirrorImage", SNOPower.Wizard_MirrorImage);
            runeDict.Add("Simulacrum", 0);
            runeDict.Add("Duplicates", 1);
            runeDict.Add("MockingDemise", 2);
            runeDict.Add("ExtensionOfWill", 3);
            runeDict.Add("MirrorMimics", 4);

            skillDict.Add("Archon", SNOPower.Wizard_Archon);
            runeDict.Add("Combustion", 0);
            runeDict.Add("Teleport", 1);
            runeDict.Add("PurePower", 2);
            runeDict.Add("SlowTime", 3);
            runeDict.Add("ImprovedArchon", 4);

            /*skillDict.Add("BlackHole", SNOPower.X1_Wizard_BlackHole);
            runeDict.Add("Supermassive", 0);
            runeDict.Add("AbsoluteZero", 1);
            runeDict.Add("EventHorizon", 2);
            runeDict.Add("Blazar", 3);
            runeDict.Add("Spellsteal", 4);*/

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
            skillDict.Add("ArcaneDynamo", SNOPower.Wizard_Passive_ArcaneDynamo);
            skillDict.Add("UnstableAnomaly", SNOPower.Wizard_Passive_UnstableAnomaly);
            skillDict.Add("ArcaneAegis", SNOPower.x1_Wizard_Passive_ArcaneAegis);
            skillDict.Add("Audacity", SNOPower.X1_Wizard_Passive_Audacity);
            skillDict.Add("ElementalExposure", SNOPower.X1_Wizard_Passive_ElementalExposure);
            skillDict.Add("UnwaveringWill", SNOPower.X1_Wizard_Passive_UnwaveringWill);

            //Crusader - Primary
            skillDict.Add("Punish", SNOPower.X1_Crusader_Punish);
            runeDict.Add("Roar", 0);
            runeDict.Add("Celerity", 1);
            runeDict.Add("Rebirth", 2);
            runeDict.Add("Retaliate", 3);
            runeDict.Add("Fury", 4);

            skillDict.Add("Slash", SNOPower.X1_Crusader_Slash);
            runeDict.Add("CElectrify", 0); //duplicate
            runeDict.Add("Carve", 1);
            runeDict.Add("Crush", 2);
            runeDict.Add("Zeal", 3);
            runeDict.Add("Guard", 4);

            skillDict.Add("Smite", SNOPower.X1_Crusader_Smite);
            runeDict.Add("CShatter", 0); //duplicate
            runeDict.Add("Shackle", 1);
            runeDict.Add("CSurge", 2);  //duplicate
            runeDict.Add("Reaping", 3);
            runeDict.Add("SharedFate", 4);

            skillDict.Add("Justice", SNOPower.X1_Crusader_Justice);
            runeDict.Add("Burst", 0);
            runeDict.Add("Crack", 1);
            runeDict.Add("HammerOfPursuit", 2);
            runeDict.Add("SwordOfJustice", 3);
            runeDict.Add("HolyBolt", 4);

            //Crusader - Secondaries
            skillDict.Add("ShieldBash", SNOPower.X1_Crusader_ShieldBash2);
            runeDict.Add("ShatteredShield", 0);
            runeDict.Add("OneOnOne", 1);
            runeDict.Add("ShieldCross", 2);
            runeDict.Add("Crumble", 3);
            runeDict.Add("Pound", 4);

            skillDict.Add("SweepAttack", SNOPower.X1_Crusader_SweepAttack);
            runeDict.Add("BlazingSweep", 0);
            runeDict.Add("TripAttack", 1);
            runeDict.Add("HolyShock", 2);
            runeDict.Add("GatheringSweep", 3);
            runeDict.Add("FrozenSweep", 4);

            skillDict.Add("BlessedHammer", SNOPower.X1_Crusader_BlessedHammer);
            runeDict.Add("BurningWrath", 0);
            runeDict.Add("Thunderstruck", 1);
            runeDict.Add("Limitless", 2);
            runeDict.Add("IceboundHammer", 3);
            runeDict.Add("Domination", 4);

            skillDict.Add("BlessedShield", SNOPower.X1_Crusader_BlessedShield);
            runeDict.Add("StaggeringShield", 0);
            runeDict.Add("Combust", 1);
            runeDict.Add("DivineAegis", 2);
            runeDict.Add("ShatteringThrow", 3);
            runeDict.Add("PiercingShield", 4);

            skillDict.Add("FistOfTheHeavens", SNOPower.X1_Crusader_FistOfTheHeavens);
            runeDict.Add("DivineWell", 0);
            runeDict.Add("HeavensTempest", 1);
            runeDict.Add("Fissure", 2);
            runeDict.Add("Reverberation", 3);
            runeDict.Add("CRetribution", 4); //duplicate

            //Crusader - Defensive
            skillDict.Add("ShieldGlare", SNOPower.X1_Crusader_ShieldGlare);
            runeDict.Add("DivineVerdict", 0);
            runeDict.Add("Uncertainty", 1);
            runeDict.Add("ZealousGlare", 2);
            runeDict.Add("EmblazonedShield", 3);
            runeDict.Add("Subdue", 4);

            skillDict.Add("IronSkin", SNOPower.X1_Crusader_IronSkin);
            runeDict.Add("ReflectiveSkin", 0);
            runeDict.Add("SteelSkin", 1);
            runeDict.Add("ExplosiveSkin", 2);
            runeDict.Add("ChargedUp", 3);
            runeDict.Add("CFlash", 4);   //duplicate

            skillDict.Add("Consecration", SNOPower.X1_Crusader_Consecration);
            runeDict.Add("BathedInLight", 0);
            runeDict.Add("FrozenGround", 1);
            runeDict.Add("AegisPurgatory", 2);
            runeDict.Add("CShatteredGround", 3); //duplicate
            runeDict.Add("Fearful", 4);

            skillDict.Add("Judgement", SNOPower.X1_Crusader_Judgment);
            runeDict.Add("Penitence", 0);
            runeDict.Add("MassVerdict", 1);
            runeDict.Add("Deliberation", 2);
            runeDict.Add("Resolved", 3);
            runeDict.Add("Conversion", 4);

            //Crusader - Utility
            skillDict.Add("Provoke", SNOPower.X1_Crusader_Provoke);
            runeDict.Add("Cleanse", 0);
            runeDict.Add("FleeFool", 1);
            runeDict.Add("TooScaredToRun", 2);
            runeDict.Add("CChargedUp", 3); //duplicate
            runeDict.Add("HitMe", 4);

            skillDict.Add("SteedCharge", SNOPower.X1_Crusader_SteedCharge);
            runeDict.Add("RammingSpeed", 0);
            runeDict.Add("Nightmare", 1);
            runeDict.Add("Rejuvenation", 2);
            runeDict.Add("Endurance", 3);
            runeDict.Add("DrawAndQuarter", 4);

            skillDict.Add("Condemn", SNOPower.X1_Crusader_Condemn);
            runeDict.Add("Vacuum", 0);
            runeDict.Add("CUnleashed", 1);   //duplicate
            runeDict.Add("EternalRetaliation", 2);
            runeDict.Add("ShatteringExplosion", 3);
            runeDict.Add("Reciprocate", 4);

            skillDict.Add("Phalanx", SNOPower.x1_Crusader_Phalanx3);
            runeDict.Add("Bowmen", 0);
            runeDict.Add("CShieldCharge", 1);    //duplicate
            runeDict.Add("CStampede", 2);    //duplicate
            runeDict.Add("ShieldBracers", 3);
            runeDict.Add("Bodyguard", 4);

            //Crusader - Laws
            skillDict.Add("LawsOfValor", SNOPower.X1_Crusader_LawsOfValor);
            runeDict.Add("Invincible", 0);
            runeDict.Add("FrozenInTerror", 1);
            runeDict.Add("Critical", 2);
            runeDict.Add("UnstoppableForce", 3);
            runeDict.Add("AnsweredPrayer", 4);

            skillDict.Add("LawsOfJustice", SNOPower.X1_Crusader_LawsOfJustice);
            runeDict.Add("ProtectTheInnocent", 0);
            runeDict.Add("ImmovableObject", 1);
            runeDict.Add("FaithsArmor", 2);
            runeDict.Add("DecayingStrength", 3);
            runeDict.Add("Bravery", 4);

            skillDict.Add("LawsOfHope", SNOPower.X1_Crusader_LawsOfHope);
            runeDict.Add("WingsOfAngels", 0);
            runeDict.Add("EternalHope", 1);
            runeDict.Add("HopefulCry", 2);
            runeDict.Add("FaithsReward", 3);
            runeDict.Add("StopTime", 4);

            //Crusader - Conviction
            skillDict.Add("FallingSword", SNOPower.X1_Crusader_FallingSword);
            runeDict.Add("Superheated", 0);
            runeDict.Add("PartTheClouds", 1);
            runeDict.Add("RiseBrothers", 2);
            runeDict.Add("RapidDescent", 3);
            runeDict.Add("CFlurry", 4);  //duplicate

            skillDict.Add("AkaratsChampion", SNOPower.X1_Crusader_AkaratsChampion);
            runeDict.Add("FireStarter", 0);
            runeDict.Add("EmbodimentOfPower", 1);
            runeDict.Add("Rally", 2);
            runeDict.Add("Prophet", 3);
            runeDict.Add("Hasteful", 4);

            skillDict.Add("HeavensFury", SNOPower.X1_Crusader_HeavensFury3);
            runeDict.Add("BlessedGround", 0);
            runeDict.Add("Ascendancy", 1);
            runeDict.Add("SplitFury", 2);
            runeDict.Add("ThouShaltNotPass", 3);
            runeDict.Add("FiresOfHeaven", 4);

            skillDict.Add("Bombardment", SNOPower.X1_Crusader_IronSkin);
            runeDict.Add("BarrelsOfTar", 0);
            runeDict.Add("Annihilate", 1);
            runeDict.Add("MineField", 2);
            runeDict.Add("ImpactfulBombardment", 3);
            runeDict.Add("Targeted", 4);

            //Crusader - Passives
            skillDict.Add("HeavenlyStrength", SNOPower.X1_Crusader_Passive_HeavenlyStrength);
            skillDict.Add("Fervor", SNOPower.X1_Crusader_Passive_Fervor);
            skillDict.Add("Vigilant", SNOPower.X1_Crusader_Passive_Vigilant);
            skillDict.Add("Righteousness", SNOPower.X1_Crusader_Passive_Righteousness);
            skillDict.Add("Insurmountable", SNOPower.X1_Crusader_Passive_Insurmountable);
            skillDict.Add("NephalemMajesty", SNOPower.X1_Crusader_Passive_NephalemMajesty);
            skillDict.Add("Indestructible", SNOPower.X1_Crusader_Passive_Indestructible);
            skillDict.Add("HolyCause", SNOPower.X1_Crusader_Passive_HolyCause);
            skillDict.Add("Wrathful", SNOPower.X1_Crusader_Passive_Wrathful);
            skillDict.Add("DivineFortress", SNOPower.X1_Crusader_Passive_DivineFortress);
            skillDict.Add("LordCommander", SNOPower.X1_Crusader_Passive_LordCommander);
            skillDict.Add("HoldYourGround", SNOPower.X1_Crusader_Passive_HoldYourGround);
            skillDict.Add("LongArmOfTheLaw", SNOPower.X1_Crusader_Passive_LongArmOfTheLaw);
            skillDict.Add("IronMaiden", SNOPower.X1_Crusader_Passive_IronMaiden);
            skillDict.Add("Renewal", SNOPower.X1_Crusader_Passive_Renewal);
            skillDict.Add("Finery", SNOPower.X1_Crusader_Passive_Finery);
            skillDict.Add("Blunt", SNOPower.X1_Crusader_Passive_Blunt);
            skillDict.Add("ToweringShield", SNOPower.X1_Crusader_Passive_ToweringShield);
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
