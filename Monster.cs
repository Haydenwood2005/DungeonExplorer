using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer

// This class pulls features (eg. name, health, and attack) from the creature class.


{
    class Monster : Creature
    {
        public static string Name { get; private set; }
        public static int Health { get; private set; }

        public static Combat combat;
        public Random randomD8 = new Random();
        public int MonsterDamageDealt = 0;
        public bool attacked = false;

        public Monster(string name, int health)
        {
            Name = name;
            Health = health;
        }


        // The code pulled from the turn by turn combat loop to represent the monster attack.
        public override void Attack(string currentWeapon = null)
        {
            //  The damage dice for the monster, representing an 8 sided dice.
            MonsterDamageDealt = randomD8.Next(1, 9);

            // Pull the players current health from the combat class and set it as the current player health.
            int currentPlayerHealth = Combat.DamagePlayer(MonsterDamageDealt);


            // Shows the damage the monster did to the player and prints the players new health after damage.
            Program.ClearConsole();
            Console.WriteLine($"You were hit and took {MonsterDamageDealt} damage!");
            Console.WriteLine($"You have {currentPlayerHealth} health points left!");
            Console.WriteLine($"Type (A) to attack or type (E) to equip weapon");
           
            // Program finished if players health is <= 0.
            if (currentPlayerHealth <= 0)
             {
                    Program.ClearConsole();
                    Console.WriteLine($"Your health has reached {currentPlayerHealth} and therefore your journey ends here.\n");
                    Console.ReadKey();
             }

            



        }
    }
}
