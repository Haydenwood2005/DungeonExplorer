using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Item.Items;


namespace DungeonExplorer.Room // namespace for organizing the code into a group 
{
    public class Room
    {
        private string description;

        private List<Item.Item> items;

        private RoomType roomType;
        

        public Room(string description, RoomType roomType) { // for deciding which room player enters next
            switch (roomType)
        {

                case RoomType.Normal:
                    description += " [ NORMAL ROOM ]";
                    break;
                
                case RoomType.Safe: // all the different room types
                    description += " [ SAFE ZONE ]";
                    break;

                case RoomType.Boss:
                    description += " [ BOSS ROOM ]";
                    break;

                case RoomType.Event:
                    description += " [ EVENT ROOM ]";
                    break;

                case RoomType.Shop:
                    description += " [ SHOP ROOM ]";
                    break;

                default:
                    break;

            }

            this.description = description;

            this.items = new List<Item.Item>();

            this.roomType = roomType;

        }


        public
            string GetDescription() { // returns the value of the description value to change room type

            return description;
        }

        public List<Item.Item> GetItems() // obtain the item in the room
        {
            return items;
        }

        public RoomType getRoomType() { // to obtain the room that the player will enter next
            return roomType;
        }


        public void AddItem(Item.Item item)
        {
            items.Add(item);
        }

        public void EnterRoom(Player.Player player) // code for the player entering a room 
        {
            Console.WriteLine("You enter a " + roomType.ToString().ToLower() + " room!");
            if (items.Count > 0)
            {
                Console.WriteLine("You found the following items:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name} (ID: {item.Id})");
                    player.PickUpItem(item); // Item is picked up by player
                }
                items.Clear(); // Clear items from room after they get picked up by player
            }
    }
}



