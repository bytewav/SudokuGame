using UnityEngine;

namespace Catalyst.Core.Utility
{
    /// <summary>
    /// Vector3 extension.
    /// </summary>
    public static class Vector2Extension
    {
        public static Vector4 ToVector3(this Vector3 v) { return new Vector3(v.x,v.y,0); }


        /// <summary>
        /// Multipy the specified v and v2.
        /// </summary>
        /// <param name="v">V.</param>
        /// <param name="v2">V2.</param>
        public static Vector2 Multipy(this Vector2 v,Vector2 v2)
        {
            return new Vector2(v.x * v2.x, v.y * v2.y);
        }

        /// <summary>
        /// return (1 - x , 1 - y , 1 - z)
        /// </summary>
        /// <param name="v">V.</param>
        public static Vector2 OneMinus(this Vector2 v) 
        {         
            return new Vector2(1 - v.x,1 - v.y);
        }

        /// <summary>
        /// Opposite direction of the Vector3
        /// </summary>
        /// <param name="v">V.</param>
        public static Vector2 Invert(this Vector2 v) 
        { 
            return v * -1;
        }

        public static Vector3 ToVector3_XY(this Vector2 v) 
        { 
            return new Vector3(v.x,v.y,0);
        }

        public static Vector3 ToVector3_XZ(this Vector2 v) 
        { 
            return new Vector3(v.x,0,v.y);
        }
    }
}