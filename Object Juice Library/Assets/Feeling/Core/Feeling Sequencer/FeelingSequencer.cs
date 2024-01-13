using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raynah
{
    public class FeelingSequencer : MonoBehaviour
    {
        private readonly ArrayList _feelingHandlers = new ArrayList();

        public void Append<T>(FeelingRuntimeHandler<T> feelingHandler)
        {
            _feelingHandlers.Add(feelingHandler);
        }
    }
}
