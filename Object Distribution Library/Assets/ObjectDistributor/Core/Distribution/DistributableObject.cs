using UnityEngine;

namespace Raynah.Core
{
    public class DistributableObject : MonoBehaviour
    {
        public DistributableObjectData ObjectData => _distributableObjectData;
        [SerializeField] private DistributableObjectData _distributableObjectData;
        
        public void DestroyObject()
        {
            Destroy(gameObject);
            _distributableObjectData.Clear();
        }
    }
}