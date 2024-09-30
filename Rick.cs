using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Rick : Enemy
    {
        private int _chargePower;
        public int ChargePower { get => _chargePower; set => _chargePower = value; }

        public Rick()
        {
            Name = "R.I.C.K.";
            Health = 10.0f;
            MaxHealth = 10.0f;
            AttackPower = 5.0f;
            DefensePower = 1.0f;
            IsDead = false;
            _chargePower = 5;
        }

        public Rick(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            Name = name;
            Health = maxHealth;
            MaxHealth = maxHealth;
            AttackPower = attackPower;
            DefensePower = defensePower;
            IsDead = false;
            _chargePower = 5;
        }

        

        public override float Attack(Character target)
        {
            // if the countdown is greater than 0, count it down by one.
            if (ChargePower > 0)
            {
                Console.WriteLine(Name + " is charging a devastating attack...");
                if (ChargePower > 1)
                {
                    Console.WriteLine(ChargePower + " turns remain.");
                }
                else
                {
                    Console.WriteLine("1 turn remains.");
                }
                ChargePower--;
            }
            // if the countdown is 0, unleash the R.I.C.K. Blast, which backfires to deal 999998 damage and lower R.I.C.K.'s defense to 9
            else if (ChargePower == 0)
            {
                Console.WriteLine(Name + " unleashed its R.I.C.K. Blast!");
                Console.WriteLine("But it backfired! " + Name + " took 999998 damage!");
                TakeDamage(999998);
                Console.WriteLine(Name + "'s health: " + Health + "/" + MaxHealth);
                DefensePower = 9;
                ChargePower--;
            }
            // if the countdown is less than 0, print a little bit of flavor text and do nothing whatsoever
            else
            {
                Console.WriteLine(Name + " is dazed after the impact of the R.I.C.K. Blast!");
            }


            return 0;
        }
    }
}
