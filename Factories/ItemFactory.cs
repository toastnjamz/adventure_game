using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame
{
    /// <summary>
    /// Static factory class creates a master list of items and does not change after creation
    /// </summary>

    public static class ItemFactory
    {
        // Attempt to create a dictionary of strings (to pick up later):
        //private static Dictionary<string, List<Item>> _items;

        //static ItemFactory()
        //{
        //    _items = new Dictionary<string, List<Item>>
        //    {
        //        _items.Add("Battle Axe", new Weapon(1001, "Battle Axe", "Battle Axes", "Tempered, trusty.", 1, 5, 2)),
        //    };
        //}

        //private static Dictionary<string, Item> _items;

        //static ItemFactory()
        //{
        //    Weapon BattleAxe = new Weapon(1001, "Battle Axe", "Battle Axes", "Tempered, trusty.", 1, 2, 5);
        //    Weapon GreaterAxe = new Weapon(1002, "Greater Axe", "Greater Axes", "Sturdy and a little fancy.", 1, 5, 7);
        //    Weapon LesserAxe = new Weapon(1003, "Lesser Axe", "Lesser Axes", "Not the best quality, but it'll do.", 1, 2, 3);
        //    Weapon Parasol = new Weapon(1004, "Parasol", "Parasols", "Why tho.", 1, 1, 2);
        //    Item DungeonDirt = new Item(001, "Dungeon Dirt", "Dungeon Dirt","Nothing special.", 1);
        //    Item DeadRodent = new Item(002, "Dead Rodent of Usual Size", "Dead Rodents of Unusual Size", "Mmm, tasty.", 1);
        //    Item TrollTooth = new Item(003, "Troll Tooth", "Troll Teeth", "Someone's missing this.", 1);
        //    Item BallnChain = new Item(004, "Ball n' Chain", "Balls n' Chains", "The standard fare.", 1);
        //    Item SkeletonKey = new Item(005, "Skeleton Key", "Skeleton Keys", "Looks like it opens something.", 1);

        //    _items = new Dictionary<string, Item>
        //    {
        //        { BattleAxe.Name, BattleAxe },
        //        { GreaterAxe.Name, GreaterAxe },
        //        { LesserAxe.Name, LesserAxe },
        //        { Parasol.Name, Parasol },
        //        { DungeonDirt.Name, DungeonDirt },
        //        { DeadRodent.Name, DeadRodent },
        //        { TrollTooth.Name, TrollTooth },
        //        { BallnChain.Name, BallnChain },
        //        { SkeletonKey.Name, SkeletonKey }
        //    };
        //}

        private static List<Item> _itemsMasterList;

        static ItemFactory()
        {
            _itemsMasterList = new List<Item>
            {
                new Weapon(1001, "Battle Axe", "Battle Axes", "Tempered, trusty.", 1, true, 2, 5),
                new Weapon(1002, "Greater Axe", "Greater Axes", "Sturdy and a wee bit fancy.", 1, true, 5, 7),
                new Weapon(1003, "Lesser Axe", "Lesser Axes", "Not the best quality, but it'll do.", 1, true, 2, 3),
                new Weapon(1004, "Parasol", "Parasols", "Why tho.", 1, true, 1, 2),
                new Weapon(1005, "Battle Toaster", "Battle Toasters", "Shoots sharp toast. Handy!", 1, true, 3, 5),
                new Weapon(1006, "Sharpened Bit of Mango", "Sharpend Bits of Mango", "So pointy sweeeet!", 1, true, 1, 1),
                new Item(001, "Dungeon Dirt", "Dungeon Dirt", "It's dirt. Nothing special.", 1, true),
                new Item(002, "Dead Rodent of Usual Size", "Dead Rodents of Unusual Size", "Mmm, tasty.", 1, true),
                new Item(003, "Troll Tooth", "Troll Teeth", "Someone's missing this.", 1, true),
                new Item(004, "Ball n' Chain", "Balls n' Chains", "The standard fare.", 1, false),
                new Item(005, "Skeleton Key", "Skeleton Keys", "Looks like it opens something.", 1, true),
                new Item(006, "Sharpened Bit of Bone", "Sharpened Bits of Bone", "Does this look like a lockpick to you?", 1, true),
                new Item(007, "Wooden Stool", "Wooden Stools", "Fit for sittin'.", 1, true),
                new Item(008, "Playing Cards", "Playing Cards", "Do they have naked trolls on them!?", 1, true),
                new Item(009, "Dusty Tome", "Dusty Tomes", "An ancient-looking manuscript.", 1, true),
                new Item(010, "Sack of Grain", "Sacks of Grain", "Sure looks heavy...", 1, false),
                new Consumable(2001, "Cured Sausage", "Cured Sausages", "Classic larder item.", 1, true, 10),
                new Consumable(2002, "Baguette", "Baguettes", "Add a bottle of wine and you'll have yourself a RomCom.", 1, true, 4),
                new Consumable(2003, "Wedge of Camembert", "Wedges of Camembert", "A whole wheel of cheese!", 1, true, 7),
                new Consumable(2004, "Kozy Shack Pudding", "Kozy Shack Pudding", "Only the best in this dungeon!", 1, true, 3),
                new Consumable(2005, "Vial of Gold Liquid", "Vials of Gold Liquid", "What could it be!", 1, true, 50),
                new Consumable(2006, "Jug of Cider", "Jugs of Cider", "The booze of choice in these here parts.", 1, true, -2),
                new Weapon(9001, "Lesser Sword", "Lesser Swords", "A simple defensive weapon.", 1, true, 2, 3),
                new Item(9002, "Bar of Soap", "Bars of Soap", "Guess he dropped it.", 1, true),
                new Item(9003, "Rodent Fur", "Rodent Furs", "Looks like it had the mange.", 1, true),
                new Item(9004, "Rodent Tail", "Rodent Tails", "It's of unusually large size.", 1, true),
                new Item(9005, "Yellowed Skeleton", "Yellowed Skeletons", "The remains of an unfortunate victim.", 1, true),
                new Item(9006, "False Teeth", "False Teeth", "All the better to bite you with.", 1, true),
                new Item(9007, "Poo", "Poos", "Dungeon monsters gotta go somewhere!", 1, true)
            };
        }

        // Looks through the _items list to find the item with the same ID
        // If match is found, create new instance of that object
        // If not, return null
        // Allows unique items in the game
        public static Item CreateItem(int itemID)
        {
            Item gameItem = _itemsMasterList.FirstOrDefault(item => item.ID == itemID);

            if(gameItem != null)
            {
                return gameItem.Clone();
            }
            return null;
        }
    }
}
