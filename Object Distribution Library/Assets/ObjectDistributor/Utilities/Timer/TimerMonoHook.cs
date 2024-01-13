using System;
using System.Collections.Generic;
using UnityEngine;

namespace Raynah.Utilities
{
    public class TimerMonoHook : Singleton<TimerMonoHook>
    {
        public readonly List<Timer> _currentTimers = new List<Timer>();

        private void Update()
        {
            if (_currentTimers.IsEmpty())
                return;

            foreach (Timer currentTimer in _currentTimers)
                currentTimer.Tick(Time.deltaTime);
        }

        public void AppendTimer(Timer iterativeTimer)
        {
            _currentTimers.Add(iterativeTimer);
        }

        public void RemoveTimer(Timer iterativeTimer)
        {
            _currentTimers.Remove(iterativeTimer);
        }
    }
}