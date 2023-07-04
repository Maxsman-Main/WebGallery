using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Image
{
    public class ImageScroller : MonoBehaviour
    {
        [SerializeField] private List<GameObject> leftImages;
        [SerializeField] private List<GameObject> rightImages;

        private List<ImageEnterInTheScreenTracker> _leftImageTrackers;
        private List<ImageEnterInTheScreenTracker> _rightImageTrackers;

        private List<ImageZoom> _leftImageZooms;
        private List<ImageZoom> _rightImageZooms;

        public List<ImageEnterInTheScreenTracker> OrderedImagesTrackers
        {
            get
            {
                List<ImageEnterInTheScreenTracker> imageTrackers = new();
                for (int i = 0; i < leftImages.Count; i++)
                {
                    imageTrackers.Add(_leftImageTrackers[i]);
                    imageTrackers.Add(_rightImageTrackers[i]);
                }

                return imageTrackers;
            }
        }

        public List<ImageZoom> OrderedImagesZoom
        {
            get
            {
                List<ImageZoom> imageZooms = new();
                for (int i = 0; i < leftImages.Count; i++)
                {
                    imageZooms.Add(_leftImageZooms[i]);
                    imageZooms.Add(_rightImageZooms[i]);
                }

                return imageZooms;
            }
        }

        public void Init()
        {
            _leftImageTrackers = new List<ImageEnterInTheScreenTracker>();
            _rightImageTrackers = new List<ImageEnterInTheScreenTracker>();
            
            _leftImageZooms = new List<ImageZoom>();
            _rightImageZooms = new List<ImageZoom>();

            for (int i = 0; i < leftImages.Count; i++)
            {
                _leftImageTrackers.Add(leftImages[i].GetComponent<ImageEnterInTheScreenTracker>());
                _rightImageTrackers.Add(rightImages[i].GetComponent<ImageEnterInTheScreenTracker>());
            }
            
            for (int i = 0; i < leftImages.Count; i++)
            {
                _leftImageZooms.Add(leftImages[i].GetComponent<ImageZoom>());
                _rightImageZooms.Add(rightImages[i].GetComponent<ImageZoom>());
            }
        }
    }
}