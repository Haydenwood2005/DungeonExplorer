using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;


namespace DungeonExplorer
{
     class Player : Creature
    {
        public static string Name { get; private set; }
        public static int Health { get; set; }
        public static Combat combat;
        
        public Random randomD10 = new Random();
        public int DamageDealt = 0;
        public bool attacked = false;
        /// public var playerInventory = InventoryContents();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        // Serves as the player attack script ovverided from the Creature class.
        public override void Attack(string currentWeapon = null)
        {
            // The damage dice for the player, representing a 10 sided dice.
            DamageDealt = randomD10.Next(1, 11);

            // Obtains % increase by using active modifier and weapon active.
            int modifiedDamageDealt = (DamageDealt * Items.GetDamageModifier(currentWeapon) / 100);

            // Adds both damage numbers to obtain new damage the player does to monster.
            int totalDamageDealt = DamageDealt + modifiedDamageDealt;

            // Calls and sets the monsters new health after damage.
            int monsterHealthRemaining = Combat.DamageMonster(totalDamageDealt);

            // Main text for the combat game. Shows equipped weapon, total damage dealt, damage added by the modifier (if equipped) and the monsters remaining health.
            Console.WriteLine($"\n Your equipped weapon = {Inventory.equipedItem}");
            Console.WriteLine($"You hit the monster and dealt {totalDamageDealt} damage!"); 
            Console.WriteLine($"With your modified weapon you deal an extra {modifiedDamageDealt} to the monster");
            Console.WriteLine($"The monster has {monsterHealthRemaining} health points left!");

            // Checks if monsters health is <= 0 after each turn. It then goes to an option screen for players input.
            if (monsterHealthRemaining <= 0)
            {
                Program.ClearConsole();
                Console.WriteLine($"You won the battle The Monster had {monsterHealthRemaining} remaining and therefore has been defeated.\n");
                Game.PlayerInput();
            }

        }

        // Asks for the player name and detects if there is any errors such as whitespace or input is empty. If so, asks user to input again.
        public static string GetPlayerName()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter your name or an alias: ");
            var inputName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputName))
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid name or alias");
                return GetPlayerName();
            }
            else
            {
                return inputName;
            }

        }

    }

   
}
