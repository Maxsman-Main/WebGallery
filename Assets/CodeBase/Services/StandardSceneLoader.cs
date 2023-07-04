using CodeBase.Constants;
using UnityEngine.SceneManagement;

namespace CodeBase.Services
{
    public class StandardSceneLoader : ISceneLoaderService
    {
        public void LoadZoomScene()
        {
            SceneManager.LoadScene(Scenes.Zoom);
        }

        public void LoadGalleryScene()
        {
            SceneManager.LoadScene(Scenes.Gallery);
        }
    }
}
