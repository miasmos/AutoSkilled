using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta;
using Zeta.Bot;
using Zeta.Game.Internals.Actors;

namespace AutoSkilled {
    public class ActiveSkill : Skill {
        private Dictionary<string, HotbarSlot> activeSkillSlotDict;

        private HotbarSlot hotbarSlot;

        public ActiveSkill() {
            activeSkillSlotDict = new Dictionary<string, HotbarSlot>();
            // Skill Slots
            activeSkillSlotDict.Add("L", HotbarSlot.HotbarMouseLeft);
            activeSkillSlotDict.Add("R", HotbarSlot.HotbarMouseRight);
            activeSkillSlotDict.Add("1", HotbarSlot.HotbarSlot1);
            activeSkillSlotDict.Add("2", HotbarSlot.HotbarSlot2);
            activeSkillSlotDict.Add("3", HotbarSlot.HotbarSlot3);
            activeSkillSlotDict.Add("4", HotbarSlot.HotbarSlot4);
        }

        public override bool activate() {
            // Get the current Skill in the hotbar slot we want to use
            SNOPower currentlyEquippedSkillInHotbarSlot = Zeta.Game.ZetaDia.CPlayer.GetPowerForSlot(this.hotbarSlot);
            // Check if Skill in slot is off cooldown, out of resource, or slot is empty so we can switch it
            PowerManager.CanCastFlags castFlag = PowerManager.CanCastFlags.None;
            bool wasSet = false;
            bool offCooldown = PowerManager.CanCast(currentlyEquippedSkillInHotbarSlot, out castFlag);
            if (offCooldown || castFlag == PowerManager.CanCastFlags.PowerUnusableGeneric || currentlyEquippedSkillInHotbarSlot == SNOPower.None) {
                // Set the skill
                Zeta.Game.ZetaDia.Me.SetActiveSkill(this.getSnoPower(), this.getRuneId(), this.getHotbarSlot());
                Zeta.Game.ZetaDia.Actors.Update();
                // Check to see if it actually was set
                if (Zeta.Game.ZetaDia.CPlayer.GetPowerForSlot(this.getHotbarSlot()) == this.getSnoPower() && Zeta.Game.ZetaDia.CPlayer.GetRuneIndexForSlot(this.getHotbarSlot()) == this.getRuneId())
                {
                    wasSet = true;
                }
            }
            return wasSet;
        }

        public override void setSlotByString(string slotString) {
            this.setHotbarSlot(activeSkillSlotDict[slotString]);
        }

        public HotbarSlot getHotbarSlot() {
            return this.hotbarSlot;
        }

        public void setHotbarSlot(HotbarSlot hotbarSlot) {
            this.hotbarSlot = hotbarSlot;
        }
    }
}
