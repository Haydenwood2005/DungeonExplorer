using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;
using System.Text;
using DungeonExplorer.Item.Items;



namespace DungeonExplorer.Managers.Game {
    internal class Game {
        private Player.Player Player { get; set; } // Properties
        private Room.Room CurrentRoom { get; set; }


        public Game()
        {
            // Initialize the game with one room and one player
            Player = new Player.Player("Player", 100);
            Player.PickUpItem(new HealthPotion());

            CurrentRoom = new Room.Room($"Starting Room", Room.RoomType.Normal);
        }

        public void Start()
        {
            // Changed the playing logic into true and populated the while loop
            bool playing = true;
            while (playing)
            { 
                DisplayGameStatus();
                RoomManager.DisplayMap();
                string action = GetPlayerAction();
                playing = HandlePlayerAction(action);
                Console.WriteLine("\n\n");
            }
        }


        private void DisplayGameStatus()
        { // Show the user the players stats and attributes
            Console.WriteLine("--- GAME STATS ---");
            Console.WriteLine($"Players Current Health: {Player.Health}/{Player.getMaxHealth()}"); // shows players health
            Console.WriteLine();
            Console.WriteLine("Players Current Inventory:"); // shows players inventory
            foreach (var item in Player.InventoryContents())
            {
                Console.WriteLine($"- {item.Name} (ID: {item.Id})"); // shows amount of which item player has in inventory
            }
            Console.WriteLine();
            Console.WriteLine($"Current Room: {CurrentRoom.GetDescription()}"); // shows user which room player is currently in
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        private string GetPlayerAction()
        {  // Asks user what they would like the player to do.
            Console.WriteLine("What action would you like to do?");
            DisplayPlayerActions();
            Console.Write("> ");
            return Console.ReadLine();
        }


        private void DisplayPlayerActions()
        { // Way to show the user all the options the player has at the curent time.
            Console.WriteLine("Actions available:");
            foreach (var item in Player.InventoryContents())
            {
                if (item.Useable)
                {
                    Console.WriteLine($"- Use {item.Name} (ID: {item.Id})");
                }
            }
            Console.WriteLine("- Move Up");
            Console.WriteLine("- Move Down");
            Console.WriteLine("- Move Left");
            Console.WriteLine("- Move Right");
            Console.WriteLine("- Exit");
            Console.WriteLine();
        }

        private bool HandlePlayerAction(string action)
        { // Method to handle player actions
            if (int.TryParse(action, out int itemId))
            {
                var item = Player.InventoryContents().FirstOrDefault(i => i.Id == itemId);
                if (item != null && item.Useable)
                {
                    Player.UseItem(item);
                }
                else
                {
                    Console.WriteLine("Input was invalid. Try again.");
                }
            }
            else if (action.Equals("move up", StringComparison.OrdinalIgnoreCase) ||
                     action.Equals("move down", StringComparison.OrdinalIgnoreCase) ||
                     action.Equals("move left", StringComparison.OrdinalIgnoreCase) ||
                     action.Equals("move right", StringComparison.OrdinalIgnoreCase))
            {
                string direction = action.Split(' ')[1];
                if (!RoomManager.MovePlayer(direction, Player))
                {
                    Console.WriteLine("You can not move that way.");
                }
            }
            else if (action.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Input was invalid. Try again.");
            }
            return true;
        }
    }
}
