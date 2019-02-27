using System;

namespace AdventureGame
{
    // Static factory class creates a new map and does not change after creation
    // I know it's hideous - it'll be in an XML or JSON file someday.
    internal static class MapFactory
    {
        internal static Map CreateMap()
        {
            Map newMap = new Map();

            Item[] SecretTunnelItems = new Item[2];
            SecretTunnelItems[0] = ItemFactory.CreateItem(001);
            SecretTunnelItems[1] = ItemFactory.CreateItem(002);
           
            Item[] LarderItems = new Item[6];
            LarderItems[0] = ItemFactory.CreateItem(2001);
            LarderItems[1] = ItemFactory.CreateItem(2002);
            LarderItems[2] = ItemFactory.CreateItem(2003);
            LarderItems[3] = ItemFactory.CreateItem(2004);
            LarderItems[4] = ItemFactory.CreateItem(010);
            LarderItems[5] = ItemFactory.CreateItem(1005);

            Item[] LaboratoryItems = new Item[2];
            LaboratoryItems[0] = ItemFactory.CreateItem(009);
            LaboratoryItems[1] = ItemFactory.CreateItem(2005);

            Item[] ControlRoomItems = new Item[1];
            ControlRoomItems[0] = ItemFactory.CreateItem(005);

            Item[] BarracksItems = new Item[3];
            BarracksItems[0] = ItemFactory.CreateItem(1002);
            BarracksItems[1] = ItemFactory.CreateItem(008);
            BarracksItems[2] = ItemFactory.CreateItem(2006);

            Item[] CellBlockItems = new Item[2];
            CellBlockItems[0] = ItemFactory.CreateItem(003);
            CellBlockItems[1] = ItemFactory.CreateItem(007);

            Item[] ArmoryItems = new Item[3];
            ArmoryItems[0] = ItemFactory.CreateItem(1001);
            ArmoryItems[1] = ItemFactory.CreateItem(1003);
            ArmoryItems[2] = ItemFactory.CreateItem(1004);

            Item[] DungeonCellItems = new Item[3];
            DungeonCellItems[0] = ItemFactory.CreateItem(001);
            DungeonCellItems[1] = ItemFactory.CreateItem(004);
            DungeonCellItems[2] = ItemFactory.CreateItem(006);


            newMap.AddRoom(-1, -1, "Secret Tunnel", "a small dirt tunnel large " +
            	"enough for a single person to walk through. It’s awfully dark.", 
                null, SecretTunnelItems);

            newMap.AddRoom(0, -1, "Dungeon Entrance", "the main entrance to the " +
            	"dungeon. It's blocked by a steel-reinforced floor-to-ceiling door.", 
                null);

            newMap.AddRoom(1, -1, "Larder", "a room with cured meats and vegetables " +
            	"hanging on hooks. Sacks of grain line the back wall.", 
                null, LarderItems);

            newMap.AddRoom(-1, 0, "Laboratory",
                "a lab filled with equipment where various potions are being made. " +
                "The scent of brimstone fills the air and you can see broken glass on the floor.", 
                null, LaboratoryItems);

            newMap.AddRoom(0, 0, "Main Corridor","a large stone hallway with " +
            	"shadowy portraits on the walls.", 
                null);

            newMap.AddRoom(1, 0, "Control Room", "a room with lots of levers " +
            	"attached to chains that run out of the room through holes in the wall. " +
            	"There’s a wooden shelf in the corner of the room.", 
                null, ControlRoomItems);

            newMap.AddRoom(-1, 1, "Barracks", "a musty bunkbed-lined room with a " +
            	"table in the middle. The table's strewn with playing cards and tin cups.", 
                null, BarracksItems);

            newMap.AddRoom(0, 1, "Cell Block", "a long hallway lined with cell " +
            	"blocks on either side. Each cell is locked with a heavy steel gate.", 
                null, CellBlockItems);

            newMap.AddRoom(1, 1, "Armory", "a small room filled with racks of " +
            	"weapons and greasy pots.", 
                null, ArmoryItems);

            newMap.AddRoom(0, 2, "Dungeon Cell", "a dirt-floored cell spattered " +
            	"with blood stains and the decayed remains various severed digits.", 
                null, DungeonCellItems);

            return newMap;
        }
    }
}
