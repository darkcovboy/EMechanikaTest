using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Player
{
    public class TigerMovement : MonoBehaviour, IInputs
    {
        private PointsHandler _pointsHandler;
        private TigerSettings _tigerSettings;
        
        private int currentPointIndex = 0;
        private float _currentSpeed;
        private Coroutine _boostCoroutine;

        [Inject]
        public void Constructor(PointsHandler pointsHandler, TigerSettings tigerSettings)
        {
            _pointsHandler = pointsHandler;
            _tigerSettings = tigerSettings;
        }

        private void Start()
        {
            _currentSpeed = _tigerSettings.Speed;
            _boostCoroutine = null;
        }
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointsHandler.Points[currentPointIndex].position,
                _currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _pointsHandler.Points[currentPointIndex].position) < 0.1f)
            {
                currentPointIndex = (currentPointIndex + 1) % _pointsHandler.Points.Count;
            }
        }

        public void OnPlayerTap()
        {
            _boostCoroutine ??= StartCoroutine(BoostSpeed());
        }

        private IEnumerator BoostSpeed()
        {
            _currentSpeed = _tigerSettings.Speed *
                            Random.Range(_tigerSettings.MINBoostRange, _tigerSettings.MAXBoostRange);
            yield return new WaitForSeconds(_tigerSettings.TimeToAcceseleration);
            _currentSpeed = _tigerSettings.Speed;
            _boostCoroutine = null;
        }
    }
}