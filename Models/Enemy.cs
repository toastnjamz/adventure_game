using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Enemy
    {
        private int _currentHitPoints;
        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                _currentHitPoints = value;

                if (_currentHitPoints <= 0)
                {
                    // When the enemy's hit points are zero or less, the enemy object
                    // will raise a EnemyKilled notification to all subscribed objects.
                    OnEnemyKilled();
                }
            }
        }

        public string Name { get; private set; }
        public int MaxHitPoints { get; private set; }
        public int MaxDamage { get; private set; }
        public int RewardExperiencePoints { get; private set; }
        //public int RewardGold { get; private set; } TODO later
        public List<Item> Inventory { get; private set; }
        public event EventHandler EnemyKilled;

        public Enemy(string name, int currentHitPoints, int maxHitPoints, 
        int maxDamage, int rewardExperiencePoints)
        {
            Name = name;
            CurrentHitPoints = currentHitPoints;
            MaxHitPoints = maxHitPoints;
            MaxDamage = maxDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            Inventory = new List<Item>();
        }

        private void OnEnemyKilled()
        {
            // If there are no subscribers, the EnemyKilled EventHandler will be null
            EnemyKilled?.Invoke(this, EventArgs.Empty);
        }
    }
}
