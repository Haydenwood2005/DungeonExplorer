using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    internal class Program
    {
        private Testing testingClass;
        public static Game game;

        private static Weapons weapons { get; set; }
        private static WeaponModifiers weaponMods { get; set; }

        static public void Main(string[] args)
        {
            Console.WriteLine("Welcome to The Dungeon Explorer. Press any button to start the game, or press (T) to open the testing menu.");
            Console.WriteLine("");

            weapons = new Weapons();
            weaponMods = new WeaponModifiers();

            var inputKey = Console.ReadKey().Key;
          
            if (inputKey == ConsoleKey.T)
            {
                Testing.testingDebug();          
            }
            else 
            {
                // Start the game.

                game = new Game();
            }

          
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }


    }
}
