using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingQuadraticCurve : FeelingCurve
{
    public Vector3 P1 { get; private set; }

    public FeelingQuadraticCurve(Vector3 startPosition, Vector3 p1, Vector3 endPosition)
    {
        StartPosition = startPosition;
        P1 = p1;
        EndPosition = endPosition;
    }

    public override Vector3 Evaluate(float t)
    {
        Vector3 position = ((1 - t) * (1 - t)) * StartPosition;
        position += 2 * (1 - t) * t * P1;
        position += (t * t) * EndPosition;
        
        return position;
    }
}