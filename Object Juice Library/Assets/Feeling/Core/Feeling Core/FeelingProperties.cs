using System;

public abstract class FeelingProperties<T>
{
    protected FeelingProperties(FeelingRoutineType feelingType, Action<T>[] modifyValue, float duration)
    {
        Type = feelingType;
        ModifyValue = modifyValue;
        Duration = duration;
    }
    
    public abstract void InitialiseValues (FeelingDirectionType directionType);
    
    public Action<T>[] ModifyValue { get; set; }
    public float Duration { get; set; }
    public int Iterations { get; set; } = 1;
    public float Delay { get; set; }
    
    public FeelingRoutineType Type { get; set; }
    public FeelingIterationType IterationType { get; set; }
    public FeelingDirectionType DirectionType { get; set; }
    public FeelingTimeType TimeType { get; set; }
    public FeelingEase Ease { get; set; }

    public Action OnStart;
    public Action OnComplete;
    public Action OnIterate;
}