using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class HealthPotion : Item
    {
        public HealthPotion() : base(name: "Health Potion") { }
        public override void ApplyItemEffect(Player itemUser, Character itemTarget)
        {
            // heal the user for 25 health
            itemUser.Heal(25);
            
            ConsumeItem(itemUser);
            
        }
    }
}
