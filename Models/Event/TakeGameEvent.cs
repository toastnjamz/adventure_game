using System;

namespace AdventureGame
{
    public class TakeGameEvent : GameEvent
    {
        public Item Item { get; private set; }

        public TakeGameEvent(Item item)
        {
            Item = item;
        }
    }
}
