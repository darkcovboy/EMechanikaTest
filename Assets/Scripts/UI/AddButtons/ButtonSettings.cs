using System.Collections.Generic;
using UnityEngine;

namespace UI.AddButtons
{
    [CreateAssetMenu(fileName = "AddButtonsSettings", menuName = "UI/AddButtons", order = 0)]
    public class ButtonSettings : ScriptableObject
    {
        [SerializeField] private List<int> _prices;

        public List<int> Prices => _prices;

    }
}