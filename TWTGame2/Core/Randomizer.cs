using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWTGame.Core
{
    public class Randomizer : IRandomizer
    {
        private readonly Random rand = new Random();

        public int Next()
        {
            return rand.Next();
        }

        public int Next(int maxValue)
        {
            return rand.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue);
        }

        public float NextFloat(float maxValue)
        {
            return (float)rand.NextDouble() * maxValue;
        }

        public float NextFloat(float minValue, float maxValue)
        {
            return minValue + (float)rand.NextDouble() * (maxValue - minValue);
        }
    }
}
