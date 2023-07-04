using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
    public class SceneLoaderButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnButtonClicked; 

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClicked?.Invoke();
        }
    }
}
