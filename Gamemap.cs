using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    // Manages the layout of the game. The order of rooms and layout in the dungeon.
    internal class Gamemap // Each room, sets the scene for a story like effect throughout the rooms of the game.
    {
        public static readonly string _room1Description = "You enter a cold, dark room barely lit from your headtorch. The swift breeze rushes in from behind you, almost insisting you to urge forward.";
        
        public static readonly string _room2Description = "Descending deeper down the hole, the cave suddenly opens up into a damp, mossy, stone brick room. You find yourself in a room with empty weapon racks lining the walls and a table in the middle covered in what looks to be old notes. Across the room, you notice a rotted, moulding wooden door.";
        
        public static readonly string _room3Description = "With the wooden door creaking wide, a larger room, with a dozen skeletons of what look to be old explorers lay still across the floor. A large opening appears just on the otherside";
        
        public static readonly string _room4Description = "You progress through the opening and the cave reveals what looks to be a collection of houses in a huge ravine. Immedieately intrigued by the village like structure in this isolated place, its clear the joruney has just begun...";

    }
}
