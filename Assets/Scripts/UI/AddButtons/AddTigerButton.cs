using System;
using Player;
using Player.Counter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.AddButtons
{
    public class AddTigerButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ButtonSettings _buttonSettings;
        [SerializeField] private TMP_Text _price;
        
        private MoneyCounter _moneyCounter;
        private PlayerTigersHolder _playerTigersHolder;
        private int _currentLevel = 0;

        [Inject]
        private void Constructor(MoneyCounter moneyCounter, PlayerTigersHolder playerTigersHolder)
        {
            _moneyCounter = moneyCounter;
            _playerTigersHolder = playerTigersHolder;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(BuyTiger);
            UpdateText();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(BuyTiger);
        }

        private void Update()
        {
            CheckInteractable();
        }

        private void BuyTiger()
        {
            _moneyCounter.TakeCurrency(_buttonSettings.Prices[_currentLevel]);
            _currentLevel++;
            _playerTigersHolder.CreateTiger();
            if(!_playerTigersHolder.IsMaxTigers(_buttonSettings.Prices.Count + 1))
                UpdateText();
        }

        private void UpdateText()
        {
            _price.text = $"{_buttonSettings.Prices[_currentLevel]}";
        }

        private void CheckInteractable()
        {
            if (_playerTigersHolder.IsMaxTigers(_buttonSettings.Prices.Count + 1))
            {
                _button.interactable = false;
                _price.text = "Max";
            }
            else
            {
                if (_moneyCounter.IsEnough(_buttonSettings.Prices[_currentLevel]))
                    _button.interactable = true;
                else
                    _button.interactable = false;
            }
        }
    }
}