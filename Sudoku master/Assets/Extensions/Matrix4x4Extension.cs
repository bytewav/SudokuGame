using UnityEngine;

namespace Catalyst.Core.Utility
{
    public static class Matrix4x4Extension
    {
        public static Matrix4x4 FromVector(Vector3 position,Vector3 direction,Vector3 Up)
        {
            Vector3 Z = direction.normalized;
            Vector3 X = Vector3.Cross(Up,Z).normalized;
            Vector3 Y = Vector3.Cross(Z,X).normalized;

            Matrix4x4 matrice = new Matrix4x4();
            matrice.SetColumn(0, X.ToVector4(0));
            matrice.SetColumn(1, Y.ToVector4(0));
            matrice.SetColumn(2, Z.ToVector4(0));
            matrice.SetColumn(3, position.ToVector4(1));

            return matrice;
        }

        public static Vector3 TranslationPart(this Matrix4x4 matrix) 
        {
            Vector3 translate;
            translate.x = matrix.m03;
            translate.y = matrix.m13;
            translate.z = matrix.m23;
            return translate;
        }

        public static Quaternion RotationPart(this Matrix4x4 matrix) 
        {
            Vector3 forward;
            forward.x = matrix.m02;
            forward.y = matrix.m12;
            forward.z = matrix.m22;

            Vector3 upwards;
            upwards.x = matrix.m01;
            upwards.y = matrix.m11;
            upwards.z = matrix.m21;

            return Quaternion.LookRotation(forward, upwards);
        }

        public static Vector3 ScalePart(this Matrix4x4 matrix) 
        {
            Vector3 scale;
            scale.x = matrix.GetColumn(0).magnitude;
            scale.y = matrix.GetColumn(1).magnitude;
            scale.z = matrix.GetColumn(2).magnitude;
            return scale;
        }

        public static Vector3 X_Part(this Matrix4x4 matrix) 
        {
            Vector4 x = matrix.GetColumn(0);
            return new Vector3(x.x,x.y,x.z);
        }
        public static Vector3 Y_Part(this Matrix4x4 matrix) 
        {
            Vector4 y = matrix.GetColumn(1);
            return new Vector3(y.x,y.y,y.z);
        }
        public static Vector3 Z_Part(this Matrix4x4 matrix) 
        {
            Vector4 z = matrix.GetColumn(2);
            return new Vector3(z.x,z.y,z.z);
        }

    }
}