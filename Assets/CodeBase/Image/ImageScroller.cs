using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Image
{
    public class ImageScroller : MonoBehaviour
    {
        [SerializeField] private List<GalleryImage> leftImages;
        [SerializeField] private List<GalleryImage> rightImages;
    }
}