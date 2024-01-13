using System;
using System.Collections;
using Raynah;
using UnityEngine;

namespace JE.Feeling
{
    public static class FeelingCore
    {
        public static IEnumerator ModifyVectorCurveRoutine
            (FeelingCurveProperties<Vector3> runtimeProperties, FeelingRuntimeData<Vector3> runtimeData)
        {
            Func<float, float> easeCurve = FeelingEaseHandler.GetEase(runtimeProperties.Ease);
            runtimeProperties.InitialiseValues(runtimeData.CurrentIterationType);

            float lerpTimer = runtimeData.CurrentPercentage;
            float lerpRate = 1.0f / runtimeProperties.Duration;

            while (lerpTimer < 1.0f)
            {
                lerpTimer += GetTime(runtimeProperties) * lerpRate;
                runtimeData.CurrentPercentage = lerpTimer;

                foreach (var modifyValue in runtimeProperties.ModifyValue)
                    modifyValue.Invoke(runtimeProperties.Curve.Evaluate(easeCurve.Invoke(lerpTimer)));
                
                yield return null;
            }
            
            runtimeData.ResetPersistentData();
        }
        
        public static IEnumerator ModifyVector3Routine
            (FeelingRuntimeProperties<Vector3> runtimeProperties, FeelingRuntimeData<Vector3> runtimeData)
        {
            Func<float, float> easeCurve = FeelingEaseHandler.GetEase(runtimeProperties.Ease);
            runtimeProperties.InitialiseValues(runtimeData.CurrentIterationType);

            float lerpTimer = runtimeData.CurrentPercentage;
            float lerpRate = 1.0f / runtimeProperties.Duration;

            while (lerpTimer < 1.0f)
            {
                lerpTimer += GetTime(runtimeProperties) * lerpRate;
                runtimeData.CurrentPercentage = lerpTimer;

                foreach (var modifyValue in runtimeProperties.ModifyValue)
                    modifyValue.Invoke(Vector3.Lerp
                            (runtimeProperties.CurrentBeginValue, 
                            runtimeProperties.CurrentDestinationValue, 
                            easeCurve.Invoke(lerpTimer)));
                
                yield return null;
            }
            
            runtimeData.ResetPersistentData();
        }
        
        public static IEnumerator ModifyIntRoutine
            (FeelingRuntimeProperties<int> runtimeProperties, FeelingRuntimeData<int> runtimeData)
        {
            Func<float, float> easeCurve = FeelingEaseHandler.GetEase(runtimeProperties.Ease);
            runtimeProperties.InitialiseValues(runtimeData.CurrentIterationType);

            float lerpTimer = runtimeData.CurrentPercentage;
            float lerpRate = 1.0f / runtimeProperties.Duration;

            while (lerpTimer < 1.0f)
            {
                lerpTimer += GetTime(runtimeProperties) * lerpRate;
                runtimeData.CurrentPercentage = lerpTimer;

                foreach (var modifyValue in runtimeProperties.ModifyValue)
                    modifyValue.Invoke((int)Mathf.Lerp
                            (runtimeProperties.CurrentBeginValue, 
                            runtimeProperties.CurrentDestinationValue, 
                            easeCurve.Invoke(lerpTimer)));
                
                yield return null;
            }
            
            runtimeData.ResetPersistentData();
        }
        
        public static IEnumerator ModifyFloatRoutine
            (FeelingRuntimeProperties<float> runtimeProperties, FeelingRuntimeData<float> runtimeData)
        {
            Func<float, float> easeCurve = FeelingEaseHandler.GetEase(runtimeProperties.Ease);
            runtimeProperties.InitialiseValues(runtimeData.CurrentIterationType);

            float lerpTimer = runtimeData.CurrentPercentage;
            float lerpRate = 1.0f / runtimeProperties.Duration;;

            while (lerpTimer < 1.0f)
            {
                lerpTimer += GetTime(runtimeProperties) * lerpRate;
                runtimeData.CurrentPercentage = lerpTimer;

                foreach (var modifyValue in runtimeProperties.ModifyValue)
                    modifyValue.Invoke(Mathf.Lerp
                            (runtimeProperties.CurrentBeginValue, 
                            runtimeProperties.CurrentDestinationValue,
                            easeCurve.Invoke(lerpTimer)));
                
                yield return null;
            }
            
            runtimeData.ResetPersistentData();
        }
        
        public static IEnumerator ModifyColorRoutine
            (FeelingRuntimeProperties<Color> runtimeProperties, FeelingRuntimeData<Color> runtimeData)
        {
            Func<float, float> easeCurve = FeelingEaseHandler.GetEase(runtimeProperties.Ease);
            runtimeProperties.InitialiseValues(runtimeData.CurrentIterationType);

            float lerpTimer = runtimeData.CurrentPercentage;
            float lerpRate = 1.0f / runtimeProperties.Duration;;

            while (lerpTimer < 1.0f)
            {
                lerpTimer += GetTime(runtimeProperties) * lerpRate;
                runtimeData.CurrentPercentage = lerpTimer;

                foreach (var modifyValue in runtimeProperties.ModifyValue)
                    modifyValue.Invoke(Color.Lerp
                            (runtimeProperties.CurrentBeginValue, 
                            runtimeProperties.CurrentDestinationValue, 
                            easeCurve.Invoke(lerpTimer)));
                
                yield return null; 
            }
            
            runtimeData.ResetPersistentData();
        }
        
        public static IEnumerator ModifyQuaternionRoutine
            (FeelingRuntimeProperties<Quaternion> runtimeProperties, FeelingRuntimeData<Quaternion> runtimeData)
        {
            Func<float, float> easeCurve = FeelingEaseHandler.GetEase(runtimeProperties.Ease);
            runtimeProperties.InitialiseValues(runtimeData.CurrentIterationType);

            float lerpTimer = runtimeData.CurrentPercentage;
            float lerpRate = 1.0f / runtimeProperties.Duration;;

            while (lerpTimer < 1.0f)
            {
                lerpTimer += GetTime(runtimeProperties) * lerpRate;
                runtimeData.CurrentPercentage = lerpTimer;

                foreach (var modifyValue in runtimeProperties.ModifyValue)
                    modifyValue.Invoke(Quaternion.Lerp
                        (runtimeProperties.CurrentBeginValue, 
                        runtimeProperties.CurrentDestinationValue, 
                        easeCurve.Invoke(lerpTimer)));
                
                yield return null; 
            }
            
            runtimeData.ResetPersistentData();
        }
        
        public static IEnumerator GetRoutine<T>
            (FeelingProperties<T> runtimeProperties, FeelingRuntimeData<T> runtimeData)
        {
            switch (runtimeProperties.Type)
            {
                case FeelingRoutineType.Vector3:
                    return ModifyVector3Routine(
                        runtimeProperties as FeelingRuntimeProperties<Vector3>,
                        runtimeData as FeelingRuntimeData<Vector3> );
                case FeelingRoutineType.Vector3Curve:
                    return ModifyVectorCurveRoutine(
                        runtimeProperties as FeelingCurveProperties<Vector3>,
                        runtimeData as FeelingRuntimeData<Vector3> );
                case FeelingRoutineType.Color:
                    return ModifyColorRoutine(
                        runtimeProperties as FeelingRuntimeProperties<Color>,
                        runtimeData as FeelingRuntimeData<Color> );
                case FeelingRoutineType.Quaternion:
                    return ModifyQuaternionRoutine(
                        runtimeProperties as FeelingRuntimeProperties<Quaternion>,
                        runtimeData as FeelingRuntimeData<Quaternion>);
                case FeelingRoutineType.Float:
                    return ModifyFloatRoutine(
                        runtimeProperties as FeelingRuntimeProperties<float>,
                        runtimeData as FeelingRuntimeData<float> );
                case FeelingRoutineType.Integer:
                    return ModifyIntRoutine(
                        runtimeProperties as FeelingRuntimeProperties<int>,
                        runtimeData as FeelingRuntimeData<int> );
            }
            throw new ArgumentOutOfRangeException();
        }
        
        public static float GetTime<T>(FeelingProperties<T> runtimeProperties)
        {
            return runtimeProperties.TimeType switch
            {
                FeelingTimeType.Scaled => Time.deltaTime,
                FeelingTimeType.UnScaled => Time.unscaledDeltaTime,
                FeelingTimeType.Fixed => Time.fixedDeltaTime,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static FeelingMonoHook GetMonoHook()
        {
            FeelingMonoHook feelingMonoHook = FeelingMonoHook.Instance;

            if (feelingMonoHook)
                return feelingMonoHook;
            
            GameObject gameObject = new GameObject("Feeling Controller");
            feelingMonoHook = gameObject.AddComponent<FeelingMonoHook>();
            feelingMonoHook.Initialise();

            return feelingMonoHook;
        }
    }
}

