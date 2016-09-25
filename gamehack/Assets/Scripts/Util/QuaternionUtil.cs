using UnityEngine;

namespace Assets.Scripts.Util
{
    static class QuaternionUtil
    {
        public static Quaternion FromDirection2D(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
