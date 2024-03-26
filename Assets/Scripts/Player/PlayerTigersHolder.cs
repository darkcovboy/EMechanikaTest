using System.Collections.Generic;
using LevelLogic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerTigersHolder : MonoBehaviour
    {
        [Header("Positions")] [SerializeField] private Transform _tigerStartPosition;
        
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
            TigerMovement tiger = _fabric.CreateTiger(_tigerStartPosition);
            _playerInput = _fabric.CreatePlayerInput();
            _playerInput.AddTiger(tiger);
            _tigers.Add(tiger);
        }

        public void CreateTiger()
        {
            TigerMovement tiger = _fabric.CreateTiger(_tigerStartPosition);
            _playerInput.AddTiger(tiger);
        }
    }
}