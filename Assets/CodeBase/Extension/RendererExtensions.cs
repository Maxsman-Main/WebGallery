using UnityEngine;

namespace CodeBase.Extension
{
    public static class RendererExtensions
    {
        public static bool IsVisible(this RectTransform rectTransform)
        {
            float leftUpCornerYCoordinate = GetLeftUpCornerYCoordinate(rectTransform);
            return leftUpCornerYCoordinate > 0;
        }

        private static float GetLeftUpCornerYCoordinate(RectTransform rectTransform)
        {
            var worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);
            
            return worldCorners[1].y;
        }
    }
}