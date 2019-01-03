using System;

namespace DungeonAdventure
{
    // Room objects have coordinates for their fixed location on the Map
    //TODO Create a more dynamic (rogue-like) room arrangement on the map (no fixed coordinates) based on relation to other rooms
    public class Room
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // TODO public List<EnemyEncounter> EnemiesHere { get; }
        // TODO new List<EnemyEncounter>();
    }
}
