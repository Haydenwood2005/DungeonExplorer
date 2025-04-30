using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    // This class manages the inevntory of the player. Items such as coins and weapons.
    internal class Inventory
    {
        public static List<string> inventory = new List<string>();
        public static string equipedItem = "N/A";

        public static void InventoryContents()
        {
            Console.WriteLine($"Your inventory consists of the folowing items: {string.Join(", ", inventory)}");
            Console.WriteLine("Write down the item name to equip it.");

            var inputInv = Console.ReadLine();

            if (inventory.Contains(inputInv.ToLower()))
            {
                Console.WriteLine($"You have equipped {inputInv}");
                ///Console.WriteLine(ItemDes);
                ///string equipedItem = inputInv;

                equipedItem = inputInv;
            }

   

        }

        public static void AddToIventory(string item) 
        {
            inventory.Add(item);
        }


        public static void PickUpItem(string item)
        {
            inventory.Add(item);
        }
    }
}
