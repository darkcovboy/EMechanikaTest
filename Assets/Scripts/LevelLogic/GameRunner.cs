using System;
using Loader;
using UnityEngine;

namespace LevelLogic
{
    public class GameRunner : MonoBehaviour
    {
        private const string MainScene = "MainScene";
        [SerializeField] private SceneLoader _sceneLoader;
        private void Awake()
        {
            _sceneLoader.Load(MainScene);
        }
    }
}