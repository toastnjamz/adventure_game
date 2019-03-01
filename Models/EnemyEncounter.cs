using System;

namespace AdventureGame
{
    public class EnemyEncounter
    {
        public int EnemyID { get; set; }
        public int ChanceOfEncountering { get; set; }

        public EnemyEncounter(int enemyID, int chanceOfEncountering)
        {
            EnemyID = enemyID;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}
