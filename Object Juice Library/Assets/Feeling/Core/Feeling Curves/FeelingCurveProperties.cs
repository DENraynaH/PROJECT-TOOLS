using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raynah
{
    public class FeelingCurveProperties<T> : FeelingProperties<T>
    {
        public FeelingCurve Curve { get; private set; }
        private Vector3 _originalStartPosition;
        private Vector3 _originalEndPosition;
        
        public FeelingCurveProperties(FeelingRoutineType routineType, 
            Action<T>[] modifyValue, FeelingCurve feelingCurve ,float duration) 
            : base(routineType, modifyValue, duration)
        {
            Curve = feelingCurve;
            _originalStartPosition = Curve.StartPosition;
            _originalEndPosition = Curve.EndPosition;
        }

        public override void InitialiseValues (FeelingDirectionType directionType)
        {
            switch (directionType)
            {
                case FeelingDirectionType.Forward:
                    Curve.StartPosition = _originalStartPosition;
                    Curve.EndPosition = _originalEndPosition;
                    break;
                case FeelingDirectionType.Rewind:
                    Curve.StartPosition = _originalEndPosition;
                    Curve.EndPosition = _originalStartPosition;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
