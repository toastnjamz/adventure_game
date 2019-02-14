using System;

namespace AdventureGame
{
	public enum InputType
	{
		GO,
        STATS,
		LOOK,
		TAKE,
        INVENTORY,
		ATTACK,
        HELP,
        EXIT
	}

	public abstract class Input
	{
        public InputType Type { get; private set; }

        protected Input(InputType inputType)
		{
			Type = inputType;
		}
	}

	public class MoveInput : Input
	{
		public Direction Direction { get; private set; }

		public MoveInput(Direction direction) : base(InputType.GO) // Calling base class constructor and passing InputType.Go as an arguement to initialize the field
		{
			Direction = direction;
		}
	}

    public class StatsInput : Input
    {
        public StatsInput() : base(InputType.STATS) { }
    }

    public class LookAtInput : Input
    {
        public Room Room { get; private set; }
        public Item Item { get; private set; }

        public LookAtInput(Room room) : base(InputType.LOOK)
        {
            Room = room;
        }

        public LookAtInput(Item item) : base(InputType.LOOK)
        {
            Item = item;
        }

        public LookAtInput() : base(InputType.LOOK) { }
    }

    public class TakeInput : Input
    {
        public Item Item { get; private set; }

        public TakeInput(Item item) : base(InputType.TAKE) 
        {
            Item = item;
        }
        public TakeInput() : base(InputType.TAKE) { }
    }

    public class InventoryInput : Input
    {
        public InventoryInput() : base(InputType.INVENTORY) { }
    }

    public class ExitInput : Input
    {
        public ExitInput() : base(InputType.EXIT) { }
    }

    /* TODO add a class for each action in the InputType enum list to be passed to the controller to handle
     * Stats: display the playe's current stats   
     * Look without item arguement: describe the current room   
     * Look with item arguement: pass in the item as an arguement, return (or simply print) the item description
     * Take: add the item to the player's inventory (later: remove from the room)
     * Inventory: print out the player's inventory items    
     * Attack: TBD
     */
}
