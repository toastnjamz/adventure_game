using System;

namespace AdventureGame
{
	/// <summary>
	/// Main game rules engine logic
	/// </summary>
	public class Game
	{
		readonly Map _map = new Map();
		readonly Player _player = new Player();

		public Player Player { get { return _player; } }

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:AdventureGame.Game"/> is running.
		/// </summary>
		/// <value><c>true</c> if is running; otherwise, <c>false</c>.</value>
		public bool IsRunning { get; private set; } = true;

		public Game()
		{
		}

		
	}
}
