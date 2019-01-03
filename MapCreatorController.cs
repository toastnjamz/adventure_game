using System;

namespace DungeonAdventure
{
    // Static factory class creates a new map and does not change after creation
    internal static class MapCreator
    {
        internal static Map CreateMap()
        {
            Map newMap = new Map();

            newMap.AddRoom(-1, -1, "Secret Tunnel",
                "Secret Tunnel Description");

            newMap.AddRoom(0, -1, "Dungeon Entrance",
                "Dungeon Entrance Description");

            newMap.AddRoom(1, -1, "Larder",
                "Larder Description");

            newMap.AddRoom(-1, 0, "Laboratory",
                "Lab Description");

            newMap.AddRoom(0, 0, "Main Corridor",
                "Main Corridor Description");

            newMap.AddRoom(1, 0, "Control Room",
                "Control Room Description");

            newMap.AddRoom(-1, 1, "Barracks",
                "Barracks Description");

            newMap.AddRoom(0, 1, "Cell Block",
                "Cell Block Description");

            newMap.AddRoom(1, 1, "Armory",
                "Armory Description");

            newMap.AddRoom(0, 2, "Dungeon Cell",
                "Cell Description");

            return newMap;
        }
    }
}
