using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroGe.Services
{
    /// <summary>
    /// Provides methods for generating random numbers.
    /// </summary>
    public interface IRandomizer
    {
        int Next();

        int Next(int maxValue);

        int Next(int minValue, int maxValue);

        float NextFloat(float maxValue);

        float NextFloat(float minValue, float maxValue);
    }
}
