using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class ZoomImageEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneLoaderButton button;
        
        private SceneLoader _sceneLoader;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _sceneLoader = new SceneLoader();
            button.OnButtonClicked += _sceneLoader.LoadGalleryScene;
        }
    }
}