using System;

namespace AdventureGame
{
	/// <summary>
	/// Application Entry Point.
	/// </summary>
	public class App
	{
		public static int Main(string[] args)
		{
			App app = new App();
			app.Run();
			return 0;
		}

		public void Run()
		{
			Game game = new Game();
			game.Player.ItemAcquired += OnItemAcquired;
			while (game.IsRunning)
			{

			}
		}

		void OnItemAcquired(Item item)
		{
			Console.WriteLine(string.Format("You found a {0}", item.Name));
		}

	}
}
