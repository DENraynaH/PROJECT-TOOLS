#if UNITY_EDITOR
using System;
using Raynah.Utilities;
using Sirenix.OdinInspector.Editor;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace Raynah.Core
{
    [CustomEditor(typeof(ObjectDistributor))]
    public class ObjectDistributorEditor : OdinEditor
    {
        public void OnSceneGUI()
        {
            var objectDistributor = (ObjectDistributor)target;
            if (objectDistributor.DistributionZones.IsEmpty())
                return;

            /*EditorGUI.BeginChangeCheck();
            Handles.RadiusHandle(Quaternion.identity, objectDistributor.transform.position, , false);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(objectDistributor, "Changed Distribution Zone");
                
            }*/
        }

        [DrawGizmo(GizmoType.Active | GizmoType.NonSelected)]    
        private static void DrawGizmos(ObjectDistributor objectDistributor, GizmoType gizmoType)
        {
            if (objectDistributor.DistributionZones.IsEmpty())
                return;
            
            foreach (DistributionZone distributionZone in objectDistributor.DistributionZones)
                DrawZoneGizmos(distributionZone, objectDistributor.transform.position);
        }

        private static void DrawZoneGizmos(DistributionZone distributionZone, Vector3 objectDistributorPosition)
        {
            Gizmos.color = Color.black;
            switch (distributionZone)
            {
                case BoxDistributionZone boxDistributionZone:
                    DrawBoxGizmos(boxDistributionZone); break;
                case LineDistributionZone lineDistributionZone:
                    DrawLineGizmos(lineDistributionZone); break;
                case PointDistributionZone pointDistributionZone:
                    DrawPointGizmos(pointDistributionZone); break;
                case SphereDistributionZone sphereDistributionZone:
                    DrawSphereGizmos(sphereDistributionZone); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(distributionZone));
            }
            
            void DrawPointGizmos(PointDistributionZone pointDistributionZone)
            {
                Gizmos.DrawSphere(objectDistributorPosition + pointDistributionZone.OffsetPosition, 0.15f);
                
                /*EditorGUI.BeginChangeCheck();
                Vector3 updatedPosition = Handles.PositionHandle(objectDistributorPosition + pointDistributionZone.OffsetPosition, Quaternion.identity);
                if (EditorGUI.EndChangeCheck())
                {
                    pointDistributionZone.OffsetPosition = updatedPosition;
                }*/
            }
            
            void DrawSphereGizmos(SphereDistributionZone sphereDistributionZone)
            {
                Gizmos.DrawWireSphere(objectDistributorPosition + sphereDistributionZone.OffsetPosition, sphereDistributionZone.SphereRadius);
            }
            
            void DrawLineGizmos(LineDistributionZone lineDistributionZone)
            {
                Vector3 startPosition = objectDistributorPosition + lineDistributionZone.OffsetPosition;
                Vector3 endPosition = startPosition + lineDistributionZone.LineDirection * lineDistributionZone.LineLength;
                Gizmos.DrawLine(startPosition, endPosition);
            }
            
            void DrawBoxGizmos(BoxDistributionZone boxDistributionZone)
            {
                Gizmos.DrawWireCube (objectDistributorPosition + boxDistributionZone.OffsetPosition,
                    boxDistributionZone.BoxBoundaries);
            }
        }
    }
}
#endif