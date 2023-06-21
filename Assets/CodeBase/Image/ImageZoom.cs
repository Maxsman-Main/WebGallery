using System;
using CodeBase.Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Image
{
    [RequireComponent(typeof(ImageTextureCreator))]
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class ImageZoom : MonoBehaviour, IPointerClickHandler
    {
        public event Action<Texture2D> OnImageClicked;

        private SceneLoader _sceneLoader;
        private ImageTextureCreator _textureCreator;
        private UnityEngine.UI.Image _image;

        public void Init(SceneLoader sceneLoader)
        {
            _textureCreator = GetComponent<ImageTextureCreator>();
            _image = GetComponent<UnityEngine.UI.Image>();
            _sceneLoader = sceneLoader;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //not best solution, but it's working pretty good
            if (!_textureCreator.IsImageShowed) return;
            OnImageClicked?.Invoke(_image.sprite.texture);
            _sceneLoader.LoadZoomScene();
        }
    }
}