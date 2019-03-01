using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame
{
    /// <summary>
    /// Room objects have coordinates for their fixed location on the Map
    /// Rooms have their own inventory list of Item objects
    /// </summary>
    public class Room
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Item ItemRequiredToEnter { get; private set; }
        public List<Item> RoomInventory { get; private set; }
        public List<EnemyEncounter> EnemiesHere { get; private set; }

        public Room(int xCoordinate, int yCoordinate, string name, string description, 
            Item itemRequiredToEnter = null, params Item[] RoomItems)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            RoomInventory = new List<Item>(RoomItems);
            if (itemRequiredToEnter != null)
            {
                ItemRequiredToEnter = itemRequiredToEnter;
            }
            EnemiesHere = new List<EnemyEncounter>();
        }

        public void AddItemToRoomInventory(Item item)
        {
            RoomInventory.Add(item);
        }

        public void RemoveItemFromRoomInventory(Item item)
        {
            RoomInventory.Remove(item);
        }

        // Populates the EnemyEncounter List (list of enemy encounter objects for a room)
        public void AddEnemy(int enemyID, int chanceOfEncountering)
        {
            EnemiesHere.Add(new EnemyEncounter(enemyID, chanceOfEncountering));
        }

        // Determines which enemy the room has and creates a new instance of the enemy
        // If there are no enemies in the EnemyEncounter list, return null
        // Else add all ChanceOfEncountering and get a random number between 1 and ChanceOfEncountering
        // Then loop through EnemyEncounter objects to find the enenmy
        public Enemy GetEnemy()
        {
            if (!EnemiesHere.Any())
            {
                return null;
            }

            int totalChances = EnemiesHere.Sum(e => e.ChanceOfEncountering);
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);
            int total = 0;

            foreach(EnemyEncounter enemyEncounter in EnemiesHere)
            {
                total += enemyEncounter.ChanceOfEncountering;

                if (randomNumber <= total)
                {
                    return EnemyFactory.GetEnemy(enemyEncounter.EnemyID);
                }
            }
            throw new ArgumentException("The enemy in this room is on a coffee break, come back later.");
        }
    }
}
