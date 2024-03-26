using Buildings;
using Player;
using Player.Counter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.AddButtons
{
    public class AddBankButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ButtonSettings _buttonSettings;
        [SerializeField] private TMP_Text _price;
        
        private MeatCounter _meatCounter;
        private BuildingHolder _buildingHolder;
        private int _currentLevel = 0;

        [Inject]
        private void Constructor(MeatCounter meatCounter, BuildingHolder buildingHolder)
        {
            _meatCounter = meatCounter;
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
            _meatCounter.TakeCurrency(_buttonSettings.Prices[_currentLevel]);
            _currentLevel++;
            _buildingHolder.CreateBank(_currentLevel);
            if(!_buildingHolder.IsBankMax(_buttonSettings.Prices.Count + 1))
                UpdateText();
        }

        private void UpdateText()
        {
            _price.text = $"{_buttonSettings.Prices[_currentLevel]}";
        }

        private void CheckInteractable()
        {
            if (_buildingHolder.IsBankMax(_buttonSettings.Prices.Count + 1))
            {
                _button.interactable = false;
                _price.text = "Max";
            }
            else
            {
                if (_meatCounter.IsEnough(_buttonSettings.Prices[_currentLevel]))
                    _button.interactable = true;
                else
                    _button.interactable = false;
            }
        }
    }
}