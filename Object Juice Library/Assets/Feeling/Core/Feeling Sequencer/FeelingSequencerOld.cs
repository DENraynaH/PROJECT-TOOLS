using System;
using System.Collections;
using System.Collections.Generic;
using JE.Feeling;
using UnityEngine;

public class FeelingSequencerOld
{
    private readonly FeelingSequencerProperties _sequencerProperties = new();
    private readonly ArrayList _orderedSequences = new();
    private readonly FeelingMonoHook _feelingMonoHook;
    
    private IEnumerator _currentSequence;
    private FeelingDirectionType _sequencerDirectionType = FeelingDirectionType.Forward;
    
    private int _sequenceCount;
    private bool _isPlaying;
    private bool _isInitialised;

    public FeelingSequencerOld()
    {
        _feelingMonoHook = FeelingCore.GetMonoHook();
    }
    
    public FeelingSequencerOld Append(Action action)
    {
        _orderedSequences.Add(action);
        return this;
    }
    
    public FeelingSequencerOld Append<T>(FeelingRuntimeHandler<T> runtimeHandler)
    {
        _orderedSequences.Add((Func<IEnumerator>)runtimeHandler.BeginFeeling);
        return this;
    }
    
    public FeelingSequencerOld Delay(float delay)
    {
        _orderedSequences.Add(delay);
        return this;
    }
    
    public FeelingSequencerOld Iterations(int iterations)
    {
        _sequencerProperties.Iterations = iterations;
        return this;
    }

    public FeelingSequencerOld IterateMode(FeelingDirectionType directionType)
    {
        _sequencerDirectionType = directionType;
        return this;
    }

    public void Run()
    {
        if (!_isInitialised)
        {
            ConfigureSequenceCount();
            _isInitialised = true;
        }
        
        _isPlaying = true;

        _currentSequence = _sequencerDirectionType switch
        {
            FeelingDirectionType.Forward => IterateSequenceForward(),
            FeelingDirectionType.Rewind => IterateSequenceRewind(),
            _ => _currentSequence
        };
        _feelingMonoHook.StartCoroutine(_currentSequence);
    }

    public void Stop()
    {
        _isPlaying = false;
    }

    public FeelingSequencerOld Restart()
    {
        _isPlaying = false;
        ConfigureSequenceCount();
        return this;
    }
    
    public IEnumerator IterateSequenceForward()
    {
        for (int i = _sequenceCount; i < _orderedSequences.Count; i++)
        {
            if (!_isPlaying)
                yield break;
            
            switch (_orderedSequences[i])
            {
                case Func<IEnumerator> funcSequence:
                    yield return funcSequence();
                    break;
                case Action actionSequence:
                    actionSequence.Invoke();
                    break;
                case float floatSequence:
                    yield return new WaitForSeconds(floatSequence);
                    break;
            }
            _sequenceCount++;
        }
    }

    public IEnumerator IterateSequenceRewind()
    {
        for (int i = _sequenceCount; i >= 0; i--)
        {
            if (!_isPlaying)
                yield break;
            
            switch (_orderedSequences[i])
            {
                case Func<IEnumerator> funcSequence:
                    yield return funcSequence();
                    break;
                case Action actionSequence:
                    actionSequence.Invoke();
                    break;
                case float floatSequence:
                    yield return new WaitForSeconds(floatSequence);
                    break;
            }
            _sequenceCount--;
        }
    }

    private void ConfigureSequenceCount()
    {
        _sequenceCount = _sequencerDirectionType switch
        {
            FeelingDirectionType.Forward => 0,
            FeelingDirectionType.Rewind => _orderedSequences.Count - 1,
            _ => _sequenceCount
        };
    }
}
