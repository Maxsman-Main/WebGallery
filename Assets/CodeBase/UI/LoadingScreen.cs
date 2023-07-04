using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private TMP_Text progressPercents;
        
        private float _timerMaxValue;

        public void Init(float timerMaxValue)
        {
            _timerMaxValue = timerMaxValue;
        }
        
        public void UpdatePercents(float value)
        {
            int percent = (int)(value / _timerMaxValue * 100);
            if (percent > 100) percent = 100;
            progressPercents.text = $"{percent.ToString(CultureInfo.InvariantCulture)}%";
        }

        public void UpdateProgressBar(float value)
        {
            float barValue = value / _timerMaxValue;
            progressBar.value = barValue;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}