using System;

// TODO: Leave for later, but not necessary now with one form of take
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
