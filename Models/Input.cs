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

        // Calling base class constructor and passing InputType.Go as an arguement to initialize the field
        public MoveInput(Direction direction) : base(InputType.GO)
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
        public string LookInput { get; private set; }

        public LookAtInput(string lookInput) : base(InputType.LOOK)
        {
            LookInput = lookInput;
        }
    }

    public class TakeInput : Input
    {
        public string ItemName { get; private set; }

        public TakeInput(string itemName) : base(InputType.TAKE)
        {
            ItemName = itemName;
        }
    }

    public class InventoryInput : Input
    {
        public InventoryInput() : base(InputType.INVENTORY) { }
    }

    public class ExitInput : Input
    {
        public ExitInput() : base(InputType.EXIT) { }
    }
}
