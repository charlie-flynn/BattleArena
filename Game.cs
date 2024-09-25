using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Game
    {
        Player player;
        Character enemy;
        private bool _gameOver = false;

        // keeping this here just in case i need it
        private int GetInput(string description, string option1, string option2)
        {
            ConsoleKeyInfo key;
            int inputRecieved = 0;

            while (inputRecieved != 1 && inputRecieved != 2)
            {
                // Print options
                Console.Clear();
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");

                // get input from player
                key = Console.ReadKey();

                // if first option
                if (key.KeyChar == '1')
                {
                    // set input recieved to 1
                    inputRecieved = 1;
                }
                // otherwise if second option
                else if (key.KeyChar == '2')
                {
                    // set input recieved to 2
                    inputRecieved = 2;
                }
                // else neither
                else
                {
                    // display error message (m,y favrite mmmm)
                    Console.WriteLine("\nInvalid Input");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            // return the input recieved after the loop
            Console.WriteLine();
            return inputRecieved;
        }


        private int GetInput(string description, string[] options)
        {
            ConsoleKeyInfo key;
            string playerInput;
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

                // prompt the player to type in an option
                Console.Write("> ");

                // if there's less than nine options, just read the next key the player presses
                if (options.Length < 9)
                {
                    key = Console.ReadKey();
                    playerInput = char.ToString(key.KeyChar);
                }
                // otherwise, read the next line they type
                else
                {
                    playerInput = Console.ReadLine();
                }

                // if the input is a number, greater than zero, and less than or equal to the length of the array
                if (int.TryParse(playerInput, out int num) && num <= options.Length && num > 0)
                {
                    // set input recieved to num
                    inputRecieved = num;

                    // if the amount of options are less than 9, write an empty line
                    if (options.Length < 9)
                    {
                        Console.WriteLine();  
                    }
                   
                }
                // otherwise, print an error message
                else
                {

                    // if the amount of options are less than 9, write an empty line
                    if (options.Length < 9)
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                }
            }
            return inputRecieved;
        }

        private void Start()
        {

            // ask the player what enemy they want to fight
            int input = GetInput("Choose your opponent!", new string[] { "The Weakling", "The Vampire", "The Charger" });

            player = new Player(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);


            // if they chose 1, bring out the weakling whose name is Wimpy Wartrew and has 100 health, 9 attack, and 0 defense
            // if they choose 2, bring out the vampire whose name is dracula 2, has 100 health, etc. etc. etc.
            if (input == 1)
            {
                enemy = new Weakling(name: "Wimpy Wartrew", maxHealth: 100, attackPower: 9, defensePower: 0);
            }
            else if (input == 2)
            {
                enemy = new Vampire(name: "Dracula 2", maxHealth: 100, attackPower: 9, defensePower: 5);
            }
            else if (input == 3)
            {
                enemy = new Charger(name: "USB-C You In Hell", maxHealth: 100, attackPower: 18, defensePower: 5);
            }

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
            else
            {
                int input = GetInput("Your turn, what will you do?", new string[] {"Attack", "Heal"});
                if (input == 1)
                {
                    float damage = player.Attack(enemy);
                }
                else
                {
                    player.Heal(10);
                }
                Console.ReadKey();
                Console.Clear();
            }
            

            
            // if the enemy's health is 0, end the game and exit the loop
            if (enemy.Health == 0)
            {
                _gameOver = true;
                return;
            }
            // otherwise, let the enemy attack
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
