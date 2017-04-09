using UnityEngine;

namespace Catalyst.Core.Utility
{
    /// <summary>
    /// Utilities to test if an object is visible from a camera
    /// </summary>
    public static class RendererExtensions
    {
        public static bool IsVisibleFrom(this Renderer renderer, UnityEngine.Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }

        public static bool IsSkinVisibleFrom(this SkinnedMeshRenderer renderer, UnityEngine.Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
    }
}