using System;

namespace AdventureGame
{
    // Static factory class creates a new map and does not change after creation
    internal static class MapFactory
    {
        internal static Map CreateMap()
        {
            Map newMap = new Map();

            newMap.AddRoom(-1, -1, "Secret Tunnel",
                "Secret Tunnel Description", null);

            newMap.AddRoom(0, -1, "Dungeon Entrance",
                "Dungeon Entrance Description", null);

            newMap.AddRoom(1, -1, "Larder",
                "Larder Description", null);

            newMap.AddRoom(-1, 0, "Laboratory",
                "Lab Description", null);

            newMap.AddRoom(0, 0, "Main Corridor",
                "Main Corridor Description", null);

            newMap.AddRoom(1, 0, "Control Room",
                "Control Room Description", null);

            newMap.AddRoom(-1, 1, "Barracks",
                "Barracks Description", null);

            newMap.AddRoom(0, 1, "Cell Block",
                "Cell Block Description", null);

            newMap.AddRoom(1, 1, "Armory",
                "Armory Description", null);

            newMap.AddRoom(0, 2, "Dungeon Cell",
                "Cell Description", null);

            return newMap;
        }
    }
}
