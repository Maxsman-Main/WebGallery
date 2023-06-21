using UnityEngine;

namespace CodeBase.Image
{
    public class ZoomWindow : MonoBehaviour
    {
        [SerializeField] UnityEngine.UI.Image placeholder;
        
        public UnityEngine.UI.Image Placeholder =>
            placeholder;
        
        public void Enable(UnityEngine.UI.Image image)
        {
            SetImage(image);
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void SetImage(UnityEngine.UI.Image image)
        {
            placeholder.sprite = image.sprite;
        }
    }
}