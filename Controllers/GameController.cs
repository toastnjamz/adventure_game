using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class GameController
    {
        // Declaring Model and View variables
        private GameLogic _gameLogic;
        private ConsoleView _view;
        Player CurrentPlayer { get { return _gameLogic.CurrentPlayer; } }
        Map CurrentMap { get { return _gameLogic.CurrentMap; } }
        Room CurrentRoom { get { return _gameLogic.CurrentRoom; } }

        // Declaring Controller variables
        private Dictionary <Direction, Action> _directionHandlers;
        public bool IsRunning { get; private set; } = true;

        // Initializing Model and View variables from App.cs 
        public GameController(GameLogic gameModel, ConsoleView consoleView)
        {
			_gameLogic = gameModel;
            _view = consoleView;

            _gameLogic.OnErrorAction += OnError;   //Registering OnError with _gameLogic.OnErrorAction
            _gameLogic.OnGameEvent += OnGameEvent; //Registering OnGameEvent with _gameLogic.OnGameEvent

            _directionHandlers = new Dictionary<Direction, Action>
			{
				{ Direction.NORTH, _gameLogic.MoveNorth },
				{ Direction.SOUTH, _gameLogic.MoveSouth },
				{ Direction.EAST, _gameLogic.MoveEast },
				{ Direction.WEST, _gameLogic.MoveWest }
			};

            CurrentPlayer.PlayerKilled += HandlePlayerKilled;
        }

        public void StartGame()
        {
            GameIntro.WriteAsciiTitle();
            GameIntro.IntroText();
        }

        // Takes user input from the View and translates into actions
        public void HandleInput(Input input)
		{
            if (null == input)
                return;

			switch (input.Type)
			{
                // If InputType is "GO", convert to reference type MoveInput and pass to the HandleMoveInput method
                case InputType.GO:
					HandleMoveInput(input as MoveInput); //TODO if conversion fails, show null?
					break;

                case InputType.STATS:
                    HandleStatsInput(input as StatsInput);
                    break;

                case InputType.LOOK:
                    HandleLookInput(input as LookAtInput);
                    break;

                case InputType.TAKE:
                    HandleTakeInput(input as TakeInput);
                    break;

                case InputType.INVENTORY:
                    HandleInventoryInput(input as InventoryInput);
                    break;

                case InputType.ATTACK:
                    //TODO
                    break;

                case InputType.EXIT:
                    Console.WriteLine("Beat it, geek!");
                    IsRunning = false;
                    break;

                default:
                    _view.ShowError("Unhandled input type: " + input.Type);
					break;
			}
		}

        // Takes user movement input from the View and translates into movement action
        void HandleMoveInput(MoveInput input)
        {
            if (_directionHandlers.TryGetValue(input.Direction, out var action))
                action?.Invoke();
            else
                _view.ShowError("Value not found.");
        }

        // TODO: Add LookAt Item
        private void HandleLookInput(LookAtInput input)
        {
            _view.DescribeCurrentRoom(CurrentRoom);
        }

        private void HandleStatsInput(StatsInput input)
        {
            _view.DisplayPlayerStats(CurrentPlayer);
        }

        private void HandleTakeInput(TakeInput input)
        {
            //TODO
        }

        private void HandleInventoryInput(InventoryInput input)
        {
            _view.DisplayInventory(CurrentPlayer);
        }

        public Item DoesItemExistInRoom(Item item)
        {
            //TODO
            if (CurrentRoom.)
            return item;
        }

        void OnGameEvent(GameEvent gameEvent)
        {
            _view.ShowGameEvent(gameEvent);
        }

        void OnError(string errorName)
        {
            _view.ShowError(errorName);
        }

        private void HandlePlayerKilled(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("You died. Better luck next time.");
        }
    }
}
