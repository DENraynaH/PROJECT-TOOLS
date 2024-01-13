using System;

namespace Raynah.Utilities
{
    public abstract class Timer
    {
        protected float _timerStart;
        protected float _timerDuration;
        protected float _currentTime;
        protected bool _isPaused;
        
        protected Action OnStart;
        protected Action OnPause;
        protected Action OnCancel;
        protected Action OnComplete;
        protected Action OnLoop;
        
        protected TimerMonoHook _timerMonoHook;
        
        protected abstract void OnTimerComplete();

        public Timer Start()
        {
            if (_isPaused)
            {
                _isPaused = false;
                return this;
            }
            
            OnStart?.Invoke();
            _timerMonoHook.AppendTimer(this);
            return this;
        }
        
        public Timer Cancel()
        {
            OnCancel?.Invoke();
            _timerMonoHook.RemoveTimer(this);
            return this;
        }

        public Timer Pause()
        {
            _isPaused = true;
            return this;
        }
        
        public Timer Restart()
        {
            _currentTime = _timerStart;
            return this;
        }
        
        public void Tick(float deltaTime)
        {
            if (_isPaused)
                return;
            
            _currentTime += deltaTime;
            if (_currentTime >= _timerDuration)
                OnTimerComplete();
        }
        
        public Timer AppendStartAction(Action appendAction)
        {
            OnStart += appendAction;
            return this;
        }
        
        public Timer AppendCompleteAction(Action appendAction)
        {
            OnComplete += appendAction;
            return this;
        }
        
        public Timer AppendLoopAction(Action appendAction)
        {
            OnLoop += appendAction;
            return this;
        }
        
        public Timer AppendCancelAction(Action appendAction)
        {
            OnCancel += appendAction;
            return this;
        }
        
        public Timer AppendPauseAction(Action appendAction)
        {
            OnPause += appendAction;
            return this;
        }
    }
}