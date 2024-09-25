using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleArena
{
    internal class Vampire : Enemy
    {
        public Vampire()
        {
            Name = "Vampire";
            Health = 10.0f;
            MaxHealth = 10.0f;
            AttackPower = 5.0f;
            DefensePower = 1.0f;
            IsDead = false;
        }

        public Vampire(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
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
            // do a regular attack
            float damage = base.Attack(target);

            // then heal for half the damage dealt
            Heal(damage / 2);

            return damage;

        }




    }
}
