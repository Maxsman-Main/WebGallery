using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CodeBase.Services
{
    public class StandardWebRequestService : IWebRequestService
    {
        private readonly MonoBehaviour _context;

        public StandardWebRequestService(MonoBehaviour context)
        {
            _context = context;
        }

        public void GetTexture(string url, Action<Texture2D> onSuccess)
        {
            _context.StartCoroutine(GetTextureCoroutine(url, onSuccess));
        }

        private IEnumerator GetTextureCoroutine(string url, Action<Texture2D> onSuccess)
        {
            using UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url);
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception(unityWebRequest.error);
            }
            else
            {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                onSuccess?.Invoke(downloadHandlerTexture?.texture);
            }
        }
    }
}