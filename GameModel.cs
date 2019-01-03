using System;

namespace DungeonAdventure
{
    /// <summary>
    /// Main game rules engine / logic
    /// </summary>
    public class GameModel
    {
        public Player CurrentPlayer { get; set; }
        public Map CurrentMap { get; set; }
        public Room CurrentRoom { get; set; }
        public bool IsRunning { get; private set; } = true;

        public Action<string> OnErrorAction; //TODO

        public bool HasLocationToNorth
        {
            get
            {
                return CurrentMap.RoomAt(CurrentRoom.XCoordinate,
                CurrentRoom.YCoordinate + 1) != null;
            }
        }

        public bool HasLocationToEast
        {
            get
            {
                return CurrentMap.RoomAt(CurrentRoom.XCoordinate + 1,
                CurrentRoom.YCoordinate) != null;
            }
        }

        public bool HasLocationToSouth
        {
            get
            {
                return CurrentMap.RoomAt(CurrentRoom.XCoordinate,
                CurrentRoom.YCoordinate - 1) != null;
            }
        }

        public bool HasLocationToWest
        {
            get
            {
                return CurrentMap.RoomAt(CurrentRoom.XCoordinate - 1,
                CurrentRoom.YCoordinate) != null;
            }
        }
    }
}
