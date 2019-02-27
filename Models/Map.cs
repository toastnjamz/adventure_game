using System;
using System.Collections.Generic;

namespace AdventureGame
{
    // Map class creates a list of Room objects
    public class Map
    {
        private readonly List<Room> _rooms = new List<Room>();

        internal void AddRoom(int xCoordinate, int yCoordinate, string name, string description, 
            Item itemRequiredToEnter, params Item[] RoomItems)
        {
            _rooms.Add(new Room(xCoordinate, yCoordinate, name, description, 
                itemRequiredToEnter, RoomItems));
        }

        // Returns Room object if the room matches the set of coordinates
        public Room RoomAt(int xCoordinate, int yCoordinate)
        {
            foreach (Room rm in _rooms)
            {
                if (rm.XCoordinate == xCoordinate && rm.YCoordinate == yCoordinate)
                {
                    return rm;
                }
            }
            return null;
        }
    }
}
