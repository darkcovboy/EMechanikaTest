using System;
using UnityEngine;

namespace Buildings
{
    public abstract class Building : MonoBehaviour
    {
        [SerializeField] private HitCollider _hitCollider;

        private void OnEnable()
        {
            _hitCollider.OnTrigger += EarnCurrency;
        }

        private void OnDisable()
        {
            _hitCollider.OnTrigger -= EarnCurrency;
        }

        protected abstract void EarnCurrency();


        public void Rotate(Transform to)
        {
            transform.Rotate(to.eulerAngles);
        }
    }
}