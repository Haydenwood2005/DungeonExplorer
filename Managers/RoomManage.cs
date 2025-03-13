using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Player;
using DungeonExplorer.Room;


namespace DungeonExplorer.Managers { // namespace to organize code throughout and decluster
    public class RoomManager {
        private Room.Room[,] rooms;
        private bool[,] visitedRooms;
        private int currentRow;
        private int currentCol;
        private string[,] levelLayout;

        
        public RoomManager()  // Creating the first level 
        {
            InitializeRooms();
        }


        private void InitializeRooms() // Initialize rooms for the first level of the dungeon using a 2D structure
        {
            levelLayout = new string[,]
            {
                    { "S", "B", "N" }, // structure of level in the console with designated room types
                    { "N", "#", "N" },
                    { "N", "T", "N" }
            };


            int rows = levelLayout.GetLength(0); // sets out column and rows for rooms layout
            int cols = levelLayout.GetLength(1);
            rooms = new Room.Room[rows, cols];
            visitedRooms = new bool[rows, cols];


            for (int row = 0; row < rows; row++) // for this position, get a room type
            {
                for (int col = 0; col < cols; col++)
                {
                    string cell = levelLayout[row, col];
                    RoomType roomType = GetRoomTypeFromChar(cell);
                    if (roomType != RoomType.None) // if roomtype isnt equal to 'roomtype.none', then a new room
                    {
                        rooms[row, col] = new Room.Room($"Room ({row},{col})", roomType);
                    }
                }
            }

           
            currentRow = 0;  // Puts player in the first room in the beginning at (0,0)
            currentCol = 0;
            visitedRooms[currentRow, currentCol] = true;
        }


        private RoomType GetRoomTypeFromChar(string cell) // different room types on the 2D structure
        {
            switch (cell)
            {
                case "B":
                    return RoomType.Boss;
                case "N":
                    return RoomType.Normal;
                case "T":
                    return RoomType.Safe;
                case "S":
                    return RoomType.Shop;
                case "E":
                    return RoomType.Event;
                case "#":
                    return RoomType.None; // Wall hit
                    
                default:
                    return RoomType.None;
            }
        }

        public Room.Room GetCurrentRoom()
        {
            return rooms[currentRow, currentCol];
        }


        public bool MovePlayer(string direction, Player.Player player) // moves position of player
        {
            int newRow = currentRow;
            int newCol = currentCol;


            switch (direction.ToLower()) // decides where to move
            {
                case "up":  // new row or column depending on users input
                    newRow--;
                    break;
                case "down":  // ++ or -- based on left and up or right and down
                    newRow++;
                    break;
                case "left":
                    newCol--;
                    break;
                case "right":
                    newCol++;
                    break;
                default:
                    Console.WriteLine("Invalid input. Enter: 'up', 'down', 'left', or 'right'");
                    return false;
            }


            if (newRow >= 0 && newRow < rooms.GetLength(0) && newCol >= 0 && newCol < rooms.GetLength(1) && rooms[newRow, newCol] != null)
            {
                currentRow = newRow;
                currentCol = newCol;
                visitedRooms[currentRow, currentCol] = true;
                rooms[currentRow, currentCol].EnterRoom(player);  // Triggers room behavior
                return true;
            }
            else
            {
                Console.WriteLine("You can not move that way.");
                return false;
            }
        }

       
        public void DisplayMap() // Display map  using 2D structure and current player position (P)
        {
            int rows = levelLayout.GetLength(0);
            int cols = levelLayout.GetLength(1); // creating the map, using spacing and borders

            // Print top border of map
            Console.WriteLine(" "); // For spacing
            Console.WriteLine("+" + new string('-', cols * 2) + "+");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("|"); // Left border of map
                for (int col = 0; col < cols; col++)
                {
                    if (row == currentRow && col == currentCol)
                    {
                        Console.Write("P "); // Current position of PLayer
                    }
                    else if (levelLayout[row, col] == "#")
                    {
                        Console.Write("# "); // Wall
                    }
                    else if (visitedRooms[row, col])
                    {
                        Console.Write(levelLayout[row, col] + " ");
                    }
                    else
                    {
                        Console.Write("? ");
                    }
                }
                Console.WriteLine("|"); // Right border of map
            }

            // Print bottom border of map
            Console.WriteLine("+" + new string('-', cols * 2) + "+");
            Console.WriteLine(" "); // For spacing
        }
    }
}
