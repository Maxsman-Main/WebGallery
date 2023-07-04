using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Image
{
    [RequireComponent(typeof(ImageTextureCreator))]
    public class ImageZoom : MonoBehaviour, IPointerClickHandler
    {
        public event Action<int> OnImageClickedId;
        public event Action OnImageClicked;

        private int _id;
        private ImageTextureCreator _currentImageTextureCreator;
        
        public void Init(int id)
        {
            _id = id;
            _currentImageTextureCreator = GetComponent<ImageTextureCreator>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_currentImageTextureCreator.IsImageShowed) return;
            OnImageClickedId?.Invoke(_id);
            OnImageClicked?.Invoke();
        }
    }
}