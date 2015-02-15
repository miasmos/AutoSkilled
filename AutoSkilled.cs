using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

using Zeta;
using Zeta.Common;
using Zeta.Common.Plugins;
using Zeta.Bot;
using Zeta.Game;
using Zeta.Game.Internals;
using Zeta.Common.Helpers;
using System.IO;

namespace AutoSkilled
{
    partial class AutoSkilled : IPlugin
    {
        // Plugin info
        public string Author { get { return "Tinnvec & lii"; } }
        public string Description { get { return "AutoSkilled does exactly what it sounds like it does, automatically sets skills as you level"; } }
        public string Name { get { return "AutoSkilled"; } }
        public Version Version { get { return new Version(0, 6); } }
        public Window DisplayWindow { get { return null; } }

        // Properties
        private string BuildName;
        private string BuildClass;
        private Skill[][] BuildArray = new Skill[71][];
        private List<Skill> SkillEquipQueue = new List<Skill>();

        private WaitTimer LevelUpTimer = WaitTimer.FiveSeconds;
        private WaitTimer SetSkillTimer = WaitTimer.OneSecond;

        private static readonly log4net.ILog Logging = Logger.GetLoggerInstanceForType();

        // Initialize event method
        public void OnInitialize() {
            Log("Initialized");
        }

        // Enabled event method
        public void OnEnabled() {
            // LevelUp Event needs to trigger method
            GameEvents.OnLevelUp += DoLevelUp;

            // Get leveling setup info
            ParseBuildFile();
        }

        // Pulse event method
        public void OnPulse() {
            // Wait some more if our timers are still going
            if (!LevelUpTimer.IsFinished || !SetSkillTimer.IsFinished) {
                return;
            }

            // Don't do anything if we're dead or switching worlds
            if (!ZetaDia.IsInGame || !Zeta.Game.ZetaDia.Me.IsValid || !ZetaDia.CPlayer.IsValid || Zeta.Game.ZetaDia.Me.IsDead || ZetaDia.IsLoadingWorld)
            {
                return;
            }

            // Don't do anything if we're in combat
            if (Zeta.Game.ZetaDia.Me.IsInCombat)
            {
                return;
            }

            if(SkillEquipQueue.Count > 0) {
                Skill skillToEquip = SkillEquipQueue[0];
                if (skillToEquip.activate()) {
                    Log(skillToEquip.getSnoPower().ToString() + "(" + skillToEquip.getRuneId() + ") has been set");
                    // Remove it from list
                    SkillEquipQueue.Remove(skillToEquip);
                }
                SetSkillTimer.Reset();
            }
        }

        // Disabled event method
        public void OnDisabled() {
            // Remove Level up event
            GameEvents.OnLevelUp -= DoLevelUp;
            Log("Disabled");
        }

        // Shutdown event Method
        public void OnShutdown() {
            // Unused
        }

        // Level up event method
        public void DoLevelUp(object sender, EventArgs e) {
            LevelUpTimer.Reset();
            int CurrentLevel = Zeta.Game.ZetaDia.Me.Level;
            if(BuildArray[CurrentLevel] != null) {
                foreach(Skill LevelSkill in BuildArray[CurrentLevel]) {
                    SkillEquipQueue.Add(LevelSkill);
                }
            }
        }

        // Logging method
        public void Log(string message) {
            Logging.Notice(string.Format("[{0}] {1}", Name, message));
        }

        public bool Equals(IPlugin other) {
            return (other.Name == Name) && (other.Version == Version);
        }

        // Parse build file method
        public void ParseBuildFile() {
            Dictionary<string, ActorClass> classDict = new Dictionary<string, ActorClass>();
            classDict.Add("Barbarian", ActorClass.Barbarian);
            classDict.Add("DemonHunter", ActorClass.DemonHunter);
            classDict.Add("Monk", ActorClass.Monk);
            classDict.Add("WitchDoctor", ActorClass.Witchdoctor);
            classDict.Add("Wizard", ActorClass.Wizard);
            classDict.Add("Crusader", ActorClass.Crusader);

            XmlDocument BuildFile = new XmlDocument();


            // Get build file
            string[] buildPaths = Directory.GetFiles(@"Plugins\AutoSkilled\Builds\", "*.xml");
            foreach (string buildFilePath in buildPaths) {
                BuildFile.Load(buildFilePath);

                // Get build root element
                XmlElement tmpBuildRoot = BuildFile.DocumentElement;
                XmlAttribute BuildElementClassAttribute = tmpBuildRoot.GetAttributeNode("class");
                BuildClass = BuildElementClassAttribute.Value;
                if (HeroClass == classDict[BuildClass])
                {
                    break;
                }
            }

            // Set build name variable
            XmlElement BuildRoot = BuildFile.DocumentElement;
            XmlAttribute BuildElementNameAttribute = BuildRoot.GetAttributeNode("name");
            BuildName = BuildElementNameAttribute.Value;
            // Loop through children for level info
            foreach (XmlNode LevelNode in BuildRoot.ChildNodes) {
                // Get Level element
                XmlElement LevelElement = LevelNode as XmlElement;
                XmlAttribute LevelElementValueAttribute = LevelElement.GetAttributeNode("value");
                // Determine appropriate BuildArray index
                int SelectedLevel = int.Parse(LevelElementValueAttribute.Value);
                BuildArray[SelectedLevel] = new Skill[LevelElement.ChildNodes.Count];
                // Loop through LevelNode children
                int i = 0;

                foreach (XmlNode SetSkillNode in LevelNode.ChildNodes) {
                    // Get SetSkill element
                    XmlElement SetSkillElement = SetSkillNode as XmlElement;
                    XmlAttribute SetSkillElementNameAttribute = SetSkillElement.GetAttributeNode("name");
                    XmlAttribute SetSkillElementRuneAttribute = SetSkillElement.GetAttributeNode("rune");
                    XmlAttribute SetSkillElementSlotAttribute = SetSkillElement.GetAttributeNode("slot");

                    if(SetSkillElementSlotAttribute.Value == "P1" || SetSkillElementSlotAttribute.Value == "P2" || SetSkillElementSlotAttribute.Value == "P3") {
                        //try
                        //{
                            BuildArray[SelectedLevel][i] = new PassiveSkill();
                        /*}
                        catch (Exception e)
                        {
                            Log(e.ToString());
                        }*/
                    } else {
                        //try
                        //{
                            BuildArray[SelectedLevel][i] = new ActiveSkill();
                        /*}
                        catch (Exception e)
                        {
                            Log(e.ToString());
                        }*/
                    }

                    try
                    {
                        BuildArray[SelectedLevel][i].setSnoPowerByString(SetSkillElementNameAttribute.Value);
                    }
                    catch (Exception e)
                    {
                        Log("Error loading " + BuildName + "(" + BuildClass + "): Skill " + SetSkillElementNameAttribute.Value + " does not exist!");
                        OnDisabled();
                        return;
                    }

                    try
                    {
                        BuildArray[SelectedLevel][i].setRuneIdByString(SetSkillElementRuneAttribute.Value);
                    }
                    catch (Exception e)
                    {
                        Log("Error loading " + BuildName + "(" + BuildClass + "): Rune " + SetSkillElementRuneAttribute.Value + " for Skill "+ SetSkillElementNameAttribute.Value +" does not exist!");
                        OnDisabled();
                        return;
                    }

                    try
                    {
                        BuildArray[SelectedLevel][i].setSlotByString(SetSkillElementSlotAttribute.Value);
                    }
                    catch (Exception e)
                    {
                        Log("Error loading " + BuildName + "(" + BuildClass + "): Slot " + SetSkillElementSlotAttribute.Value + " does not exist!");
                        OnDisabled();
                        return;
                    }
                    i++;
                }
            }

            Log("Enabled. The " + BuildName + " Build for " + BuildClass + " has been loaded.");
        }

        private static string _heroName;
        public static string HeroName
        {
            get
            {
                if (ZetaDia.Service.Hero.IsValid)
                    _heroName = ZetaDia.Service.Hero.Name;
                return _heroName;
            }
        }
        private static ActorClass _heroClass;
        public static ActorClass HeroClass
        {
            get
            {
                if (ZetaDia.Service.Hero.IsValid)
                    _heroClass = ZetaDia.Service.Hero.Class;
                return _heroClass;
            }
        }
    }
}