using CodeBase.Image;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GalleryImage galleryImage;
        
        private void Awake()
        {
            IWebRequestService webRequestService = new StandardWebRequestService(this);
            webRequestService.GetTexture("http://data.ikppbb.com/test-task-unity-data/pics/55.jpg", ShowErrorMessage, galleryImage.SetImage);
        }

        private void ShowErrorMessage(string message)
        {
            Debug.Log(message);
        }
    }
}
