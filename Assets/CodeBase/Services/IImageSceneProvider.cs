namespace CodeBase.Services
{
    public interface IImageSceneProvider
    {
        public void SaveImageIndex(int value);
        public int LoadImageIndex();
    }
}