using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleArena
{
    internal class Player : Character
    {
        private Item[] _inventory = new Item[5];
        public Item[] Inventory { get { return _inventory; } protected set { } }
        public Player() : base()
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                Inventory[i] = new EmptySlot();
            }
        }
        public Player(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                Inventory[i] = new EmptySlot();
            }
        }

        public string[] GetInventoryNames()
        {
            string[] accessedInventory = new string[Inventory.Length];

            for (int i = 0; i < Inventory.Length; i++)
            {
                accessedInventory[i] = Inventory[i].Name;
            }

            return accessedInventory;
        }

        public void GainItem(Item item)
        {
            int slot = 0;
            int fullSlots = 0;

            Console.WriteLine("You got a " + item.Name + "!");

            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i].Name == " ")
                {
                    slot = i;
                    break;
                }
                else
                {
                    fullSlots++;
                }
            }

            if (fullSlots == Inventory.Length)
            {
                Console.WriteLine("...But your inventory is full!");
                Console.WriteLine("You discard the " + item.Name + ".");
            }
            else
            {
                Inventory[slot] = item;
            }
            Console.ReadKey();

        }
    }
}
