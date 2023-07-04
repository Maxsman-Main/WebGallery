using System;
using System.Collections;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Services
{
    public class StandardLoadingSceneService : ILoadingSceneService
    {
        private readonly MonoBehaviour _context;
        private readonly LoadingScreen _loadingScreen;
        private readonly float _showTime;
        
        public event Action OnLoadingEnd;
        public event Action<float> OnLoadingTimerUpdate;

        public StandardLoadingSceneService(LoadingScreen loadingScreen, MonoBehaviour context, float showTime)
        {
            _loadingScreen = loadingScreen;
            _context = context;
            _showTime = showTime;
        }

        public void Load()
        {
            _context.StartCoroutine(ShowLoadingScreen(_showTime, _loadingScreen));
        }

        private IEnumerator ShowLoadingScreen(float showTime, LoadingScreen loadingScreen)
        {
            loadingScreen.Show();
            
            const float timerStep = 0.1f;
            float timer = 0;
            while (timer < showTime)
            {
                timer += timerStep;
                OnLoadingTimerUpdate?.Invoke(timer);
                yield return new WaitForSeconds(timerStep);
            }
            
            OnLoadingEnd?.Invoke();
        }
    }
}