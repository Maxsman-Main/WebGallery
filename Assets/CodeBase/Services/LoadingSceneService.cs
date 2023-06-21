using System.Collections;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Services
{
    public class StandardLoadingSceneService : ILoadingSceneService
    {
        private readonly MonoBehaviour _context;
        private readonly LoadingScreen _loadingScreen;
        private readonly Canvas _canvas;
        private readonly float _showTime;
        
        public StandardLoadingSceneService(LoadingScreen loadingScreen, MonoBehaviour context,  Canvas canvas, float showTime)
        {
            _loadingScreen = loadingScreen;
            _context = context;
            _canvas = canvas;
            _showTime = showTime;
        }

        public void Load()
        {
            _context.StartCoroutine(ShowLoadingScreen(_showTime, _loadingScreen, _canvas));
        }

        private IEnumerator ShowLoadingScreen(float showTime, LoadingScreen loadingScreen, Canvas canvas)
        {
            LoadingScreen loadingScreenObject = Object.Instantiate(loadingScreen, loadingScreen.transform.position, Quaternion.identity);
            loadingScreenObject.transform.SetParent(canvas.transform, false);
            
            float timer = 0;
            while (timer < showTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            
            Object.Destroy(loadingScreenObject.gameObject);
        }
    }
}