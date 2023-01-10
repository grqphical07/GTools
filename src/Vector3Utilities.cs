using UnityEngine;

namespace GTools
{
    public static class Vector3Utilities
    {
        /// <summary>
        /// Gets the direction between two Vector3 points.
        /// </summary>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <returns>Vector3 of the direction</returns>
        public static Vector3 Direction(Vector3 a, Vector3 b, bool normalized)
        {
            if (normalized) return (a - b).normalized;
            else return (a - b);
        }
        /// <summary>
        /// Check if Vector3 A is greater than Vector3 B
        /// </summary>
        /// <param name="a">First Value</param>
        /// <param name="b">Second Value</param>
        public static bool Vector3GreaterThan(Vector3 a, Vector3 b)
        {
            if (a.x > b.x && a.y > b.y && a.z > b.z)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Check if Vector3 A is less than Vector3 B
        /// </summary>
        /// <param name="a">First Value</param>
        /// <param name="b">Second Value</param>
        public static bool Vector3LessThan(Vector3 a, Vector3 b)
        {
            if (a.x < b.x && a.y < b.y && a.z < b.z)
            {
                return true;
            }
            else return false;
        }
    }
}
