using UnityEngine;

namespace CodeBase.Services
{
    public class StandardScreenOrientationController : IScreenOrientationControllerService
    {
        public void SetPortraitOrientation()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        public void SetFreeOrientation()
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}