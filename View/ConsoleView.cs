using System;

namespace DungeonAdventure
{
	public class ConsoleView
	{
		public Input WaitForInput()
		{
			var line = Console.ReadLine();
			var tokens = line.Split(' ');
			var type = InputStringToEnum<InputType>(tokens[0]);
			switch (type)
			{
				case InputType.Go:
					if (tokens.Length > 1)
					{
						var direction = InputStringToEnum<Direction>(tokens[1]);
						return new MoveInput(direction);
					}
					ShowError("Missing parameter");
					break;
			}

			// TODO: parse input line
			throw new NotSupportedException();
		}

		EnumType InputStringToEnum<EnumType>(string token)
		{
			string op = token.Substring(0, 1).ToUpper() + token.Substring(1);
			if (Enum.TryParse(typeof(EnumType), op, out object test))
				return (EnumType)test;
			throw new ArgumentException(nameof(token));
		}

		public void Display()
		{
			Console.Write("$ ");
		}

		public void ShowGameEvent(GameEvent gameEvent)
		{
			if (gameEvent is MoveGameEvent moveGameEvent)
			{
				Console.WriteLine("Player moved from " + moveGameEvent.OldRoom.Name + " to " + moveGameEvent.NewRoom.Name);
				DescribeRoom(moveGameEvent.NewRoom);
			}
		}

		void DescribeRoom(Room room)
		{
			Console.WriteLine("You have entered a room that " + room.Description);
		}

		public void ShowError(string error)
		{
			Console.WriteLine("Error occurred: " + error);
		}
	}
}
