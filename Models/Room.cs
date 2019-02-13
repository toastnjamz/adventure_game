using System;

namespace AdventureGame
{
    // Room objects have coordinates for their fixed location on the Map
    public class Room
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item ItemRequiredToEnter { get; set; }
        //public Item ItemInside { get; set; }

        // TODO public List<EnemyEncounter> EnemiesHere { get; } =
        // TODO new List<EnemyEncounter>();

        public Room(int xCoordinate, int yCoordinate, string name, string description, 
            Item itemRequiredToEnter = null)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
        }
    }
}
