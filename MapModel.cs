using System;
using System.Collections.Generic;

namespace DungeonAdventure
{
    // Map class creates a list of Room objects
    public class Map
    {
        private List<Room> _rooms = new List<Room>();

        internal void AddRoom(int xCoordinate, int yCoordinate, string name, string description)
        {
            Room rm = new Room
            {
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate,
                Name = name,
                Description = description
            };

            _rooms.Add(rm);
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
