using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BattleArena
{
    internal class Character
    {

        private string _name = "Character";
        private float _health = 10.0f;
        private float _maxHealth = 10.0f;
        private float _attackPower = 1.0f;
        private float _defensePower = 1.0f;

        public Character()
        {
            _name = "Character";
            _health = 10.0f;
            _maxHealth = 10.0f;
            _attackPower = 1.0f;
            _defensePower = 1.0f;
        }

        public float Health
        {
            // gets the health variable
            get => _health;
            // set the health to what it is as long as it's above 0
            private set { _health = Math.Clamp(value, 0, _maxHealth); }
        }
        public float MaxHealth { get { return _maxHealth; } }
        public float AttackPower { get { return _attackPower; } }
        public float DefensePower { get { return _defensePower; } }
        public string Name { get { return _name; } }

        public Character(string name, float maxHealth, float attackPower, float defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }

        public float Attack(Character target)
        {
            float damage = Math.Max(0, _attackPower - target.DefensePower);
            Console.WriteLine(Name + " attacked " + target.Name + " for " + damage + " damage!");
            target.TakeDamage(damage);

            if (target.Health > 0)
            {
                Console.WriteLine(target.Name + "'s Health: " + target.Health + "/" + target.MaxHealth);
            }
            
            return damage;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health == 0)
            {
                Die();
            }
        }

        public void Heal(float health)
        {
            Health += health;
            Console.WriteLine(Name + " healed " + health + " health!");
            Console.WriteLine(Name + "'s health: " + Health + "/" + MaxHealth);
        }

        private void Die()
        {
            Console.WriteLine(Name + " has died!");
        }

        public void PrintStats()
        {
            Console.WriteLine("Name:          " + Name);
            Console.WriteLine("Health:        " + Health + "/" + MaxHealth);
            Console.WriteLine("Attack Power:  " + AttackPower);
            Console.WriteLine("Defense Power: " + DefensePower);
        }
    }
}
