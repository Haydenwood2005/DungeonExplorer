using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Item.Items;


namespace DungeonExplorer.Room // namespace for organizing the code into a group 
{
    public class Room
    {
        private string description;
        private RoomType roomType;


        public Room(string description, RoomType roomType) { // for deciding which room player enters next
            switch (roomType)
        {

                case RoomType.Safe: // all the different room types
                    description += " [ SAFE ZONE ]";
                    break;

                case RoomType.Normal:
                    description += " [ NORMAL ROOM ]";
                    break;

                case RoomType.Boss:
                    description += " [ BOSS ROOM ]";
                    break;

                case RoomType.Shop:
                    description += " [ SHOP ROOM ]";
                    break;

                case RoomType.Event:
                    description += " [ EVENT ROOM ]";
                    break;

                default:
                    break;

            }

            this.description = description;

            this.roomType = roomType;
        }


        public string GetDescription() { // returns the value of the description value to change room type

            return description;
        }

        public RoomType getRoomType() { // to obtain the room that the player will enter next
            return roomType;
        }

        public void EnterRoom(Player.Player player) // player enters new room
        {
            switch (roomType)
            {
                case RoomType.Event: // player finds treasure room with potion in
                    player.PickUpItem(new HealthPotion());
                    Console.WriteLine("You discovered a treasure room. Obtained a health potion!");
                    break;
                    
                case RoomType.None: // player doesn't enter room
                    Console.WriteLine("You hit a wall.");
                    break;

                default: //player enters one of the listed potential rooms
                    Console.WriteLine("You enter a " + roomType.ToString().ToLower() + " room.");
                    break;
            }
        }
    }
}

