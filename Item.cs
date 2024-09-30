using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal abstract class Item
    {
        private string _name = " ";
        private bool _isTargetted = false;
        
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

        
        public abstract void ApplyItemEffect(Player itemUser, Character itemTarget = default);

        protected void ConsumeItem(Player itemUser)
        {
            // find the index of the item in the right inventory, then print a message and replace the item with an empty slot
            int index = Array.IndexOf(itemUser.Inventory, this);
            Console.WriteLine("The " + itemUser.Inventory[index].Name + " was consumed!");
            itemUser.Inventory[index] = new EmptySlot();
        }
    }
}
