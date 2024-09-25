using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleArena
{
    internal class Charger : Enemy
    {
        private bool _isCharging;

        public Charger()
        {
            Name = "Charger";
            Health = 10.0f;
            MaxHealth = 10.0f;
            AttackPower = 5.0f;
            DefensePower = 1.0f;
            IsDead = false;
            _isCharging = false;
        }

        public Charger(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            Name = name;
            Health = maxHealth;
            MaxHealth = maxHealth;
            AttackPower = attackPower;
            DefensePower = defensePower;
            IsDead = false;
            _isCharging = false;
        }

        public override float Attack(Character target)
        {
            if (_isCharging == true)
            {
                Console.WriteLine(Name + " is charging up after its last attack...");
                Console.WriteLine(target.Name + "'s Health: " + target.Health + "/" + target.MaxHealth);
                _isCharging = false;
                return 0;
            }
            else
            {
                _isCharging = true;
                return base.Attack(target);
            }
        }


    }
}
