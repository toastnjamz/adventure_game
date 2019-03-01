using System;

// TODO: Potentially remove all together (may not need this event type)
namespace AdventureGame
{
    public class TakeGameEvent : GameEvent
    {
        public Item Item { get; private set; }

        public TakeGameEvent(Item item)
        {
            Item = item;
            //GameController.CurrentRoom.RemoveItemFromRoomInventory(item);
            //GameController.CurrentPlayer.AddItemToInventory(item);
        }
    }
}
