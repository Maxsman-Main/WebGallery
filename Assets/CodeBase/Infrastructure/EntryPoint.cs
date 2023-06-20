using System.Collections.Generic;
using CodeBase.Image;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ImageScroller imageScroller;
        
        private IWebRequestService _webRequestService;
        
        private void Start()
        {
            InitApp();
        }

        private void InitApp()
        {
            _webRequestService = new StandardWebRequestService(this);
            InitializeImageTrackers();
        }
        
        private void InitializeImageTrackers()
        {
            List<ImageEnterInTheScreenTracker> orderedImageTrackers = imageScroller.OrderedImagesTrackers;
            
            for (int i = 0; i < orderedImageTrackers.Count; i++)
            {
                orderedImageTrackers[i].ImageIndex = i + 1;
                orderedImageTrackers[i].OnImageEnterInTheScreen += _webRequestService.GetTexture;
            }
        }
    }
}
