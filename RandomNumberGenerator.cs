using System;

namespace AdventureGame
{
    public static class RandomNumberGenerator
    {
        private static readonly Random _generator = new Random();

        public static int NumberBetween(int minValue, int maxValue)
        {
            return _generator.Next(minValue, maxValue + 1);
        }
    }
}