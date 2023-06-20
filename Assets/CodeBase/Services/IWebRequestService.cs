using System;
using UnityEngine;

namespace CodeBase.Services
{
    public interface IWebRequestService
    {
        public void GetTexture(string url, Action<Texture2D> onSuccess);
    }
}