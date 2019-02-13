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
                new Weapon(1001, "Battle Axe", "Battle Axes", "Tempered, trusty.", 1, 5, 2),
                new Weapon(1002, "Parasol", "Parasols", "Why tho.", 1, 2, 1),
                new Item(001, "Dungeon Dirt", "Dungeon Dirt", "Nothing special.", 1),
                new Item(002, "Dead Rodent of Usual Size", "Dead Rodents of Unusual Size", "Mmm, tasty.", 1),
                new Item(003, "Troll Tooth", "Troll Teeth", "Someone's missing this.", 1),
                new Item(004, "Ball n' Chain", "Balls n' Chains", "The standard fare.", 1),
                new Item(005, "Key", "Keys", "Looks like it opens something.", 1)
            };
        }

        // Looks through the _items list to find the item with the same ID
        // If match is found, create new instance of that object
        // If not, return null
        // Allows unique items in the game
        public static Item CreateItem(int itemID)
        {
            Item gameItem = _items.FirstOrDefault(item => item.ID == itemID);

            if(gameItem != null)
            {
                return gameItem.Clone();
            }
            return null;
        }
    }
}
