using UnityEngine;

namespace CodeBase.Image
{
    [RequireComponent(typeof(ImageTextureCreator))]
    public class ZoomedImage : MonoBehaviour
    {
        private ImageTextureCreator _imageTextureCreator;
        
        public void Init()
        {
            _imageTextureCreator = GetComponent<ImageTextureCreator>();
        }
        
        public void SetImage(Texture2D texture)
        {
            _imageTextureCreator.SetImage(texture);
        }
    }
}