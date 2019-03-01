using System;

namespace AdventureGame
{
    // Weapon class inherits from the Item class with added min/max damage properties
    public class Consumable : Item
    {
        public int HitPointsOfHealing { get; set; }

        public Consumable(int itemID, string name, string namePlural, string description, 
        int quantity, bool moveable, int hitPointsOfHealing)
            : base(itemID, name, namePlural, description, quantity, moveable)
        {
            HitPointsOfHealing = hitPointsOfHealing;
        }

        // Lets the CreateItem function in the ItemCreator class make new instances of consumable items
        public new Consumable Clone()
        {
            return new Consumable(ID, Name, NamePlural, Description, Quantity, 
            Moveable, HitPointsOfHealing);
        }

        //public void PerformAction(Player source, Player target)
        //{
        //    Action?.Execute(source, target);
        //}
    }
}
