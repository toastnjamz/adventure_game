using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AdventureGame
{
    /// <summary>
    /// Using concrete class for the player model, since we can make an instance of the base class (for now)
    /// Player model holds item inventory
    /// </summary>
    public class Player
    {
        private int _experiencePoints;
        private int _currentHitPoints;

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            private set
            {
                _experiencePoints = value;
                UpdateLevelAndMaxHitPoints();
            }
        }
        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                _currentHitPoints = value;

                if(_currentHitPoints <= 0)
                {
                    // When the player's hit points are zero or less, the player object
                    // will raise a PlayerKilled notification to all subscribed objects.
                    OnPlayerKilled();
                }
            }
        }

        public string Name { get; set; } //TODO change back to private set later
        public int Level { get; private set; }
        public int MaxHitPoints { get; private set; }
        public Room CurrentRoom { get; private set; }
        public CharacterClass CharacterClass { get; private set; } //TODO
        public List<Item> Inventory { get; set; } //TODO: Change back to private set later
        //public event EventHandler LeveledUp;
        public event EventHandler PlayerKilled;

        //TODO: Passing in arguements for now, will have CharacterClass set starting values later
        public Player(string name, int currentHitPoints, int maxHitPoints, Room currentRoom)
        {
            Name = name;
            CurrentHitPoints = currentHitPoints;
            MaxHitPoints = maxHitPoints;
            CurrentRoom = currentRoom;
            Inventory = new List<Item>();
        }

        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        private void UpdateLevelAndMaxHitPoints()
        {
            int originalLevel = Level;
            Level = (ExperiencePoints / 100) + 1;

            if (Level != originalLevel)
            {
                MaxHitPoints = Level * 10;
                //OnLeveledUp();
            }
        }

        public bool DoesNotHaveItemToEnter(Room room)
        {
            return !HasItemToEnter(room);
        }

        public void TakeDamage (int hitPointsDealt)
        {
            CurrentHitPoints =- hitPointsDealt;
        }

        public void AddItemToInventory(Item item)
        {
            Inventory.Add(item);
        }

        public void RemoveItemFromInventory(Item item)
        {
            Inventory.Remove(item);
        }

        public bool HasItemToEnter(Room room)
        {
            if(room.ItemRequiredToEnter == null)
            {
                // There is no required item to enter this room, so return "true"
                return true;
            }
            // Check if the player has the required item in their inventory
            return Inventory.Any(item => item.ID == room.ItemRequiredToEnter.ID);
        }

        //private void OnLeveledUp()
        //{
        //    // If there are no subscribers, the LeveledUp EventHandler will be null
        //    LeveledUp?.Invoke(this, EventArgs.Empty);
        //}

        private void OnPlayerKilled()
        {
            // If there are no subscribers, the PlayerKilled EventHandler will be null
            PlayerKilled?.Invoke(this, EventArgs.Empty);
        }
    }
}