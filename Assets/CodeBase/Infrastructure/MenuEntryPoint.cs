using CodeBase.Services;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class MenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneLoaderButton button;

        private ISceneLoaderService _standardSceneLoader;
        private IScreenOrientationControllerService _screenOrientationController;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitScreenOrientation();
            button.OnButtonClicked += _standardSceneLoader.LoadGalleryScene;
        }

        private void InitScreenOrientation()
        {
            _screenOrientationController = new StandardScreenOrientationController();
            _screenOrientationController.SetPortraitOrientation();
            _standardSceneLoader = new StandardSceneLoader();
        }
    }
}
