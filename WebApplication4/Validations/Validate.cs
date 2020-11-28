using System;
using System.Collections.Generic;

namespace WebApplication4.Validations
{
    public static class Validate
    {
        public static void NotNull(object theObj, string parameterName)
        {
            if (theObj == null)
            {
                throw new ArgumentNullException($"'{parameterName}'");
            }
        }

        public static void NotEmpty<T>(List<T> objects, string parameterName)
        {
            if (objects == null || objects.Count == 0)
            {
                throw new ArgumentException($"'{parameterName}' list can't be empty");
            }
        }

        public static void IntegerGreaterThanOrEqualToZero(int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Integer '{parameterName}' must be greater than or equal to zero");
            }
        }

        public static void NotNullOrWhitespace(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"{parameterName}");
            }
        }
    }
}
