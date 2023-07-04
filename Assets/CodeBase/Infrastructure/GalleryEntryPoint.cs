using System.Collections.Generic;
using CodeBase.Image;
using CodeBase.Services;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GalleryEntryPoint : MonoBehaviour
    {
        [SerializeField] private ImageScroller imageScroller;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private float maxLoadingScreenShowTime;
        
        private IWebRequestService _webRequestService;
        private ILoadingSceneService _loadingSceneService;
        private IScreenOrientationControllerService _screenOrientationController;
        private IImageSceneProvider _imageSceneProvider;
        private ISceneLoaderService _standardSceneLoader;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitScreenOrientation();
            InitLoadingScreen();
            _loadingSceneService.Load();
            _webRequestService = new StandardWebRequestService(this);
            _standardSceneLoader = new StandardSceneLoader();
            _imageSceneProvider = new StandardImageSceneProvider();
            imageScroller.Init();
            InitImageTrackers();
            InitImageZooms();
        }

        private void InitScreenOrientation()
        {
            _screenOrientationController = new StandardScreenOrientationController();
            _screenOrientationController.SetPortraitOrientation();
        }
        
        private void InitLoadingScreen()
        {
            loadingScreen.Init(maxLoadingScreenShowTime);
            _loadingSceneService = new StandardLoadingSceneService(loadingScreen, this, maxLoadingScreenShowTime);
            _loadingSceneService.OnLoadingTimerUpdate += loadingScreen.UpdatePercents;
            _loadingSceneService.OnLoadingTimerUpdate += loadingScreen.UpdateProgressBar;
            _loadingSceneService.OnLoadingEnd += loadingScreen.Hide;
        }
        
        private void InitImageTrackers()
        {
            List<ImageEnterInTheScreenTracker> orderedImagesTrackers = imageScroller.OrderedImagesTrackers;
            for (int i = 0; i < orderedImagesTrackers.Count; i++)
            {
                orderedImagesTrackers[i].Init(i + 1);
                orderedImagesTrackers[i].OnImageEnterInTheScreen += _webRequestService.GetTexture;
            }
        }

        private void InitImageZooms()
        {
            List<ImageZoom> orderedImagesZoom = imageScroller.OrderedImagesZoom;
            for (var i = 0; i < orderedImagesZoom.Count; i++)
            {
                var imageZoom = orderedImagesZoom[i];
                imageZoom.Init(i + 1);
                imageZoom.OnImageClickedId += _imageSceneProvider.SaveImageIndex;
                imageZoom.OnImageClicked += _standardSceneLoader.LoadZoomScene;
            }
        }
    }
}
