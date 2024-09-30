using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal abstract class Enemy : Character
    {
        // not much here really
        public Enemy() : base()
        {

        }
        public Enemy(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            
        }
    }
}
