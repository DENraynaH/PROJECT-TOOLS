using System;
using System.Collections;
using System.Collections.Generic;
using Raynah.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Raynah.Testing
{
    public class TimerTesting : MonoBehaviour
    {
        [FoldoutGroup("Test")] public int A;
        [ReadOnly] [SerializeField] private float B;
        
        [FoldoutGroup("Test2")] [SerializeField] private int C;
        [FoldoutGroup("Test2")] [field:SerializeField] private float D { get; set; }

        private void Start()
        {
            Timers.TimedAction(5.0f, () => { Debug.Log("Test"); }).Start();
            Timers.IterativeAction(5.0f, 10, () => { Debug.Log("Iterative"); }).Start();
            Timers.LoopingAction(5.0f, () => { Debug.Log("Looping"); }).Start();

            Timer timer = new ConditionalTimer(5.0f, () => false)
                .AppendLoopAction(() => Debug.Log("Looping"))
                .AppendCompleteAction(() => Debug.Log("Complete"))
                .Start();
        }
        
        [Button]
        public void TestDebug()
        {
            Debug.Log("Test");
        }
    }
}
