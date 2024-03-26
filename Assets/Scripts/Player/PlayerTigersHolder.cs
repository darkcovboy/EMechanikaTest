using System.Collections;
using System.Collections.Generic;
using LevelLogic;
using PersistentData;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerTigersHolder : MonoBehaviour
    {
        [Header("Positions")]
        [SerializeField] private Transform _tigerStartPosition;


        private ObjectsFabric _fabric;
        private Progress _progress;
        private PlayerInput _playerInput;
        private List<TigerMovement> _tigers;

        [Inject]
        public void Constructor(ObjectsFabric fabric, Progress progress)
        {
            _fabric = fabric;
            _progress = progress;
        }

        private void Start()
        {
            _tigers = new List<TigerMovement>();
            _playerInput = _fabric.CreatePlayerInput();
            StartCoroutine(SpawnTigers());
        }

        private IEnumerator SpawnTigers()
        {
            for (int i = 0; i < _progress.ProgressData.CountTigers + 1; i++)
            {
                CreateTiger(true);
                yield return new WaitForSeconds(0.2f);
            }
        }

        public bool IsMaxTigers(int maxTigers) => _tigers.Count == maxTigers;

        public void CreateTiger(bool isStartSpawn = false)
        {
            TigerMovement tiger = _fabric.CreateTiger(_tigerStartPosition.position);
            _playerInput.AddTiger(tiger);
            _tigers.Add(tiger);
            if(!isStartSpawn) 
                _progress.ProgressData.CountTigers++;
        }
    }
}