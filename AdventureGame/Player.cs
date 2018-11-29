using System;
using System.Collections.Generic;

namespace AdventureGame
{
	public class Player
	{
		readonly List<Item> _inventory = new List<Item>();

		public delegate void ItemAcquiredFunc(Item item);
		public event ItemAcquiredFunc ItemAcquired;

		public Player()
		{
		}

		public void AddItem(Item item)
		{
			if (null == item)
				return;
			_inventory.Add(item);

			if (null != ItemAcquired)
				ItemAcquired(item);

			//ItemAcquired?.Invoke(item);
		}
	}
}
