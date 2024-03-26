using System;
using Player.Counter;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.CounterView
{
    public class MeatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private IMeatChangeHandler _handler;

        [Inject]
        public void Constructor(IMeatChangeHandler handler)
        {
            _handler = handler;
        }

        private void OnEnable()
        {
            _handler.OnMeatChangeValue += UpdateText;
        }

        private void OnDisable()
        {
            _handler.OnMeatChangeValue -= UpdateText;
        }

        private void UpdateText(int meatCount)
        {
            _text.text = $"{meatCount}";
        }
    }
}