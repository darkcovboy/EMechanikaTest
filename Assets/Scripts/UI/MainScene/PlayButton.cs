using System;
using Loader;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainScene
{
    public class PlayButton : MonoBehaviour
    {
        private const string Level = "Level";
        [SerializeField] private Button _button;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Constructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
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
            _sceneLoader.Load(Level);
        }
    }
}