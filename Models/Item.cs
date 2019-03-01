using System;

namespace AdventureGame
{
    // Item class that both game items and weapons are based on
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool Moveable { get; private set; }

        public Item(int iD, string name, string namePlural, string description, 
        int quantity, bool moveable)
        {
            ID = iD;
            Name = name;
            NamePlural = namePlural;
            Description = description;
            Quantity = quantity;
            Moveable = moveable;
        }

        // Lets the CreateItem function in the ItemFactory class make new instances of items
        public Item Clone()
        {
            return new Item(ID, Name, NamePlural, Description, Quantity, Moveable);
        }
    }
}
