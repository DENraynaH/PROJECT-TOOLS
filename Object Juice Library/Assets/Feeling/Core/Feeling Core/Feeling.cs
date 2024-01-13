using System;
using System.Collections.Generic;
using Raynah;
using UnityEngine;

namespace JE.Feeling
{
    public static class Feeling
    {
        public static FeelingRuntimeHandler<float> ModifyFloat
            (float startValue, float destinationValue, float duration, params Action<float>[] modifyValue)
        {
            FeelingRuntimeProperties<float> runtimeProperties = 
                new FeelingRuntimeProperties<float> (FeelingRoutineType.Float, 
                    startValue, destinationValue, modifyValue, duration);
            
            FeelingRuntimeHandler<float> feelingRuntimeHandler = 
                new FeelingRuntimeHandler<float> (runtimeProperties);
            
            return feelingRuntimeHandler;
        }

        public static FeelingRuntimeHandler<int> ModifyInt
            (int startValue, int destinationValue, float duration, params Action<int>[] modifyValue)
        {
            FeelingRuntimeProperties<int> runtimeProperties = 
                new FeelingRuntimeProperties<int> (FeelingRoutineType.Integer, 
                    startValue, destinationValue, modifyValue, duration);
            
            FeelingRuntimeHandler<int> feelingRuntimeHandler = 
                new FeelingRuntimeHandler<int> (runtimeProperties);
            
            return feelingRuntimeHandler;
        }

        public static FeelingRuntimeHandler<Vector3> ModifyVector3
            (Vector3 startValue, Vector3 destinationValue, float duration, params Action<Vector3>[] modifyValue)
        {
            FeelingRuntimeProperties<Vector3> runtimeProperties = 
                new FeelingRuntimeProperties<Vector3> (FeelingRoutineType.Vector3, 
                    startValue, destinationValue, modifyValue, duration);
            
            FeelingRuntimeHandler<Vector3> feelingRuntimeHandler = 
                new FeelingRuntimeHandler<Vector3> (runtimeProperties);
            
            return feelingRuntimeHandler;
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyVector3
            (FeelingCurve feelingCurve, float duration, params Action<Vector3>[] modifyValue)
        {
            FeelingCurveProperties<Vector3> runtimeProperties = 
                new FeelingCurveProperties<Vector3>(FeelingRoutineType.Vector3Curve, 
                    modifyValue, feelingCurve, duration);
            
            FeelingRuntimeHandler<Vector3> feelingRuntimeHandler = 
                new FeelingRuntimeHandler<Vector3> (runtimeProperties);
            
            return feelingRuntimeHandler;
        }

        public static FeelingRuntimeHandler<Color> ModifyColor
        (Color startValue, Color destinationValue, float duration, params Action<Color>[] modifyValue)
        {
            FeelingRuntimeProperties<Color> runtimeProperties = 
                new FeelingRuntimeProperties<Color> (FeelingRoutineType.Color, 
                    startValue, destinationValue, modifyValue, duration);
            
            FeelingRuntimeHandler<Color> feelingRuntimeHandler = 
                new FeelingRuntimeHandler<Color> (runtimeProperties);
            
            return feelingRuntimeHandler;
        }
        
        public static FeelingRuntimeHandler<Quaternion> ModifyQuaternion
            (Quaternion startValue, Quaternion destinationValue, float duration, params Action<Quaternion>[] modifyValue)
        {
            FeelingRuntimeProperties<Quaternion> runtimeProperties = 
                new FeelingRuntimeProperties<Quaternion> (FeelingRoutineType.Quaternion, 
                    startValue, destinationValue, modifyValue, duration);
            
            FeelingRuntimeHandler<Quaternion> feelingRuntimeHandler = 
                new FeelingRuntimeHandler<Quaternion> (runtimeProperties);
            
            return feelingRuntimeHandler;
        }
    }
}

