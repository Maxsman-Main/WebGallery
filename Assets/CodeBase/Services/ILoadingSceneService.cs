using System;

namespace CodeBase.Services
{
    public interface ILoadingSceneService
    {
        public event Action OnLoadingEnd;
        public event Action<float> OnLoadingTimerUpdate;
        public void Load();
    }
}