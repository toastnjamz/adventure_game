using System;

namespace DungeonAdventure
{
    //TODO impelement separate Class classes that inherit from CharacterClass (Fighter, Warlock, Rogue)
    public abstract class CharacterClass
    {
        public string ClassName { get; set; }
        public int StartingHP { get; set; }

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
