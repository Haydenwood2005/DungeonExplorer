
namespace DungeonExplorer.Item {

    
    public abstract class Item { 
        private static int nextId = 1;

        public string Name { get; }
        public string Description { get; }
        public int Id { get; }
        public bool Useable { get; }

        
        protected Item(string name, string description, bool useable)  // a new ID of the Item class.
        {
            Name = name;
            Description = description;
            Useable = useable;
            Id = nextId++;
        }
        public abstract void Use(Player.Player player); // item is used on the player.
    }
}
