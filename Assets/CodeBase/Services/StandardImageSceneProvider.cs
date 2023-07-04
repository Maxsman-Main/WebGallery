using UnityEngine;

namespace CodeBase.Services
{
    public class StandardImageSceneProvider : IImageSceneProvider
    {
        private const string ImageIDKey = "imageID";

        public void SaveImageIndex(int value)
        {
            PlayerPrefs.SetInt(ImageIDKey, value);
        }

        public int LoadImageIndex()
        {
            return PlayerPrefs.GetInt(ImageIDKey);
        }
    }
}