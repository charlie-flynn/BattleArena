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
        public Item[] Inventory { get { return _inventory; } set { } }

        public Player() : base()
        {

        }
        public Player(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            
        }
    }
}
