using System;
using Data;
using UnityEngine;
using Zenject;

namespace GameBehavior
{
    public class Timer : ITickable
    {
        private float _currentTime = 0;
        private float _maxTime;

        private bool _isKilled = false;

        public event Action<float> TimerTicked;

        [Inject]
        private void Construct(GameData gameData)
        {
            _maxTime = gameData.DayHours * gameData.HourDuration * 60;
        }
        
        public void Tick()
        {
            if(_isKilled)
                return;
            
            _currentTime += Time.deltaTime;
            TimerTicked?.Invoke(_currentTime / _maxTime);
            if (_currentTime >= _maxTime)
            {
                _isKilled = true;
            }
        }

        public void SetActive(bool value)
        {
            _isKilled = value;
        }
    }
}