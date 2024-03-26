using Player.Counter;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.CounterView
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private IMoneyChangedHandler _handler;

        [Inject]
        public void Constructor(IMoneyChangedHandler handler)
        {
            _handler = handler;
        }

        private void OnEnable()
        {
            _handler.OnMoneyChangedValue += UpdateText;
        }

        private void OnDisable()
        {
            _handler.OnMoneyChangedValue -= UpdateText;
        }

        private void UpdateText(int money)
        {
            _text.text = $"{money}";
        }
    }
}