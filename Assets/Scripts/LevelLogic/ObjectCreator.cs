using System;
using Installers;
using Player;
using UnityEngine;
using Zenject;

namespace LevelLogic
{
    public class ObjectCreator : MonoBehaviour
    {
        [Header("Positions")] [SerializeField] private Transform _tigerStartPosition;
        
        private ObjectsFabric _fabric;
        private PlayerInput _playerInput;

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
        }

        public void CreateTiger()
        {
            TigerMovement tiger = _fabric.CreateTiger(_tigerStartPosition);
            _playerInput.AddTiger(tiger);
        }
    }
}