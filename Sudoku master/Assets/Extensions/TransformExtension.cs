using UnityEngine;

namespace Catalyst.Core.Utility
{
    public static class TransformExtension
    {
        public static void ResetWorldPosition(this Transform t)
        {
            t.position = Vector3.zero;
        }

        public static void ResetWorldRotation(this Transform t)
        {
            t.rotation = Quaternion.identity;
        }

        public static void ResetLocalPosition(this Transform t)
        {
            t.localPosition = Vector3.zero;
        }

        public static void ResetLocalRotation(this Transform t)
        {
            t.localRotation = Quaternion.identity;
        }

        public static void ResetLocalScale(this Transform t)
        {
            t.localScale = Vector3.one;
        }

        public static void AlingPositionRotation(this Transform t,Transform target)
        {
            t.position = target.position;
            t.rotation = target.rotation;
        }

        public static void AlingPosition(this Transform t,Transform target)
        {
            t.position = target.position;
        }

        public static void AlingRotation(this Transform t,Transform target)
        {
            t.rotation = target.rotation;
        }

        public static void SetLocalMatrix (this Transform transform, ref Matrix4x4 matrix) 
        {
            transform.localPosition = matrix.TranslationPart();
            transform.localRotation = matrix.RotationPart();
            transform.localScale = matrix.ScalePart();
        }

        public static void SetGlobalMatrix (this Transform transform, ref Matrix4x4 matrix) 
        {
            transform.position = matrix.TranslationPart();
            transform.rotation = matrix.RotationPart();
            transform.localScale = matrix.ScalePart();
        }

        public static Transform FindRecursive(this Transform transform, string name)
        {   
            Transform[] children = transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].name == name)
                    return children[i];
            }
            return null;
        }

    }
}