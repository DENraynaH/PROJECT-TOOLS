using System;
using System.Collections.Generic;
using UnityEngine;

public class FeelingRuntimeProperties<T> : FeelingProperties<T>
{
    public T BeginValue { get; set; }
    public T DestinationValue { get; set; }
    public T CurrentBeginValue { get; set; }
    public T CurrentDestinationValue { get; set; }

    public FeelingRuntimeProperties(FeelingRoutineType feelingType, T beginValue, 
            T destinationValue, Action<T>[] modifyValue, float duration)
            : base(feelingType, modifyValue, duration)
    {
        BeginValue = beginValue;
        DestinationValue = destinationValue;
        
        IterationType = FeelingIterationType.Reset;
        TimeType = FeelingTimeType.Scaled;
        Ease = FeelingEase.Linear;
    }
    
    public override void InitialiseValues
        (FeelingDirectionType directionType)
    {
        switch (directionType)
        {
            case FeelingDirectionType.Forward:
                CurrentBeginValue = BeginValue;
                CurrentDestinationValue = DestinationValue;
                break;
            case FeelingDirectionType.Rewind:
                CurrentBeginValue = DestinationValue;
                CurrentDestinationValue = BeginValue;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}