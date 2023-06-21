using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Image
{
    [RequireComponent(typeof(ImageEnterInTheScreenTracker))]
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class ImageZoom : MonoBehaviour, IPointerClickHandler
    {
        private ZoomWindow _zoomWindow;
        private UnityEngine.UI.Image _image;
        private ImageEnterInTheScreenTracker _imageTracker;

        public void Init(ZoomWindow window)
        {
            if (window == null)
            {
                throw new ArgumentException();
            }

            _zoomWindow = window;
            _imageTracker = GetComponent<ImageEnterInTheScreenTracker>();
            _image = GetComponent<UnityEngine.UI.Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_imageTracker.IsImageShowed)
            {
                _zoomWindow.Enable(_image);
            }
        }
    }
}