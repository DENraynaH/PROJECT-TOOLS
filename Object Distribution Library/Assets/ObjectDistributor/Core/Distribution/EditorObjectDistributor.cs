using UnityEditor;
using UnityEngine;

namespace Raynah.Core
{
    public class EditorObjectDistributor : ObjectDistributor
    {
        protected override void OnDistribute(GameObject distributedObject)
        {
            Undo.RegisterCreatedObjectUndo(distributedObject, "Distributed Object");
        }
    }
}