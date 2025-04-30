using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    internal class Combat
    {

        public Player currentPlayer;
        public Testing TestingClass; 
        public static Game game;
        public Monster monster;


        public static int currentMonsterHealth = 1;
        public int monsterHealthRemaining = 0;
        public static int currentPlayerHealth = 1;
        public int currentPlayerHealthRemaining = 0;



        public Combat() 
        {
            monster = new Monster("Gremlin!", 50);

            var monsterName = Monster.Name;
            int monsterHealth = Monster.Health;

            currentMonsterHealth = monsterHealth;

            // Establishes the Combat instance of the player whether the user is testing, or establishes the Game.player instance if the user is playing the game.
            
        }


        public void StartCombat(Player player)
        {
            ///if (Testing._testing == true)            // tested code
            //{
            //    currentPlayer = Testing.testingPlayer;
            //    CombatLinearInput();
            //}
            //else if (Testing._testing == false)
            //{
            //    currentPlayer = Game.player;
            //    CombatLinearInput();
            //}

            currentPlayer = player;
            currentPlayerHealth = Player.Health;
            CombatLinearInput();

        }


        public void CombatLinearInput()
        {
            // Checks if Testing is true.
            if (Testing._testing == true) 
            {
                Console.WriteLine($"Once entered the room, you are faced by a {Monster.Name}. It begins to move towards you, what is your move {Player.Name}");
                Console.WriteLine("Press A to attack. Press E to see equipped weapon and options");
                PlayerCombatLoop();
            }


            else if (Testing._testing == false) 
            {

                Console.WriteLine($"Once entered the room, you are faced by a {Monster.Name}. It begins to move towards you, what is your move {Player.Name}");
                Console.WriteLine("Press A to attack. Press E to see equipped weapon and options");
                PlayerCombatLoop();
            }

        }



        //The main function for the combat. Allows player to attack and equip a weapon, and also add a modifier.
        public void PlayerCombatLoop()
        {
            var CombatInputKey = Console.ReadKey().Key;


            var C_inputInv = Inventory.equipedItem;

            if (CombatInputKey == ConsoleKey.E)
            {
                
                if (Testing._testing == true)
                {
                    Program.ClearConsole();

                    // Shows all modifers and weapons present and includes error checking for invalid inputs from user.
                    Console.WriteLine("Weapons and their modifiers available:");

                    List<string> itemNames = new List<string>();

                    for (int i = 0; i < Items.Allitems.Count; i++)
                    {
                        itemNames.Add(Items.Allitems[i][0]);
                    }

                    Console.WriteLine(string.Join(", ", itemNames));
                    Console.WriteLine("\nType out the name of the item you want to equip...\n");

                    void equip(bool incorrect = false)
                    {
                        if (incorrect)
                        {
                            Console.WriteLine("\nInvalid input. Try again.\n");
                        }

                        var playerInput = Console.ReadLine();

                        // Checks if players input is valid and then adds item to the players inventory. Then allows for the option to attack.
                        if (playerInput != null && !(Inventory.inventory.Contains(playerInput)))
                        {
                            Inventory.AddToIventory(playerInput);

                            Console.WriteLine("\nItem selected has been added to inventory and equipped.\n\nPress (A) to attack\n");

                            Inventory.equipedItem = playerInput;

                            PlayerCombatLoop();
                        }
                        else
                        {
                            equip(true);
                        }
                    }
                    
                    equip();
                }
            }
            else if (CombatInputKey == ConsoleKey.A)
            {
                // Basic turn by turn system for combat. Starts with player attack and weapon choice, then after an input calls the monsters turn. Repeats until one is dead.
                currentPlayer.Attack(C_inputInv);
                Console.WriteLine("\nNext turn\n\nPress any key to continue.");
                Console.ReadKey();
                Program.ClearConsole();
                monster.Attack();
                PlayerCombatLoop();
            }
            else
            {
                Console.WriteLine("Invalid input, Try Again.");
                PlayerCombatLoop();
            }


        }


        // Sets monster health to be used in scripts for attacking.
        public static int DamageMonster(int damage) 
        {
            currentMonsterHealth -= damage;

            return currentMonsterHealth;
        }


        // Sets player health to be used in scripts for attacking.
        public static int DamagePlayer(int Monsterdamage) 
        {
            currentPlayerHealth -= Monsterdamage;

            return currentPlayerHealth;  
        }





    }

}
