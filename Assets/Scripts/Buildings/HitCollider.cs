using System;
using UnityEngine;

namespace Buildings
{
    public class HitCollider : MonoBehaviour
    {
        public event Action OnTrigger;
        
        private void OnTriggerEnter(Collider other) => OnTrigger?.Invoke();
    }
}