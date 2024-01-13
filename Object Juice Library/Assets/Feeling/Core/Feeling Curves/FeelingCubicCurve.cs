using UnityEngine;

public class FeelingCubicCurve : FeelingCurve
{
    public Vector3 P1 { get; private set; }
    public Vector3 P2 { get; private set; }

    public FeelingCubicCurve(Vector3 startPosition, Vector3 p1, Vector3 p2, Vector3 endPosition)
    {
        StartPosition = startPosition;
        P1 = p1;
        P2 = p2;
        EndPosition = endPosition;
    }

    public override Vector3 Evaluate(float t)
    {
        Vector3 position = ((1 - t) * (1 - t) * (1 - t)) * StartPosition;
        position += 3 * ((1 - t) * (1 - t)) * t * P1;
        position += 3 * (1 - t) * (t * t) * P2;
        position += (t * t * t) * EndPosition;
        
        return position;
    }
}