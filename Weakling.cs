using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleArena
{
    internal class Weakling : Enemy
    {
        public Weakling()
        {
            Name = "Weakling";
            Health = 10.0f;
            MaxHealth = 10.0f;
            AttackPower = 5.0f;
            DefensePower = 1.0f;
            IsDead = false;
        }

        public Weakling(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            Name = name;
            Health = maxHealth;
            MaxHealth = maxHealth;
            AttackPower = attackPower;
            DefensePower = defensePower;
            IsDead = false;
        }

        public override float Attack(Character target)
        {
            int d4Roll = RandomNumberGenerator.GetInt32(1, 5);

            if (!(d4Roll == 1))
            {
                Console.WriteLine(Name + " tried to attack, but was too scared to follow through!");
                Console.WriteLine(target.Name + "'s Health: " + target.Health + "/" + target.MaxHealth);
                return 0;
            }
            else
            {
                return base.Attack(target);
            }
            
        }




    }
}
