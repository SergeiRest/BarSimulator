using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameBehavior
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Image _timerImage;

        [Inject] private Timer _timer;

        [Inject]
        private void Construct()
        {
            _timer.TimerTicked += Fill;
        }

        private void Fill(float value)
        {
            _timerImage.fillAmount = value;
        }

        private void OnDestroy()
        {
            _timer.TimerTicked -= Fill;
        }
    }
}