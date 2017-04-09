using UnityEngine;

namespace Catalyst.Core.Utility
{
    public static class QuaternionExtension
    {
        public static Matrix4x4 RotationMatrix(this Quaternion quaternion)
        {
            return Matrix4x4.TRS(Vector3.zero, quaternion, Vector3.one);
        }
    }
}