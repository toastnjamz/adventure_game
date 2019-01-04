using System;
namespace DungeonAdventure
{
	public enum InputType
	{
		Noop,
		Go,
		Look,
		Take,
		Attack
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

		public MoveInput(Direction direction) : base(InputType.Go)
		{
			Direction = direction;
		}
	}
}
