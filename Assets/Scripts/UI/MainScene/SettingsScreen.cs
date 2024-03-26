using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainScene
{
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private Menu _menu;
        [SerializeField] private Button _closeButton;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
            _menu.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            gameObject.SetActive(false);
            _menu.gameObject.SetActive(true);
        }
    }
}