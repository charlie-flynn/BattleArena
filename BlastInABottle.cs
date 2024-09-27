using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class BlastInABottle : Item
    {
        public BlastInABottle() : base(name: "Blast in a Bottle", true) { }

        public override void ApplyItemEffect(Player itemUser)
        {
            /*
            Console.WriteLine(itemUser.Name + " used the Blast in a Bottle!");
            Console.WriteLine(itemTarget.Name);
            itemTarget.TakeDamage(25);
            */

            
            ConsumeItem(itemUser);

        }
    }
}
