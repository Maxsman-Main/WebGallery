using System;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InputController : MonoBehaviour
    {
        public event Action OnBackButtonDown;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                OnBackButtonDown?.Invoke();
            }
        }
    }
}