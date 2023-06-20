using UnityEngine;

namespace CodeBase.Image
{
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class ImageTextureCreator : MonoBehaviour
    {
        public void SetImage(Texture2D texture)
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        }
    
    }
}