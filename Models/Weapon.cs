using System;

namespace AdventureGame
{
    // Weapon class inherits from the Item class with added min/max damage properties
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(int itemID, string name, string namePlural, string description, 
        int quantity, bool moveable, int minDamage, int maxDamage)
            : base(itemID, name, namePlural, description, quantity, moveable)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        // Lets the CreateItem function in the ItemCreator class make new instances of weapon items
        public new Weapon Clone()
        {
            return new Weapon(ID, Name, NamePlural, Description, Quantity, 
            Moveable, MinDamage, MaxDamage);
        }

        //public void PerformAction(Player source, Enemy target)
        //{
        //    Action?.Execute(source, target);
        //}
    }
}