using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta;
using Zeta.Internals.Actors;

namespace AutoSkilled {
    public class PassiveSkill : Skill {
        private Dictionary<string, int> passiveSkillSlotDict;

        private int passiveSlot;

        public PassiveSkill() {
            passiveSkillSlotDict = new Dictionary<string, int>();
            passiveSkillSlotDict.Add("P1", 0);
            passiveSkillSlotDict.Add("P2", 1);
            passiveSkillSlotDict.Add("P3", 2);
        }

        public override bool activate() {
            SNOPower[] currentPassives = new SNOPower[3];
            int i = 0;
            // Read current passives and store them in array
            foreach (SNOPower currentlySetPassive in ZetaDia.CPlayer.PassiveSkills) {
                if(currentlySetPassive == null) {
                    currentPassives[i] = SNOPower.None;
                } else {
                    currentPassives[i] = currentlySetPassive;
                }
                i++;
            }
            currentPassives[this.getPassiveSlot()] = this.getSnoPower();
            ZetaDia.Me.SetTraits(currentPassives[0], currentPassives[1], currentPassives[2]);
            ZetaDia.Actors.Update();
            IEnumerable passivesSet = ZetaDia.CPlayer.PassiveSkills;
            bool passiveSkillWasSet = false;
            foreach (SNOPower setPassiveSkill in passivesSet) {
                if (setPassiveSkill == this.getSnoPower()) {
                    passiveSkillWasSet = true;
                }
            }

            return passiveSkillWasSet;
        }

        public override void setSlotByString(string slotString) {
            this.setPassiveSlot(passiveSkillSlotDict[slotString]);
        }

        public int getPassiveSlot() {
            return this.passiveSlot;
        }

        public void setPassiveSlot(int passiveSlot) {
            this.passiveSlot = passiveSlot;
        }
    }
}
