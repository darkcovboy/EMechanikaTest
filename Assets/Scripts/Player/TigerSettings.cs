using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Player/TigerSettings")]
    public class TigerSettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _minBoostRange;
        [SerializeField] private float _maxBoostRange;
        [SerializeField] private float _timeToAcceseleration;

        public float Speed => _speed;

        public float MINBoostRange => _minBoostRange;

        public float MAXBoostRange => _maxBoostRange;

        public float TimeToAcceseleration => _timeToAcceseleration;
    }
}