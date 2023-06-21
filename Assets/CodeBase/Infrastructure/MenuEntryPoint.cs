using CodeBase.Services;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class MenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneLoaderButton button;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private float loadingScreenShowTime;
        
        
        private SceneLoader _sceneLoader;
        private ILoadingSceneService _loadingSceneService;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _sceneLoader = new SceneLoader();
            _loadingSceneService = new StandardLoadingSceneService(loadingScreen, this, mainCanvas, loadingScreenShowTime);
            button.OnButtonClicked += _loadingSceneService.Load;
            //button.OnButtonClicked += _sceneLoader.LoadGalleryScene;
        }
    }
}
