using System;

namespace AdventureGame
{
    //TODO impelement separate Class classes that inherit from CharacterClass (Fighter, Warlock, Rogue)
    public abstract class CharacterClass
    {
        public string ClassName { get; private set; }
        public int StartingHP { get; private set; }
        public int MaxHitPoints { get; private set; }

        public virtual string Method1()
        {
            throw new NotImplementedException();
            // TODO To be defined by the inheriting classes
        }
    }

    public class Fighter : CharacterClass
    {
        public override string Method1()
        {
            return base.Method1();
        }
    }
}
