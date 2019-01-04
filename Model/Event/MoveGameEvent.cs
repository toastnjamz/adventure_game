using System;
namespace DungeonAdventure
{
	public class MoveGameEvent : GameEvent
	{
		public Room OldRoom { get; private set; }
		public Room NewRoom { get; private set; }

		public MoveGameEvent(Room oldRoom, Room newRoom)
		{
			OldRoom = oldRoom;
			NewRoom = newRoom;
		}
	}
}
