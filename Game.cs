using System;
using System.Collections.Generic;


namespace DungeonExplorer
{
    class Game
    {
        public static Player player;
        public static Room room = new Room();
        private static Inventory inventory = new Inventory();
        private static Combat combat; // bool playing = false

        public Game()
        {
            var playerName = Player.GetPlayerName();


            player = new Player(playerName, 100);
            Start();
        }
        public void Start()
        {
            Console.WriteLine($"\nSo your name is {Player.Name}?");
            
            Console.WriteLine("You have " + Player.Health + " health points.");
            
            Console.WriteLine("You can move to the next room and make decisions when shown on screen.\n");

            Program.ClearConsole();

            Console.WriteLine("You, " + Player.Name + ", start your journey in an eerie, mysterious cave. A cool breeze washes over you as you try to peer into the darkness only to see nothing. You're too deep in this adventure to turn back now. You build the courage to step forward into the nothingness.");
            
            Console.WriteLine("Press any key to continue your journey...\n");

            Console.ReadKey();
            bool playing = true;
            /// Console.WriteLine("playing = true");

            Program.ClearConsole();

            MoveToNextRoom();

            void MoveToNextRoom()
            {
                string roomDescription = Room.GetDescription();
                PlayerInput();
            }
        }
            
            


            public static void PlayerInput()
            {
                Console.WriteLine("What action would you like to carry out?");
                
                Console.WriteLine("You have " + Player.Health + " health points.");
                
                Console.WriteLine("Press Q for the menu.");

                Console.WriteLine("");

                var playerKey = Console.ReadKey().Key;

                Program.ClearConsole();

                if (playerKey == ConsoleKey.C)
                {
                    // Check to see if theres any items in the room.
                    List<string> roomItems = Room.GetItems();

                    Console.WriteLine(string.Join(", ", roomItems));
                    
                    Console.WriteLine("Type out the item you wish to interact with...");

                    var inputItem = Console.ReadLine();

                    if (roomItems.Contains(inputItem.ToLower()))
                    {
                        Console.WriteLine($"You picked up the {inputItem} and put the item(s) in your pocket");
                        Inventory.PickUpItem(inputItem);
                    }

                    PlayerInput();

                }
                else if (playerKey == ConsoleKey.I)
                {
                    // Show the inventory of the player.
                    Inventory.InventoryContents();

                    /// Console.WriteLine(player.InventoryContents());
                    PlayerInput();
                }
                else if (playerKey == ConsoleKey.F)
                {
                    // Player moves to the next room.
                    Console.WriteLine("You move into the next room");
                    
                    Room.GetDescription();
                    PlayerInput();
                    ///currentRoom = 2;
                }

                else if (playerKey == ConsoleKey.Q)
                {

                    Console.WriteLine("Press (C) to look around the room for any items");
                    
                    Console.WriteLine("Press (I) to check your current inventory");
                    
                    Console.WriteLine("Press (F) to move into the next room");
                    PlayerInput();
                }
                else if (playerKey == ConsoleKey.A) 
                {

                    Combat combat = new Combat();
                    combat.StartCombat(player);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    PlayerInput();
                }
            }
            
        
    }
}
