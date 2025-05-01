using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    internal class WeaponModifiers : Items
    {
        private static string[] sharp = new string[]
        {
            "sharp",
            "25" // The % of damage added onto attack from weapon to hit monster for additional damage.
        };

        private static string[] heavy = new string[]
        {
            "heavy",
            "15" // The % of damage added onto attack from weapon to hit monster for additional damage.
        };

        public WeaponModifiers()
        {
            Items.Allitems.Add(sharp);
            
            Items.Allitems.Add(heavy);
        }
    }
}
