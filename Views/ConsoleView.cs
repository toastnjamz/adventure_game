using System;

namespace AdventureGame
{
	public class ConsoleView
	{
        public Input WaitForInput()
		{
			// Takes user input, splits into an array of substrings, and passes to InputStringToEnum method 
            var line = Console.ReadLine();
			var tokens = line.Split(' ');
			var type = InputStringToEnum<InputType>(tokens[0]);
			
            switch (type)
			{
				case InputType.GO:
					if (tokens.Length > 1)
					{
						var direction = InputStringToEnum<Direction>(tokens[1]);
                        return new MoveInput(direction); //TODO: is it ok to just use new keyword here and not have a named instance of the class?
					}
					ShowError("Missing direction parameter.");
					break;

                case InputType.STATS:
                    return new StatsInput();

                // TODO create a dictionary of all items in the game?
                case InputType.LOOK:
                    return new LookAtInput();
                
                case InputType.TAKE:
                    //if (tokens.Length > 1)
                    //{
                    //    var item = list.Find(x => x.Name == )
                    //    return new TakeInput(item);
                    //}
                    //ShowError("Invalid item input.");
                    //break;
                    return new TakeInput();

                case InputType.INVENTORY:
                    return new InventoryInput();
                
                case InputType.ATTACK:
                    //TODO
                    break;
                
                case InputType.HELP:
                    DisplayAvailableCommands();
                    break;
                
                case InputType.EXIT:
                    // Exits the game by breaking the IsRunning loop in the app controller
                    return new ExitInput();

                default:
                    throw new NotSupportedException();
            }
            return null;
        }

        // Attempts to convert substring from user input to enum value
		private EnumType InputStringToEnum<EnumType>(string token)
		{
			string op = token.Substring(0).ToUpper();
			if (Enum.TryParse(typeof(EnumType), op, out object test))
            {
                return (EnumType)test;
            }
            throw new ArgumentException(nameof(token));
		}

        // User prompt
        public void Display()
		{
			Console.Write("$ ");
		}

        // Displays the player's current location
        public void DisplayCurrentRoom(Room room)
        {
            Console.WriteLine("You are now in a {0}.", room.Name);
        }

        // Describes the payer's current room
        public void DescribeCurrentRoom(Room room)
        {
            Console.WriteLine("This room..." + room.Description);
        }

        // Prints the player's current stats
        public void DisplayPlayerStats(Player CurrentPlayer)
        {
            Console.WriteLine("Current hit points: {0}", CurrentPlayer.CurrentHitPoints);
            Console.WriteLine("Maximum hit points: {0}", CurrentPlayer.MaxHitPoints);
            Console.WriteLine("Experience points: {0}", CurrentPlayer.ExperiencePoints);
            Console.WriteLine("Level: {0}", CurrentPlayer.Level);
        }

        // Displays the player's current inventory items
        public void DisplayInventory(Player CurrentPlayer)
        {
            foreach (Item item in CurrentPlayer.Inventory)
                Console.WriteLine(item.Name);
        }

        // Displays help menu
        private void DisplayAvailableCommands()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("=================================================");
            Console.WriteLine("Go North - Move North");
            Console.WriteLine("Go South - Move South");
            Console.WriteLine("Go East - Move East");
            Console.WriteLine("Go West - Move West");
            Console.WriteLine("Look - Get a description of your current location");
            Console.WriteLine("Take - Pick up item");
            Console.WriteLine("Inventory - Display your inventory");
            Console.WriteLine("Attack - Fight monster");
            Console.WriteLine("Exit - Quit the game");
        }

        public void ShowGameEvent(GameEvent gameEvent)
		{
			if (gameEvent is MoveGameEvent moveGameEvent)
			{
				Console.WriteLine("Player moved from " + moveGameEvent.OldRoom.Name + " to " + moveGameEvent.NewRoom.Name);
				DescribeCurrentRoom(moveGameEvent.NewRoom);
			}
            else if (gameEvent is TakeGameEvent takeGameEvent)
            {
                Console.WriteLine("You've added a {0} to your inventory.", takeGameEvent.Item);
            }
            // else TODO: add display results for other games events
        }

		public void ShowError(string error)
		{
			Console.WriteLine("Error occurred: " + error);
		}
    }
}
