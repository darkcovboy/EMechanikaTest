using System;
using Loader;
using PersistentData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ReturnButton : MonoBehaviour
    {
        private const string MainScene = "MainScene";
        
        [SerializeField] private Button _button;
        
        private SceneLoader _sceneLoader;
        private Progress _progress;

        [Inject]
        public void Constructor(SceneLoader sceneLoader, Progress progress)
        {
            _sceneLoader = sceneLoader;
            _progress = progress;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Load);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Load);
        }

        private void Load()
        {
            _progress.Save();
            _sceneLoader.Load(MainScene);
        }
    }
}