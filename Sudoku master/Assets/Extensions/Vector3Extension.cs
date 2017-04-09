using UnityEngine;

namespace Catalyst.Core.Utility
{
    /// <summary>
    /// Vector3 extension.
    /// </summary>
    public static class Vector3Extension
    {
        public static Vector4 ToVector4(this Vector3 v,int w) { return new Vector4(v.x,v.y,v.z,w); }
        public static Quaternion ToQuaternion(this Vector3 v) { return Quaternion.Euler(v.x, v.y, v.z); }

        //Masking for Vector3
        public static Vector3 xxx( this Vector3 v ) { return new Vector3( v.x,v.x,v.x); }
        public static Vector3 xxy( this Vector3 v ) { return new Vector3( v.x,v.x,v.y); }
        public static Vector3 xxz( this Vector3 v ) { return new Vector3( v.x,v.x,v.z); }
        public static Vector3 xyx( this Vector3 v ) { return new Vector3( v.x,v.y,v.x); }
        public static Vector3 xyy( this Vector3 v ) { return new Vector3( v.x,v.y,v.y); }
        public static Vector3 xyz( this Vector3 v ) { return new Vector3( v.x,v.y,v.z); }
        public static Vector3 xzx( this Vector3 v ) { return new Vector3( v.x,v.z,v.x); }
        public static Vector3 xzy( this Vector3 v ) { return new Vector3( v.x,v.z,v.y); }
        public static Vector3 xzz( this Vector3 v ) { return new Vector3( v.x,v.z,v.z); }
        public static Vector3 yxx( this Vector3 v ) { return new Vector3( v.y,v.x,v.x); }
        public static Vector3 yxy( this Vector3 v ) { return new Vector3( v.y,v.x,v.y); }
        public static Vector3 yxz( this Vector3 v ) { return new Vector3( v.y,v.x,v.z); }
        public static Vector3 yyx( this Vector3 v ) { return new Vector3( v.y,v.y,v.x); }
        public static Vector3 yyy( this Vector3 v ) { return new Vector3( v.y,v.y,v.y); }
        public static Vector3 yyz( this Vector3 v ) { return new Vector3( v.y,v.y,v.z); }
        public static Vector3 yzx( this Vector3 v ) { return new Vector3( v.y,v.z,v.x); }
        public static Vector3 yzy( this Vector3 v ) { return new Vector3( v.y,v.z,v.y); }
        public static Vector3 yzz( this Vector3 v ) { return new Vector3( v.y,v.z,v.z); }
        public static Vector3 zxx( this Vector3 v ) { return new Vector3( v.z,v.x,v.x); }
        public static Vector3 zxy( this Vector3 v ) { return new Vector3( v.z,v.x,v.y); }
        public static Vector3 zxz( this Vector3 v ) { return new Vector3( v.z,v.x,v.z); }
        public static Vector3 zyx( this Vector3 v ) { return new Vector3( v.z,v.y,v.x); }
        public static Vector3 zyy( this Vector3 v ) { return new Vector3( v.z,v.y,v.y); }
        public static Vector3 zyz( this Vector3 v ) { return new Vector3( v.z,v.y,v.z); }
        public static Vector3 zzx( this Vector3 v ) { return new Vector3( v.z,v.z,v.x); }
        public static Vector3 zzy( this Vector3 v ) { return new Vector3( v.z,v.z,v.y); }
        public static Vector3 zzz( this Vector3 v ) { return new Vector3( v.z,v.z,v.z); }
        public static Vector2 xx( this Vector3 v ) { return new Vector2( v.x,v.x); }
        public static Vector2 xy( this Vector3 v ) { return new Vector2( v.x,v.y); }
        public static Vector2 xz( this Vector3 v ) { return new Vector2( v.x,v.z); }
        public static Vector2 yx( this Vector3 v ) { return new Vector2( v.y,v.x); }
        public static Vector2 yy( this Vector3 v ) { return new Vector2( v.y,v.y); }
        public static Vector2 yz( this Vector3 v ) { return new Vector2( v.y,v.z); }
        public static Vector2 zx( this Vector3 v ) { return new Vector2( v.z,v.x); }
        public static Vector2 zy( this Vector3 v ) { return new Vector2( v.z,v.y); }
        public static Vector2 zz( this Vector3 v ) { return new Vector2( v.z,v.z); }

        /// <summary>
        /// Multipy the specified v and v2.
        /// </summary>
        /// <param name="v">V.</param>
        /// <param name="v2">V2.</param>
        public static Vector3 Multiply(this Vector3 v,Vector3 v2)
        {
            return new Vector3(v.x * v2.x, v.y * v2.y, v.z * v2.z);
        }

        /// <summary>
        /// return (1 - x , 1 - y , 1 - z)
        /// </summary>
        /// <param name="v">V.</param>
        public static Vector3 OneMinus(this Vector3 v) 
        {         
            return new Vector3(1 - v.x,1 - v.y,1 - v.z);
        }

        /// <summary>
        /// Opposite direction of the Vector3
        /// </summary>
        /// <param name="v">V.</param>
        public static Vector3 Invert(this Vector3 v) 
        { 
            return v * -1;
        }

        /// <summary>
        /// Randoms normalized vector3.
        /// </summary>
        /// <returns>The normalized.</returns>
        /// <param name="v">V.</param>
        public static Vector3 RandomNormalized() 
        { 
            bool isInBoundShere = false;
            Vector3 ret = new Vector3();
            while (!isInBoundShere)
            {
                float x = Random.Range(-1f, 1f);
                float y = Random.Range(-1f, 1f);
                float z = Random.Range(-1f, 1f);
                ret.x = x;
                ret.y = y;
                ret.z = z;
                if (ret.magnitude <= 1f)
                    isInBoundShere = true;
            }
            return ret.normalized;
        }


        public static int Return1(this Vector3 v)
        {
            return 1;
        }
    }
}