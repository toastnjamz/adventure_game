using System;
using System.Collections.Generic;

namespace AdventureGame
{
	public class Room
	{
		Room[] _neighbours = new Room[8];


		public Room()
		{
		}

		public List<Room> GetPossibleNeighbours()
		{
			List<Room> rooms = new List<Room>();
			for (int i = 0; i < _neighbours.Length; ++i)
			{
				if (null != _neighbours[i])
					rooms.Add(_neighbours[i]);
			}
			return rooms;
		}

		public Room GetNeighbour(Direction direction)
		{
			return _neighbours[(int)direction];
		}
	}
}
