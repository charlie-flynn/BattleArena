using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private bool _isDead = false;

        public Character()
        {
            _name = "Character";
            _health = 10.0f;
            _maxHealth = 10.0f;
            _attackPower = 1.0f;
            _defensePower = 1.0f;
            _isDead = false;
        }

        public Character(string name, float maxHealth, float attackPower, float defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
            _isDead = false;
        }

        public float Health
        {
            // gets the health variable
            get => _health;
            // set the health to what it is as long as it's above 0
            protected set { _health = Math.Clamp(value, 0, _maxHealth); }
        }
        public float MaxHealth { get { return _maxHealth; } protected set { } }
        public float AttackPower { get { return _attackPower; } protected set { } }
        public float DefensePower { get { return _defensePower; } protected set { } }
        public string Name { get { return _name; } protected set { } }
        public bool IsDead { get { return _isDead; } protected set { } }



        public virtual float Attack(Character target)
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

        public virtual void TakeDamage(float damage)
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
            _isDead = true;
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
