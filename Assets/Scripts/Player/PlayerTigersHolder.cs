using System.Collections.Generic;
using LevelLogic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerTigersHolder : MonoBehaviour
    {
        [Header("Positions")]
        [SerializeField] private Transform _tigerStartPosition;


        private ObjectsFabric _fabric;
        private PlayerInput _playerInput;
        private List<TigerMovement> _tigers;

        [Inject]
        public void Constructor(ObjectsFabric fabric)
        {
            _fabric = fabric;
        }

        private void Start()
        {
            _tigers = new List<TigerMovement>();
            _playerInput = _fabric.CreatePlayerInput();
            CreateTiger();
        }

        public bool IsMaxTigers(int maxTigers) => _tigers.Count == maxTigers;

        public void CreateTiger()
        {
            TigerMovement tiger = _fabric.CreateTiger(_tigerStartPosition.position);
            _playerInput.AddTiger(tiger);
            _tigers.Add(tiger);
        }
    }
}