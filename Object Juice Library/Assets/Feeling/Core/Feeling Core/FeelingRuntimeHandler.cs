using System;
using System.Collections;
using JE.Feeling;
using UnityEngine;

public class FeelingRuntimeHandler<T>
{
    private readonly FeelingProperties<T> _runtimeProperties;
    private readonly FeelingRuntimeData<T> _runtimeData = new FeelingRuntimeData<T>();

    public FeelingRuntimeHandler(FeelingProperties<T> feelingRuntimeProperties)
    {
        _runtimeProperties = feelingRuntimeProperties;
    }

    public FeelingRuntimeHandler<T> Start()
    {
        FeelingMonoHook feelingMonoHook = FeelingCore.GetMonoHook();
        
        _runtimeData.CurrentRoutine = BeginFeeling();
        _runtimeData.CurrentIterationType = _runtimeProperties.DirectionType;

        feelingMonoHook.StartCoroutine(_runtimeData.CurrentRoutine);
        return this;
    }

    public FeelingRuntimeHandler<T> Stop()
    {
        FeelingMonoHook feelingMonoHook = FeelingCore.GetMonoHook();
        feelingMonoHook.StopCoroutine(_runtimeData.CurrentRoutine);
        return this;
    }

    public FeelingRuntimeHandler<T> Reset()
    {
        _runtimeData.CurrentPercentage = 0.0f;
        return this;
    }

    public FeelingRuntimeHandler<T> SetIterations(int iterations)
    {
        _runtimeProperties.Iterations = iterations;
        return this;
    }
        
    public FeelingRuntimeHandler<T> SetDelay(float delay)
    {
        _runtimeProperties.Delay = delay;
        return this;
    }
    
    public FeelingRuntimeHandler<T> SetEase(FeelingEase feelingEase)
    {
        _runtimeProperties.Ease = feelingEase;
        return this;
    }
        
    public FeelingRuntimeHandler<T> AppendCompleteAction(Action completeAction)
    {
        _runtimeProperties.OnComplete += completeAction;
        return this;
    }
        
    public FeelingRuntimeHandler<T> AppendStartAction(Action startAction)
    {
        _runtimeProperties.OnStart += startAction;
        return this;
    }
    
    public FeelingRuntimeHandler<T> AppendIterateAction(Action loopingAction)
    {
        _runtimeProperties.OnIterate += loopingAction;
        return this;
    }

    public FeelingRuntimeHandler<T> SetIterateType(FeelingIterationType loopType)
    {
        _runtimeProperties.IterationType = loopType;
        return this;
    }

    public FeelingRuntimeHandler<T> SetDirectionType(FeelingDirectionType directionType)
    {
        _runtimeProperties.DirectionType = directionType;
        return this;
    }

    public FeelingRuntimeHandler<T> SetTimeType(FeelingTimeType timeType)
    {
        _runtimeProperties.TimeType = timeType;
        return this;
    }
    
    public FeelingRuntimeHandler<T> ReCache(T updatedValue)
    {
        if (_runtimeProperties is FeelingRuntimeProperties<T> runtimeProperties)
            runtimeProperties.BeginValue = updatedValue;
        return this;
    }

    public IEnumerator BeginFeeling()
    {
        if (_runtimeData.InitialBegin)
        {
            yield return new WaitForSeconds(_runtimeProperties.Delay);
            _runtimeProperties.OnStart?.Invoke();
            _runtimeData.InitialBegin = false;
        }

        for (int i = _runtimeData.CurrentIteration; i < _runtimeProperties.Iterations; i++)
        {
            yield return FeelingCore.GetRoutine(_runtimeProperties, _runtimeData);
            _runtimeProperties.OnIterate?.Invoke();
            ConfigureNextRoutine();
        }
        
        _runtimeData.CurrentIteration = 0;
        _runtimeProperties.OnComplete?.Invoke();
    }

    private void ConfigureNextRoutine()
    {
        if (_runtimeProperties.IterationType == FeelingIterationType.Reverse)
            _runtimeData.FlipIteration();

        _runtimeData.CurrentIteration++;
    }
}

public class FeelingRuntimeData<T>
{
    public IEnumerator CurrentRoutine { get; set; } = null;
    public FeelingDirectionType CurrentIterationType { get; set; } = FeelingDirectionType.Forward;
    public int CurrentIteration { get; set; } = 0;
    public float CurrentPercentage { get; set; } = 0.0f;
    public bool InitialBegin  { get; set; } = true;

    public void FlipIteration()
    {
        CurrentIterationType = CurrentIterationType == FeelingDirectionType.Forward
            ? FeelingDirectionType.Rewind
            : FeelingDirectionType.Forward;
    }

    public void ResetPersistentData()
    {
        InitialBegin = true;
        CurrentPercentage = 0.0f;
    }
}
