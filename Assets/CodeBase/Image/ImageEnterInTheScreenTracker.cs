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
        private bool _isImageShowed;
        private RectTransform _rectTransform;
        private int _imageIndex;

        public int ImageIndex
        {
            set => 
                _imageIndex = value;
        }

        public Action<string, Action<Texture2D>> OnImageEnterInTheScreen;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _textureCreator = GetComponent<ImageTextureCreator>();
            _isImageShowed = false;
        }

        private void Update()
        {
            if(_isImageShowed || !_rectTransform.IsVisible()) return;
            _isImageShowed = true;
            OnImageEnterInTheScreen?.Invoke($"{LinkConstants.ImageURL}/{_imageIndex}.{ImageConstants.ImageFormat}", _textureCreator.SetImage);
        }
    }
}