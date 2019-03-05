using System;
using System.Collections.Generic;
using System.Linq;

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

            CurrentPlayer.PlayerWon += HandlePlayerWon;
            CurrentPlayer.PlayerKilled += HandlePlayerKilled;
            CurrentPlayer.PlayerLeveledUp += HandlePlayerLeveledUp;

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
        private void HandleMoveInput(MoveInput input)
        {
            if (_directionHandlers.TryGetValue(input.Direction, out var action))
                action?.Invoke();
            else
                _view.ShowError("Value not found.");
        }

        // Describes the room or an item in the room depending on what the player enters
        private void HandleLookInput(LookAtInput input)
        {
            if (input.LookInput == "Room" || input.LookInput == "room")
            {
                _view.DescribeCurrentRoom(CurrentRoom);
            }
            else if (CurrentRoom.RoomInventory.Exists(x => x.Name == input.LookInput))
            {
                Item targetItem = CurrentRoom.RoomInventory.First(x => x.Name == input.LookInput);
                _view.DescribeItem(targetItem);
            }
            else
            {
                _view.ShowError("That item doesn't exist here.");
            }
        }

        // Takes the player's current stats and passes to the view to print
        private void HandleStatsInput(StatsInput input)
        {
            _view.DisplayPlayerStats(CurrentPlayer);
        }

        // Verifies TakeInput item is an actual item in the room before passing to the rules engine for further verification
        private void HandleTakeInput(TakeInput input)
        {
            if (CurrentRoom.RoomInventory.Exists(x => x.Name == input.ItemName))
            {
                Item targetItem = CurrentRoom.RoomInventory.First(x => x.Name == input.ItemName);
                _gameLogic.TakeItemFromRoom(targetItem);
            }
            else
            {
                _view.ShowError("That item doesn't exist here.");
            }
        }

        // Takes the player's current list of inventory items and passes to the view to print
        private void HandleInventoryInput(InventoryInput input)
        {
            _view.DisplayInventory(CurrentPlayer);
        }

        void OnGameEvent(GameEvent gameEvent)
        {
            _view.ShowGameEvent(gameEvent);
        }

        void OnError(string errorName)
        {
            _view.ShowError(errorName);
        }

        private void HandlePlayerWon(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("You won! You live to cause dwarven debauchery another day.");
        }

        private void HandlePlayerKilled(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("You died. Better luck next time.");
        }

        private void HandlePlayerLeveledUp(object sender, PlayerLeveledUpEventArgs eventArgs)
        {
            Console.WriteLine("Leveled up! You are now level {0}.", eventArgs.Level);
            //Console.WriteLine("Leveled up!");
        }
    }
}
