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

                Debug.Log(imageTrackers.Count);
                return imageTrackers;
            }
        }

        private void Start()
        {
            _leftImageTrackers = new List<ImageEnterInTheScreenTracker>();
            _rightImageTrackers = new List<ImageEnterInTheScreenTracker>();
            
            //Add some refactor
            for (int i = 0; i < leftImages.Count; i++)
            {
                _leftImageTrackers.Add(leftImages[i].GetComponent<ImageEnterInTheScreenTracker>());
                _rightImageTrackers.Add(rightImages[i].GetComponent<ImageEnterInTheScreenTracker>());
            }
        }
    }
}