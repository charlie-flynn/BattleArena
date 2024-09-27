using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class EmptySlot : Item
    {
        private string _name = " ";
        public EmptySlot() : base(name: " ") { }




        public override void ApplyItemEffect(Player itemUser)
        {
            Console.WriteLine(itemUser + " tried to use nothing... But nothing happened!");
        }
    }
}
