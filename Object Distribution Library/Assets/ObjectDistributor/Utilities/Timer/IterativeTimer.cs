using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Raynah.Utilities
{
    public class IterativeTimer : Timer
    {
        private readonly int _timerIterations;
        private int _currentIterations;

        public IterativeTimer(float timerDuration, int iterationCount = 1, float timerStart = 0.0f)
        {
            _timerStart = timerStart;
            _timerDuration = timerDuration;
            _currentTime = timerStart;
            _timerIterations = iterationCount;
            
            _timerMonoHook = Timers.GetMonoHook();
        }
        
        protected override void OnTimerComplete()
        {
            OnLoop?.Invoke();
            _currentIterations++;

            if (_currentIterations >= _timerIterations)
            {
                OnComplete?.Invoke();
                _timerMonoHook.RemoveTimer(this);
                return;
            }
            _currentTime = _timerStart;
        }
    }
}
