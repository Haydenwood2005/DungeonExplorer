using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace DungeonExplorer
{
    class Room
    {
        public static int currentRoom = -1;
        public static Game game;

        // The list of available items in each room.
        public static List<string> room1Items = new List<string> { "dagger" };
        
        public static List<string> room2Items = new List<string> { "sword", "20 copper coins", "undesiphered notes" };
        
        public static List<string> room3Items = new List<string> { "shield", "30 gold coins", "dusty coat" };

        public static List<string> RoomDescriptions = new List<string>();
        public static List<List<string>> RoomItems = new List<List<string>>();

        public Room()
        {
            // Lists all of the accessible areas of the map and their descriptions.
            RoomDescriptions.Add(Gamemap._room1Description);
            RoomDescriptions.Add(Gamemap._room2Description);
            RoomDescriptions.Add(Gamemap._room3Description);
            RoomDescriptions.Add(Gamemap._room4Description);

            RoomItems.Add(room1Items);
            RoomItems.Add(room2Items);
            RoomItems.Add(room3Items);
        }

        public static string GetDescription()
        {
            currentRoom++;
            string roomDescription = "";

            try
            {
                roomDescription = RoomDescriptions[currentRoom];
            }
            catch
            {
                Debug.WriteLine("Room description not found.");
            }

            /// Console.WriteLine(roomItems);         // Tested code.
            Console.WriteLine(roomDescription);

            return roomDescription;


        }

        public static List<string> GetItems()
        {
            List<string> roomItems = RoomItems[currentRoom];
            return roomItems;
        }
    }
}
