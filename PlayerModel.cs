using System;
using System.Collections.ObjectModel;

namespace DungeonAdventure
{
    /// <summary>
    /// Using concrete class for the player model, since we can make an instance of the base class (for now)
    /// Player model holds item inventory
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public string CharacterClass; //TODO
        public int HitPoints; //TODO

        public ObservableCollection<Item> Inventory { get; private set; }

        public Player()
        {
            Inventory = new ObservableCollection<Item>();
        }
    }
}
