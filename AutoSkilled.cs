using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

using Zeta;
using Zeta.Common;
using Zeta.CommonBot;
using Zeta.Common.Plugins;
using Zeta.Internals.Actors;
using Zeta.Common.Helpers;
using System.IO;

namespace AutoSkilled
{
    partial class AutoSkilled : IPlugin
    {
        // Plugin info
        public string Author { get { return "Tinnvec"; } }
        public string Description { get { return "AutoSkilled does exactly what it sounds like it does, automatically sets skills as you level"; } }
        public string Name { get { return "AutoSkilled"; } }
        public Version Version { get { return new Version(0, 5); } }
        public Window DisplayWindow { get { return null; } }

        // Properties
        private string BuildName;
        private string BuildClass;
        private Skill[][] BuildArray = new Skill[61][];
        private List<Skill> SkillEquipQueue = new List<Skill>();

        private WaitTimer LevelUpTimer = WaitTimer.FiveSeconds;
        private WaitTimer SetSkillTimer = WaitTimer.OneSecond;

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

            Log("Enabled. The " + BuildName + " Build for " + BuildClass + " has been loaded");
        }

        // Pulse event method
        public void OnPulse() {
            // Wait some more if our timers are still going
            if (!LevelUpTimer.IsFinished || !SetSkillTimer.IsFinished) {
                return;
            }

            // Don't do anything if we're dead or switching worlds
            if (!ZetaDia.IsInGame || !ZetaDia.Me.IsValid || !ZetaDia.CPlayer.IsValid || ZetaDia.Me.IsDead || ZetaDia.IsLoadingWorld) {
                return;
            }

            // Don't do anything if we're in combat
            AnimationState CurrentAnimationState = ZetaDia.Me.CommonData.AnimationState;
            if (CurrentAnimationState == AnimationState.Attacking || CurrentAnimationState == AnimationState.Casting || CurrentAnimationState == AnimationState.Channeling || CurrentAnimationState == AnimationState.TakingDamage) {
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
            int CurrentLevel = ZetaDia.Me.Level;
            if(BuildArray[CurrentLevel] != null) {
                foreach(Skill LevelSkill in BuildArray[CurrentLevel]) {
                    SkillEquipQueue.Add(LevelSkill);
                }
            }
        }

        // Logging method
        public void Log(string message, LogLevel level = LogLevel.Normal) {
            Logging.Write(level, string.Format("[{0}] {1}", Name, message));
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
            classDict.Add("WitchDoctor", ActorClass.WitchDoctor);
            classDict.Add("Wizard", ActorClass.Wizard);

            XmlDocument BuildFile = new XmlDocument();

            // Get build file
            ActorClass myClass = ZetaDia.Service.CurrentHero.Class;
            string[] buildPaths = Directory.GetFiles(@"Plugins\AutoSkilled\Builds\", "*.xml");
            foreach (string buildFilePath in buildPaths) {
                BuildFile.Load(buildFilePath);

                // Get build root element
                XmlElement tmpBuildRoot = BuildFile.DocumentElement;
                XmlAttribute BuildElementClassAttribute = tmpBuildRoot.GetAttributeNode("class");
                BuildClass = BuildElementClassAttribute.Value;
                if (ZetaDia.Service.CurrentHero.Class == classDict[BuildClass]) {
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
                        BuildArray[SelectedLevel][i] = new PassiveSkill();
                    } else {
                        BuildArray[SelectedLevel][i] = new ActiveSkill();
                    }
                    BuildArray[SelectedLevel][i].setSnoPowerByString(SetSkillElementNameAttribute.Value);
                    BuildArray[SelectedLevel][i].setRuneIdByString(SetSkillElementRuneAttribute.Value);
                    BuildArray[SelectedLevel][i].setSlotByString(SetSkillElementSlotAttribute.Value);
                    i++;
                }
            }
        }
    }
}