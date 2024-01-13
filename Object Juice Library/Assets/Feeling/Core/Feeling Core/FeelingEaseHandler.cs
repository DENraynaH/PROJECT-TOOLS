using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FeelingEaseHandler
{
    public static Func<float, float> GetEase(FeelingEase feelingEase)
    {
        switch (feelingEase)
        {
            case FeelingEase.Linear:
                return EaseLinear;
            case FeelingEase.EaseInSine:
                return EaseInSine;
            case FeelingEase.EaseOutSine:
                return EaseOutSine;
            case FeelingEase.EaseInOutSine:
                return EaseInOutSine;
            case FeelingEase.EaseInCubic:
                return EaseInCubic;
            case FeelingEase.EaseOutCubic:
                return EaseOutCubic;
            case FeelingEase.EaseInOutCubic:
                return EaseInOutCubic;
            case FeelingEase.EaseInQuint:
                return EaseInQuint;
            case FeelingEase.EaseOutQuint:
                return EaseOutQuint;
            case FeelingEase.EaseInOutQuint:
                return EaseInOutQuint;
            case FeelingEase.EaseInCirc:
                return EaseInCirc;
            case FeelingEase.EaseOutCirc:
                return EaseOutCirc;
            case FeelingEase.EaseInOutCirc:
                return EaseInOutCirc;
            case FeelingEase.EaseInElastic:
                return EaseInElastic;
            case FeelingEase.EaseOutElastic:
                return EaseOutElastic;
            case FeelingEase.EaseInOutElastic:
                return EaseInOutElastic;
            case FeelingEase.EaseInQuad:
                return EaseInQuad;
            case FeelingEase.EaseOutQuad:
                return EaseOutQuad;
            case FeelingEase.EaseInOutQuad:
                return EaseInOutQuad;
            case FeelingEase.EaseInQuart:
                return EaseInQuart;
            case FeelingEase.EaseOutQuart:
                return EaseOutQuart;
            case FeelingEase.EaseInOutQuart:
                return EaseInOutQuart;
            case FeelingEase.EaseInBack:
                return EaseInBack;
            case FeelingEase.EaseOutBack:
                return EaseOutBack;
            case FeelingEase.EaseInOutBack:
                return EaseInOutBack;
            case FeelingEase.EaseInBounce:
                return EaseInBounce;
            case FeelingEase.EaseOutBounce:
                return EaseOutBounce;
            case FeelingEase.EaseInOutBounce:
                return EaseInOutBounce;
        }
        return EaseLinear;
    }

    private static float EaseLinear(float t)
    {
        return t;
    }
    
    private static float EaseInSine(float t)
    {
        return (float)(1 - Math.Cos((t * Math.PI) / 2));
    }

    private static float EaseOutSine(float t)
    {
        return (float)Math.Sin((t * Math.PI) / 2);
    }

    private static float EaseInOutSine(float t)
    {
        return (float)-(Math.Cos(Math.PI * t) - 1) / 2;
    }

    private static float EaseInCubic(float t)
    {
        return t * t * t;
    }

    private static float EaseOutCubic(float t)
    {
        return 1 - (float)Math.Pow(1 - t, 3.0);
    }

    private static float EaseInOutCubic(float t)
    {
        return (float)(t < 0.5f ? 4 * t * t * t : 1 - Math.Pow(-2 * t + 2, 3) / 2);
    }

    private static float EaseInQuint(float t)
    {
        return t * t * t * t;
    }

    private static float EaseOutQuint(float t)
    {
        return (float)(1.0f - Math.Pow(1 - t, 5));
    }

    private static float EaseInOutQuint(float t)
    {
        return (float)(t < 0.5 ? 16 * t * t * t * t * t : 1 - Math.Pow(-2 * t + 2, 5) / 2);
    }

    private static float EaseInCirc(float t)
    {
        return (float)(1.0f - Math.Sqrt(1 - Math.Pow(t, 2)));
    }
    
    private static float EaseOutCirc(float t)
    {
        return (float)Math.Sqrt(1.0f - Math.Pow(t - 1, 2));
    }
    
    private static float EaseInOutCirc(float t)
    {
        return (float)(t < 0.5
            ? (1 - Math.Sqrt(1 - Math.Pow(2 * t, 2))) / 2
            : (Math.Sqrt(1 - Math.Pow(-2 * t + 2, 2)) + 1) / 2);
    }

    private static float EaseInQuad(float t)
    {
        return t * t;
    }
    
    private static float EaseOutQuad(float t)
    {
        return 1 - (1 - t) * (1 - t);
    }
    
    private static float EaseInOutQuad(float t)
    {
        return (float)(t < 0.5 ? 2 * t * t : 1 - Math.Pow(-2 * t + 2, 2) / 2);
    }
    
    private static float EaseInQuart(float t)
    {
        return t * t * t * t;
    }
    
    private static float EaseOutQuart(float t)
    {
        return (float)(1 - Math.Pow(1 - t, 4));
    }
    
    private static float EaseInOutQuart(float t)
    {
        return (float)(t < 0.5 ? 8 * t * t * t * t : 1 - Math.Pow(-2 * t + 2, 4) / 2);
    }

    private static float EaseInBack(float t)
    {
        const double C1 = 1.70158;
        const double C3 = C1 + 1;

        return (float)(C3 * t * t * t - C1 * t * t);
    }
    
    private static float EaseOutBack(float t)
    {
        const double C1 = 1.70158;
        const double C3 = C1 + 1;

        return (float)(1 + C3 * Math.Pow(t - 1, 3) + C1 * Math.Pow(t - 1, 2));
    }
    
    private static float EaseInOutBack(float t)
    {
        const double C1 = 1.70158;
        const double C2 = C1 * 1.525;

        return (float)(t < 0.5
            ? (Math.Pow(2 * t, 2) * ((C2 + 1) * 2 * t - C2)) / 2
            : (Math.Pow(2 * t - 2, 2) * ((C2 + 1) * (t * 2 - 2) + C2) + 2) / 2);
    }
    
    private static float EaseInElastic(float t)
    {
        const double C4 = (2 * Math.PI) / 3;

        return t switch
        {
            0 => 0,
            >= 1.0f => 1,
            _ => (float)(-Math.Pow(2, 10 * t - 10) * Math.Sin((t * 10 - 10.75) * C4))
        };
    }
    
    private static float EaseOutElastic(float t)
    {
        const double C4 = (2 * Math.PI) / 3;
        
        return t switch
        {
            0 => 0,
            >= 1.0f => 1,
            _ => (float)(Math.Pow(2, -10 * t) * Math.Sin((t * 10 - 0.75) * C4) + 1)
        };
    }
    
    private static float EaseInOutElastic(float t)
    {
        const double C5 = (2 * Math.PI) / 4.5;

        switch (t)
        {
            case 0:
                return 0;
            case >= 1:
                return 1;
        }

        if (t < 0.5)
            return (float)(-(Math.Pow(2, 20 * t - 10) * Math.Sin((20 * t - 11.125) * C5)) / 2);
        
        return (float)((Math.Pow(2, -20 * t + 10) * Math.Sin((20 * t - 11.125) * C5)) / 2 + 1);
    }
    
    private static float EaseInBounce(float t)
    {
        return 1 - EaseOutBounce(1 - t);
    }
    
    private static float EaseOutBounce(float t)
    {
        const double n1 = 7.5625;
        const double d1 = 2.75;
        double d = t;

        if (t < 1 / d1) 
            return (float)(n1 * t * t);

        if (t < 2 / d1) 
            return (float)(n1 * (d - 1.5 / d1) * t + 0.75);

        if (t < 2.5 / d1) 
            return (float)(n1 * (d - 2.25 / d1) * t + 0.9375);

        return (float)(n1 * (d - 2.625 / d1) * t + 0.984375);
    }
    
    private static float EaseInOutBounce(float t)
    {
        return t < 0.5
            ? (1 - EaseOutBounce(1 - 2 * t)) / 2
            : (1 + EaseOutBounce(2 * t - 1)) / 2;
    }
}
