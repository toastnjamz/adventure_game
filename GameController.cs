using System;
using System.Collections.Generic;

namespace DungeonAdventure
{
    public class GameController
    {
		GameModel _gameModel;
		Dictionary<Direction, Action> _directionHandlers;

		public Player CurrentPlayer { get; set; }
        public Map CurrentMap { get; set; }
        public Room CurrentRoom { get; set; }
        public bool IsRunning { get; private set; } = true;

		public Action<GameEvent> OnGameEvent;
		public Action<string> OnErrorAction; //TODO

        public GameController(GameModel gameModel)
        {
			_gameModel = gameModel;
			CurrentPlayer = new Player();
            CurrentPlayer.Name = "Verity";

            CurrentMap = MapCreator.CreateMap();
            CurrentRoom = CurrentMap.RoomAt(0, 2);

            CurrentPlayer.Inventory.Add(ItemCreator.CreateItem(001)); //TODO remove
            CurrentPlayer.Inventory.Add(ItemCreator.CreateItem(1001)); //TODO remove

			_directionHandlers = new Dictionary<Direction, Action>
			{
				{ Direction.North, MoveNorth },
				{ Direction.South, MoveSouth },
				{ Direction.East, MoveEast },
				{ Direction.West, MoveWest }
			};
		}

		public void HandleInput(Input input)
		{
			switch (input.Type)
			{
				case InputType.Go:
					HandleMoveInput(input as MoveInput);
					break;
				default:
					OnErrorAction?.Invoke("Unhandled input type: " + input.Type);
					break;
			}
		}

		void HandleMoveInput(MoveInput input)
		{
			if (_directionHandlers.TryGetValue(input.Direction, out var action))
				action?.Invoke();
		}

		public void TestGame()
        {
            Console.WriteLine("Player name = {0}", CurrentPlayer.Name);
            //Console.WriteLine("Player location = {0}", CurrentRoom.Name);
            IsRunning = false;

            //if (error != null && OnErrorAction != null) //TODO
                //OnErrorAction("name");
        }

        // Functions use the player's CurrentRoom X and Y coordinates
        // Add or subtract 1 based on X or Y direction
        public void MoveNorth()
        {
			var oldRoom = CurrentRoom;
            // TODO add if(HasRoomToNorth) for protection from invalid movement
            CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1);
			OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
        }

        public void MoveEast()
        {
			var oldRoom = CurrentRoom;
			// TODO add if(HasRoomToEast) for protection from invalid movement
			CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate);
			OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
		}

        public void MoveSouth()
        {
			var oldRoom = CurrentRoom;
			// TODO add if(HasRoomToSouth) for protection from invalid movement
			CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1);
			OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
		}

        public void MoveWest()
        {
			var oldRoom = CurrentRoom;
			// TODO add if(HasRoomToWest) for protection from invalid movement
			CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate);
			OnGameEvent?.Invoke(new MoveGameEvent(oldRoom, CurrentRoom));
		}
    }
}
