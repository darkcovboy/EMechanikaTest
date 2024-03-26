using System.Collections.Generic;
using UnityEngine;

namespace Buildings
{
    public class BuildingsPositionsHolder : MonoBehaviour
    {
        [SerializeField] private List<Transform> _bankPoints;
        [SerializeField] private List<Transform> _butchersShopPoints;

        public List<Transform> BankPoints => _bankPoints;

        public List<Transform> ButchersShopPoints => _butchersShopPoints;
    }
}