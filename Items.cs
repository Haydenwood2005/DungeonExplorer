using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    // This class manages the items in the game. Adding and removing items in rooms.
    internal class Items
    {
        public static List<string[]> Allitems = new List<string[]>();

        //goes into the weapon and specifically calls the modifiers for each weapon
        public static int GetDamageModifier(string item)
        {
            for (int i = 0; i < Allitems.Count; i++)
            {
                if (Allitems[i][0] == item)
                {
                    return int.Parse(Allitems[i][1]);
                }
            }

            return 1;
        }
    }
}
