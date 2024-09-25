using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class HealthPotion : Item
    {

        public HealthPotion() : base(name: "Health Potion") { }
        protected override void ApplyItemEffect(Character itemUser)
        {
            itemUser.Heal(25);
        }
    }
}
