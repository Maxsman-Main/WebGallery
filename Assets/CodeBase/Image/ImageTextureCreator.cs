using UnityEngine;

namespace CodeBase.Image
{
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class ImageTextureCreator : MonoBehaviour
    {
        private bool _isImageShowed;

        public bool IsImageShowed =>
            _isImageShowed;
        
        public void SetImage(Texture2D texture)
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
            GetComponent<UnityEngine.UI.Image>().sprite = sprite;
            _isImageShowed = true;
        }
    }
}