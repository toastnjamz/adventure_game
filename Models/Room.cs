using System;
using System.Collections.Generic;

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

        // TODO public List<EnemyEncounter> EnemiesHere { get; } =
        // TODO new List<EnemyEncounter>();

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
        }

        public void AddItemToRoomInventory(Item item)
        {
            RoomInventory.Add(item);
        }

        public void RemoveItemFromRoomInventory(Item item)
        {
            RoomInventory.Remove(item);
        }
    }
}
