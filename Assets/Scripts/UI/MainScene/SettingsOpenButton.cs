using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainScene
{
    public class SettingsOpenButton : MonoBehaviour
    {
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(Open);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Open);
        }

        private void Open()
        {
            _settingsScreen.gameObject.SetActive(true);
        }
    }
}