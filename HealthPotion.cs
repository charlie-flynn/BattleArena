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
        public HealthPotion() : base(name: "Health Potion", targetsEnemy: false) { }
        public override void ApplyItemEffect(Player itemUser)
        {
            itemUser.Heal(25);
            
            ConsumeItem(itemUser);
            
        }
    }
}
