using System;
using UnityEngine;

namespace Raynah.Utilities
{
    public static class Timers
    {
        public static TimerMonoHook GetMonoHook()
        {
            TimerMonoHook timerMonoHook = TimerMonoHook.Instance;

            if (timerMonoHook)
                return timerMonoHook;

            GameObject gameObject = new GameObject("Timer Controller");
            timerMonoHook = gameObject.AddComponent<TimerMonoHook>();

            return timerMonoHook;
        }
        
        public static IterativeTimer TimedAction(float timerDuration, Action OnComplete)
        {
            Timer timedAction = new IterativeTimer(timerDuration)
                .AppendCompleteAction(OnComplete);

            return timedAction as IterativeTimer;
        }

        public static IterativeTimer IterativeAction(float timerDuration, int iterations, 
            Action OnLoop, Action OnComplete = null)
        {
            Timer iterativeAction = new IterativeTimer(timerDuration, iterations)
                .AppendLoopAction(OnLoop)
                .AppendCompleteAction(OnComplete);

            return iterativeAction as IterativeTimer;
        }
        
        public static ConditionalTimer LoopingAction(float timerDuration, Action OnLoop, Action OnComplete = null)
        {
           Timer loopingAction = new ConditionalTimer(timerDuration, () => false) 
               .AppendLoopAction(OnLoop)
               .AppendCompleteAction(OnComplete);

           return loopingAction as ConditionalTimer;
        }
    }
}