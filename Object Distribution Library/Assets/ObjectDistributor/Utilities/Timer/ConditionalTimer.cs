using System;
using UnityEngine;

namespace Raynah.Utilities
{
    public class ConditionalTimer : Timer
    {
        private readonly Func<bool> _timerCondition;

        public ConditionalTimer(float timerDuration, Func<bool> timerCondition, float timerStart = 0.0f)
        {
            _timerStart = timerStart;
            _timerDuration = timerDuration;
            _currentTime = timerStart;
            _timerCondition = timerCondition;

            _timerMonoHook = Timers.GetMonoHook();
        }

        protected override void OnTimerComplete()
        {
            OnLoop?.Invoke();

            if (_timerCondition.Invoke())
            {
                OnComplete?.Invoke();
                _timerMonoHook.RemoveTimer(this);
                return;
            }
                
            _currentTime = _timerStart;
        }
    }
}