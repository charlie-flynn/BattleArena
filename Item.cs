using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal abstract class Item
    {
        private string _name = " ";
        private bool _isTargetted = false;
        private Character nullTarget;
        
        public Item(string name, bool targetsEnemy)
        {
            Name = name;
            _isTargetted = targetsEnemy;
        }
        public string Name 
        { 
            get { return _name; } 

            private set { _name = value; } 
        }
        public bool IsTargetted { get { return _isTargetted; } }

        
        // i really wanna have an optional argument for the target of the item but i just dont know how to do it??? ugh, ill do it monday im sure
        public abstract void ApplyItemEffect(Player itemUser);

        protected void ConsumeItem(Player itemUser)
        {
            // find the index of the item in the right inventory, then print a message and replace the item with an empty slot
            int index = Array.IndexOf(itemUser.Inventory, this);
            Console.WriteLine("The " + itemUser.Inventory[index].Name + " was consumed!");
            itemUser.Inventory[index] = new EmptySlot();
        }
    }
}
