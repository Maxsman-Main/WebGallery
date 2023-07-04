using System;
using CodeBase.Constants;
using CodeBase.Extension;
using UnityEngine;

namespace CodeBase.Image
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(ImageTextureCreator))]
    public class ImageEnterInTheScreenTracker : MonoBehaviour
    {
        private ImageTextureCreator _textureCreator;
        private bool _isImageLoaded;
        private RectTransform _rectTransform;
        private int _imageIndex;

        public Action<string, Action<Texture2D>> OnImageEnterInTheScreen;

        public void Init(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException();
            }
            
            _rectTransform = GetComponent<RectTransform>();
            _textureCreator = GetComponent<ImageTextureCreator>();
            _isImageLoaded = false;
            _imageIndex = index;
        }

        private void Update()
        {
            if(_isImageLoaded || !_rectTransform.IsVisible()) return;
            _isImageLoaded = true;
            OnImageEnterInTheScreen?.Invoke($"{LinkConstants.ImageURL}/{_imageIndex}.{ImageConstants.ImageFormat}", _textureCreator.SetImage);
        }
    }
}