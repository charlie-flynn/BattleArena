using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Game
    {
        private Player player;
        private Enemy enemy;
        private Enemy[] enemies;
        private bool _gameOver = false;
        private int enemyIndex;
        private int enemiesKilled = 0;
        private int GetInput(string description, string[] options)
        {
            ConsoleKeyInfo key;
            int inputRecieved = 0;

            while (inputRecieved <= 0 || inputRecieved > options.Length)
            {
                // clear the console, then print out the description and options
                Console.Clear();
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }

                // prompt the player to type in an option (we shouldnt need more than 9 options ever so just read key)
                Console.Write("> ");
                key = Console.ReadKey();
                Console.WriteLine();

                // if the input is a number, greater than zero, and less than or equal to the length of the array
                if (int.TryParse(key.KeyChar.ToString(), out int num) && num <= options.Length && num > 0)
                {
                    // set input recieved to num
                    inputRecieved = num;

                   
                }
                // otherwise, print an error message
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                }
            }
            return inputRecieved;
        }
        private string[] GetAliveEnemyNames(Enemy[] enemies)
        {
            string[] names = new string[enemies.Length];

            for (int i = 0; i < enemies.Length; i++)
            {
                if (!enemies[i].IsDead)
                {
                    names[i] = enemies[i].Name;
                }
                else
                {
                    names[i] = "(X) " + enemies[i].Name;
                }
                
            }

            return names;
        }
        private void Start()
        {
            enemies = new Enemy[]
            {
                new Weakling(name: "Wimpy Wartrew", maxHealth: 100, attackPower: 9, defensePower: 0),
                new Vampire(name: "Dracula 2", maxHealth: 80, attackPower: 9, defensePower: 5),
                new Charger(name: "Blastholomew", maxHealth: 100, attackPower: 18, defensePower: 5)
            };
            // ask the player what enemy they want to fight
            int input = GetInput("Choose your opponent!", GetAliveEnemyNames(enemies));

            // initialize the player
            player = new Player(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);
            Console.WriteLine();
            Console.WriteLine("Here's a couple freebies, use them wisely!");
            player.GainItem(new HealthPotion());
            player.GainItem(new BlastInABottle());
            Console.WriteLine();



            // if they chose 1, bring out the weakling whose name is Wimpy Wartrew and has 100 health, 9 attack, and 0 defense
            // if they choose 2, bring out the vampire whose name is dracula 2, has 100 health, etc. etc. etc.
            enemyIndex = input - 1;
            enemy = enemies[enemyIndex];

            // print the player's stats, and the enemy's stats
            player.PrintStats();
            Console.WriteLine();
            enemy.PrintStats();
            Console.ReadKey();
            Console.Clear();
        }

        private void Update()
        {
            // if your health is 0, end the game and exit the loop
            if (player.Health == 0)
            {
                _gameOver = true;
                return;
            }
            // otherwise give the player their turn

            // if you input 1, you attack. when you input 2, you heal 10 health. when you input 3, you open your inventory and choose an item to use
            else
            {
                int input = GetInput("Your turn, what will you do?", ["Attack", "Heal", "Item"]);
                if (input == 1)
                {
                    float damage = player.Attack(enemy);
                }
                else if (input == 2)
                {
                    player.Heal(10);
                }
                else
                {
                    input = GetInput("What item will you use?", player.GetInventoryNames());
                    player.Inventory[input - 1].ApplyItemEffect(player, enemy);
                }
                Console.ReadKey();
                Console.Clear();
            }
            
            // if the enemy's health is 0, prompt the player to choose an item, then choose their next enemy. otherwise, let the enemy attack
            if (enemy.Health == 0)
            {
                
                enemy.IsDead = true;
                enemies[enemyIndex].IsDead = true;
                enemiesKilled++;

                // if they've killed all enemies including the final boss, end the game
                if (enemiesKilled > enemies.Length)
                {
                    _gameOver = true;
                    return;
                }

                // let the player choose an item
                int input = GetInput("What item do you need?", ["Health Potion", "Blast in a Bottle"]);
                if (input == 1)
                {
                    player.GainItem(new HealthPotion());
                }
                else
                {
                    player.GainItem(new BlastInABottle());
                }

                // prepare the player emotionally for the final boss
                if (enemiesKilled == enemies.Length)
                {
                    Console.Clear();
                    Console.WriteLine("It's time to face your final opponent...");
                    Console.ReadKey();
                    input = GetInput("Are you ready?", ["Yes", "No"]);
                    if (input == 1)
                    {
                        Console.WriteLine("Good.");
                    }
                    else
                    {
                        Console.WriteLine("TOO BAD LOL GET READY TO GET GOT");
                    }
                    enemy = new Rick("The Royally Infallible Cannon of Killing", 999999, 999999, 999999);
                    player.PrintStats();
                    Console.WriteLine();
                    enemy.PrintStats();
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    while (enemy.IsDead)
                    {
                        input = GetInput("Choose your next foe", GetAliveEnemyNames(enemies));
                        enemyIndex = input - 1;
                        enemy = enemies[enemyIndex];
                        if (enemy.IsDead)
                        {
                            Console.WriteLine("You have already slain that foe...");
                            Console.ReadKey();
                        }
                        else
                        {
                            player.PrintStats();
                            Console.WriteLine();
                            enemy.PrintStats();
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
            }
            else
            {
                enemy.Attack(player);
                Console.ReadKey();
            }
        }

        private void End()
        {
            // if the enemy died, print you win!!!!!!!! otherwise print you lost!!!!!!!
            Console.Clear();
            if (enemy.Health == 0)
            {
                Console.WriteLine("YOU WON!!! :D");
            }
            else
            {
                Console.WriteLine("YOU LOST!!! D:");
            }
            Console.ReadKey();
        }
        public void Run()
        {
            Start();
            while (!_gameOver)
            {
                Update();
            }
            End();
        }
    }
}
