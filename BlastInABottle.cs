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

        public override void ApplyItemEffect(Player itemUser, Character itemTarget = default)
        {
            // deal 25 damage to target
            Console.WriteLine(itemUser.Name + " used the Blast in a Bottle!");
            if (itemTarget.Health > 999998)
            {
                Console.WriteLine("But " + itemTarget.Name + " was unfazed.");
            }
            else
            {
                Console.WriteLine(itemTarget.Name + " took 25 damage!");
                itemTarget.TakeDamage(25);
                Console.WriteLine(itemTarget.Name + "'s health: " + itemTarget.Health + "/" + itemTarget.MaxHealth);
            }

            ConsumeItem(itemUser);

        }
    }
}
