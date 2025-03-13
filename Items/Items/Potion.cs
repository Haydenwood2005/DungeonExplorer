using System;
using DungeonExplorer.Player;

namespace DungeonExplorer.Item.Items
{
   
    /// Represents a health potion item.
    
    public class HealthPotion : Item
    {
        private const int HealthRegen = 2;

        
        /// Initializes a new instance of the HealthPotion class.
        
        public HealthPotion() : base("Health Potion", "Restores a small amount of health.", true)
        {
           
        }

       
        // Uses the health potion on the player.
      
        public override void Use(Player.Player player)
        {
            if (!(player.Health >= player.getMaxHealth()))
            {
                Console.WriteLine("You drink the health potion and feel rejuvenated!");
                Console.WriteLine("[+2 HP]");
                player.AddHealth(HealthRegen);
                player.RemoveItem(this);
            }
            else
            {
                Console.WriteLine("You are already at full health!");
            }
        }
    }
}
