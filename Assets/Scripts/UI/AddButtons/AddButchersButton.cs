using Buildings;
using Player.Counter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.AddButtons
{
    public class AddButchersButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ButtonSettings _buttonSettings;
        [SerializeField] private TMP_Text _price;
        
        private MoneyCounter _moneyCounter;
        private BuildingHolder _buildingHolder;
        private int _currentLevel = 0;

        [Inject]
        private void Constructor(MoneyCounter moneyCounter, BuildingHolder buildingHolder)
        {
            _moneyCounter = moneyCounter;
            _buildingHolder = buildingHolder;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(BuyBank);
            UpdateText();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(BuyBank);
        }

        private void Update()
        {
            CheckInteractable();
        }

        private void BuyBank()
        {
            _moneyCounter.TakeCurrency(_buttonSettings.Prices[_currentLevel]);
            _currentLevel++;
            _buildingHolder.CreateButcherShop(_currentLevel);
            if(!_buildingHolder.IsButchersMax(_buttonSettings.Prices.Count + 1))
                UpdateText();
        }

        private void UpdateText()
        {
            _price.text = $"{_buttonSettings.Prices[_currentLevel]}";
        }

        private void CheckInteractable()
        {
            if (_buildingHolder.IsButchersMax(_buttonSettings.Prices.Count + 1))
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