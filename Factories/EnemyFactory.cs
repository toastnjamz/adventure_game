using System;

namespace AdventureGame
{
    public static class EnemyFactory
    {
        public static Enemy GetEnemy(int enemyID)
        {
            switch (enemyID)
            {
                case 1:
                    Enemy guard = new Enemy("Guard", 10, 10, 8, 3);
                    AddLootItem(guard, 9001, 70);
                    AddLootItem(guard, 9002, 30);
                    return guard;

                case 2:
                    Enemy hugerat = new Enemy("Huge Rat", 5, 5, 5, 1);
                    AddLootItem(hugerat, 9003, 75);
                    AddLootItem(hugerat, 9004, 25);
                    return hugerat;

                case 3:
                    Enemy gelatinouscube = new Enemy("Gelatinous Cube", 7, 7, 7, 2);
                    AddLootItem(gelatinouscube, 9005, 50);
                    AddLootItem(gelatinouscube, 9006, 25);
                    AddLootItem(gelatinouscube, 9007, 25);
                    return gelatinouscube;

                default:
                    throw new NotSupportedException();
            }
        }

        private static void AddLootItem(Enemy enemy, int itemID, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                enemy.Inventory.Add(ItemFactory.CreateItem(itemID));
            }
        }
    }
}
