using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    internal class Weapons : Items
    {
        private static string[] dagger = new string[]
        {
            "dagger",
            "25" // The % of damage added onto attack to hit monster.
        };
        
        private static string[] sword = new string[]
        {
            "sword",
            "50" // The % of damage added onto attack to hit monster.
        };

        public Weapons() 
        {
            Items.Allitems.Add(dagger);
            
            Items.Allitems.Add(sword);
        }
    }
}
