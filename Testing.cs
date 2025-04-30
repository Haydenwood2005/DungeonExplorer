using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    internal class Testing
    {
        // Makes new version of player for combat.
        public static Player testingPlayer { get; set; }

        public static Room room = new Room();
        public static bool _testing { get; set; }


        public static void testingDebug() 
        {
            Console.WriteLine("Welcome to the Testing Class! What is it you would like to test today?");
            Console.WriteLine("Input (C) for combat test.");
            _testing = true;

            var testingKey = Console.ReadKey().Key;
            /// var _combat = Combat.CombatLinearInput();

            // Pulls next room description. 
            if (testingKey == ConsoleKey.M)
            {
                Room.GetDescription();
            }
            // Player created with set name and set health to make combat test functional. Creates combat with error checking.
            else if (testingKey == ConsoleKey.C) 
            {
                var playerName = Player.GetPlayerName();
                testingPlayer = new Player(playerName, 100);

                Combat combat = new Combat();
                combat.StartCombat(testingPlayer);
            }
            else 
            {
                Console.WriteLine("Invalid input.");
                testingDebug();       
            }

        }

    }
}
