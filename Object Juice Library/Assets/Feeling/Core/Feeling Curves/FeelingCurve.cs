using UnityEngine;

public abstract class FeelingCurve 
{
    public Vector3 StartPosition { get; set; }
    public Vector3 EndPosition { get; set; }
    
    public abstract Vector3 Evaluate(float t);

    public Vector3[] GetCurvePoints(int resolution)
    {
        Vector3[] drawPoints = new Vector3[resolution];
        float jumpIntervals = 1.0f / resolution;
        float t = 0;

        for (int i = 0; i < resolution; i++)
        {
            t += jumpIntervals;
            drawPoints[i] = Evaluate(t);
        }

        return drawPoints;
    }
}