using UnityEngine;

namespace GTools
{
    public static class Vector2Utilities
    {
        /// <summary>
        /// Gets the direction between two Vector2 points
        /// </summary>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <returns>Vector2 of the direction</returns>
        public static Vector2 Direction(Vector2 a, Vector2 b, bool normalized)
        {
            if (normalized) return (a - b).normalized;
            else return (a - b);

        }
        /// <summary>
        /// Check if Vector2 A is greater than Vector 2 B
        /// </summary>
        /// <param name="a">First Value</param>
        /// <param name="b">Second Value</param>
        public static bool Vector2GreaterThan(Vector2 a, Vector2 b)
        {
            if (a.x > b.x && a.y > b.y)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Check if Vector2 A is less than Vector 2 B
        /// </summary>
        /// <param name="a">First Value</param>
        /// <param name="b">Second Value</param>
        public static bool Vector2LessThan(Vector2 a, Vector2 b)
        {
            if (a.x < b.x && a.y < b.y)
            {
                return true;
            }
            else return false;
        }
    }
}