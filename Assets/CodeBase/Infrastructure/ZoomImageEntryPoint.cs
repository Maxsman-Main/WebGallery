using CodeBase.Constants;
using CodeBase.Image;
using CodeBase.Services;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class ZoomImageEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneLoaderButton button;
        [SerializeField] private InputController inputController;
        [SerializeField] private ImageTextureCreator zoomedImage;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private float maxLoadingScreenShowTime;

        private ISceneLoaderService _standardSceneLoader;
        private IScreenOrientationControllerService _screenOrientationController;
        private IImageSceneProvider _imageSceneProvider;
        private IWebRequestService _webRequestService;
        private ILoadingSceneService _loadingSceneService;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitZoomedImage();
            InitLoadingScreen();
            _loadingSceneService.Load();
            InitScreenOrientation();
            InitSceneLoader();
        }
        
        private void InitScreenOrientation()
        {
            _screenOrientationController = new StandardScreenOrientationController();
            _screenOrientationController.SetFreeOrientation();
        }

        private void InitSceneLoader()
        {
            _standardSceneLoader = new StandardSceneLoader();
            button.OnButtonClicked += _standardSceneLoader.LoadGalleryScene;
            inputController.OnBackButtonDown += _standardSceneLoader.LoadGalleryScene;
        }

        private void InitZoomedImage()
        {
            _imageSceneProvider = new StandardImageSceneProvider();
            int imageID = _imageSceneProvider.LoadImageIndex();
            _webRequestService = new StandardWebRequestService(this);
            _webRequestService.GetTexture($"{LinkConstants.ImageURL}/{imageID}.{ImageConstants.ImageFormat}", zoomedImage.SetImage);
        }
        
        private void InitLoadingScreen()
        {
            loadingScreen.Init(maxLoadingScreenShowTime);
            _loadingSceneService = new StandardLoadingSceneService(loadingScreen, this, maxLoadingScreenShowTime);
            _loadingSceneService.OnLoadingTimerUpdate += loadingScreen.UpdatePercents;
            _loadingSceneService.OnLoadingTimerUpdate += loadingScreen.UpdateProgressBar;
            _loadingSceneService.OnLoadingEnd += loadingScreen.Hide;
        }
    }
}