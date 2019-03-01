using System;

namespace AdventureGame
{
	public abstract class GameEvent
	{
		public string Message { get; private set; }

        protected GameEvent(string message)
		{
            Message = message;
		}

        // Overloaded constructor with no parameters?
        protected GameEvent()
        {
            //TODO
        }
    }
}
