using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame
{
    // Static factory class creates an item and does not change after creation
    public static class ItemFactory
    {
        private static List<Item> _items;

        static ItemFactory()
        {
            _items = new List<Item>
            {
                new Weapon(1001, "Battle Axe", "Tempered, trusty.", 5, 2),
                new Weapon(1002, "Parasol", "Why tho.", 2, 1),
                new Item(001, "Dungeon Dirt", "Nothing special."),
                new Item(002, "Dead Rodent of Usual Size", "Mmm, tasty."),
                new Item(003, "Troll Tooth", "Someone's missing this."),
                new Item(004, "Ball n' Chain", "The standard fare.")
            };
        }

        // Looks through the _items list to find the item with the same ID
        // If match is found, create new instance of that object
        // If not, return null
        // Allows unique items in the game
        public static Item CreateItem(int itemID)
        {
            Item gameItem = _items.FirstOrDefault(item => item.ItemID == itemID);

            if(gameItem != null)
            {
                return gameItem.Clone();
            }

            return null;
        }
    }
}
