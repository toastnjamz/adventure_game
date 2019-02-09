using System;

namespace AdventureGame
{
    public class Enemy
    {
        public string Name { get; set; }
        public int MaxDamage;
        public int RewardExperiencePoints;
        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;

                if (_hitPoints <= 0)
                {
                    // When the enemy's hit points are zero or less, the enemy object
                    // will raise a EnemyKilled notification to all subscribed objects.
                    OnEnemyKilled();
                }
            }
        }
        public event EventHandler EnemyKilled;

        public Enemy(string name, int maxDamage, int rewardExperiencePoints, int hitPoints)
        {
            Name = name;
            MaxDamage = maxDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            HitPoints = hitPoints;
        }

        private void OnEnemyKilled()
        {
            // If there are no subscribers, the EnemyKilled EventHandler will be null
            EnemyKilled?.Invoke(this, EventArgs.Empty);
        }
    }
}
