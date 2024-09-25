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
        public Item(string name)
        {
            Name = name;
        }
        public string Name { get { return _name; } protected set { } }


        protected abstract void ApplyItemEffect(Character itemUser);
    }
}
