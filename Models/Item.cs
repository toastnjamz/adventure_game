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

        public Item(int iD, string name, string namePlural, string description)
        {
            this.ID = iD;
            this.Name = name;
            this.NamePlural = namePlural;
            this.Description = description;
        }

        public void PerformAction(Player source, Enemy target)
        {
            Action?.Execute(source, target);
        }

        // Lets the CreateItem function in the ItemFactory class make new instances of items
        public Item Clone()
        {
            return new Item(ID, Name, NamePlural, Description);
        }
    }
}
