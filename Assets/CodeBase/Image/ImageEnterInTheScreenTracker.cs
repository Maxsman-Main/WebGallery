using System;
using CodeBase.Extension;
using UnityEngine;

namespace CodeBase.Image
{
    public class ImageEnterInTheScreenTracker : MonoBehaviour
    {
        public event Action OnImageEnterInTheScreen;

        private bool _isImageShowed;
        private RectTransform _rectTransform;
        
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _isImageShowed = false;
            OnImageEnterInTheScreen += () => {Debug.Log("Enter");};
        }

        private void Update()
        {
            if(_isImageShowed || !_rectTransform.IsVisible()) return;
            _isImageShowed = true;
            OnImageEnterInTheScreen?.Invoke();
        }
    }
}