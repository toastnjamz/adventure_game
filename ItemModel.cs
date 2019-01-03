using System;

namespace DungeonAdventure
{
    // Item class that both game items and weapons are based on
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(int itemID, string name, string description)
        {
            this.ItemID = itemID;
            this.Name = name;
            this.Description = description;
        }

        // Lets the CreateItem function in the ItemCreator class make new instances of weapon items
        public Item Clone()
        {
            return new Item(ItemID, Name, Description);
        }
    }
}
