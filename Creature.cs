using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Creates an overridable function for the player and monster classes to call from in combat.
namespace DungeonExplorer 
{
    abstract class Creature
    {
        public abstract void Attack(string currentWeapon = null);
    }
}
