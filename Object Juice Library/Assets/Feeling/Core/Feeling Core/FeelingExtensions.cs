using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace JE.Feeling
{
    public static class FeelingExtensions
    {
        public static FeelingRuntimeHandler<Color> ModifyColor(this Renderer objectRenderer,
            Color destinationColor, float duration)
        {
            return Feeling.ModifyColor(objectRenderer.material.color, destinationColor,
                duration, (v) => objectRenderer.material.color = v);
        }
        
        public static FeelingRuntimeHandler<Color> ModifyColor(this Image objectImage, 
            Color destinationColor, float duration)
        {
            return Feeling.ModifyColor(objectImage.color, destinationColor,
                duration, (v) => objectImage.color = v);
        }

        public static FeelingRuntimeHandler<Vector3> ModifyPosition(this Transform objectTransform, 
            Vector3 destinationPosition, float duration)
        {
            return Feeling.ModifyVector3(objectTransform.position, destinationPosition,
                duration, (v) => objectTransform.position = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyPosition(this RectTransform objectTransform, 
            Vector3 destinationPosition, float duration)
        {
            return Feeling.ModifyVector3(objectTransform.localPosition, destinationPosition,
                duration, (v) => objectTransform.position = v);

            //SHOULD THIS BE LOCAL POSITION??
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyPosition(this Transform objectTransform, 
            Vector3 curveHeight, Vector3 destinationPosition, float duration)
        {
            FeelingCurve feelingCurve = new FeelingQuadraticCurve(objectTransform.position, 
                curveHeight, destinationPosition);

            return Feeling.ModifyVector3(feelingCurve, duration,
                (v) => objectTransform.position = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyPosition(this RectTransform objectTransform, 
            Vector3 curveHeight, Vector3 destinationPosition, float duration)
        {
            FeelingCurve feelingCurve = new FeelingQuadraticCurve(objectTransform.position, 
                curveHeight, destinationPosition);

            return Feeling.ModifyVector3(feelingCurve, duration,
                (v) => objectTransform.position = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyPosition(this RectTransform objectTransform, 
            FeelingCurve feelingCurve, float duration)
        {
            return Feeling.ModifyVector3(feelingCurve, duration,
                (v) => objectTransform.position = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyPosition(this Transform objectTransform, 
            FeelingCurve feelingCurve, float duration)
        {
            return Feeling.ModifyVector3(feelingCurve, duration,
                (v) => objectTransform.position = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyScale(this Transform objectTransform, 
            Vector3 destinationScale, float duration)
        {
            return Feeling.ModifyVector3(objectTransform.localScale, destinationScale,
                duration, (v) => objectTransform.localScale = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyScale(this RectTransform objectTransform, 
            Vector3 destinationScale, float duration)
        {
            return Feeling.ModifyVector3(objectTransform.localScale, destinationScale,
                duration, (v) => objectTransform.localScale = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyEulerRotation(this Transform objectTransform, 
            Vector3 destinationRotation, float duration)
        {
            return Feeling.ModifyVector3(objectTransform.eulerAngles, destinationRotation,
                duration, (v) => objectTransform.eulerAngles = v);
        }
        
        public static FeelingRuntimeHandler<Vector3> ModifyEulerRotation(this RectTransform objectTransform, 
            Vector3 destinationRotation, float duration)
        {
            return Feeling.ModifyVector3(objectTransform.localEulerAngles, destinationRotation,
                duration, (v) => objectTransform.localEulerAngles = v);
        }
        
        public static FeelingRuntimeHandler<Quaternion> ModifyRotation(this Transform objectTransform, 
            Quaternion destinationRotation, float duration)
        {
            return Feeling.ModifyQuaternion(objectTransform.rotation, destinationRotation,
                duration, (v) => objectTransform.rotation = v);
        }
        
        public static FeelingRuntimeHandler<Quaternion> ModifyRotation(this RectTransform objectTransform, 
            Quaternion destinationRotation, float duration)
        {
            return Feeling.ModifyQuaternion(objectTransform.localRotation, destinationRotation,
                duration, (v) => objectTransform.localRotation = v);
        }
    }
}
