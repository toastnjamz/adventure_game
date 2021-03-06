using System;

namespace AdventureGame
{
    /// <summary>
    /// Main game rules engine / logic
    /// </summary>
    public class GameLogic
    {
        public Map CurrentMap { get; private set; }
        public Room CurrentRoom { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Enemy CurrentEnemy { get; private set; }

        public Action<string> OnErrorAction; //TODO
        public Action<GameEvent> OnGameEvent; //TODO

        public bool HasLocationToNorth =>
            CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1) != null;

        public bool HasLocationToEast =>
            CurrentMap.RoomAt(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate) != null;

        public bool HasLocationToSouth =>
            CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1) != null;

        public bool HasLocationToWest =>
            CurrentMap.RoomAt(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate) != null;

        //TODO does this really go here? Should it be in its own controller?
        public GameLogic()
        {
            CurrentMap = MapFactory.CreateMap();
            CurrentRoom = CurrentMap.RoomAt(0, 2);
            CurrentPlayer = new Player("Thorin", 10, 10, CurrentRoom); //TODO remove test arguements
        }

        // Movement methods use the player's CurrentRoom X and Y coordinates
        // Add or subtract 1 based on X or Y direction
        // TODO refactor
        public void MoveNorth()
        {
            if (HasLocationToNorth && CurrentPlayer.HasItemToEnter(CurrentRoom))
            {
                var oldRoom = CurrentRoom;
                CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1);
                OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
            }
            else if (CurrentPlayer.DoesNotHaveItemToEnter(CurrentRoom))
            {
                Console.WriteLine("You need a {0} to enter this location.", CurrentRoom.ItemRequiredToEnter);
            }
            else
            {
                OnErrorAction?.Invoke("You can't move North.");
            }
        }

        public void MoveEast()
        {
            if (HasLocationToEast && CurrentPlayer.HasItemToEnter(CurrentRoom))
            {
                var oldRoom = CurrentRoom;
                CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate);
                OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
            }
            else if (CurrentPlayer.DoesNotHaveItemToEnter(CurrentRoom))
            {
                Console.WriteLine("You need a {0} to enter this location.", CurrentRoom.ItemRequiredToEnter);
            }
            else
            {
                OnErrorAction?.Invoke("You can't move East.");
            }
        }

        public void MoveSouth()
        {
            if (HasLocationToSouth && CurrentPlayer.HasItemToEnter(CurrentRoom))
            {
                var oldRoom = CurrentRoom;
                CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1);
                OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
            }
            else if (CurrentPlayer.DoesNotHaveItemToEnter(CurrentRoom))
            {
                Console.WriteLine("You need a {0} to enter this location.", CurrentRoom.ItemRequiredToEnter);
            }
            else
            {
                OnErrorAction?.Invoke("You can't move South.");
            }
        }

        public void MoveWest()
        {
            if (HasLocationToWest && CurrentPlayer.HasItemToEnter(CurrentRoom))
            {
                var oldRoom = CurrentRoom;
                CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate);
                OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
            }
            else if (CurrentPlayer.DoesNotHaveItemToEnter(CurrentRoom))
            {
                Console.WriteLine("You need a {0} to enter this location.", CurrentRoom.ItemRequiredToEnter);
            }
            else
            {
                OnErrorAction?.Invoke("You can't move West.");
            }
        }

        //TODO (Later): Use TakeGameEvent logic here when operation becomes more complex
        public void TakeItemFromRoom(Item item)
        {
            if (item.Moveable == true) 
            {
                // Doesn't really work this way:
                //OnGameEvent?.Invoke(new TakeGameEvent(item));
                CurrentRoom.RemoveItemFromRoomInventory(item);
                CurrentPlayer.AddItemToInventory(item);
            }
            else
            {
                OnErrorAction?.Invoke("You can't take that item with you.");
            }
        }

        private void GetEnemyAtLocation()
        {
            CurrentEnemy = CurrentRoom.GetEnemy();
        }
    }
}
