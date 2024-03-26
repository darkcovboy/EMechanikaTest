using Buildings;
using Player;
using UnityEngine;

namespace LevelLogic
{
    [CreateAssetMenu(fileName = "Holder", menuName = "Gameplay/Prefabs", order = 0)]
    public class PrefabsHolder : ScriptableObject
    {
        [SerializeField] private TigerMovement _tigerPrefab;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Bank _bankPrefab;
        [SerializeField] private ButcherShop _butcherShopPrefab;

        public TigerMovement TigerPrefab => _tigerPrefab;
        public PlayerInput PlayerInput => _input;

        public ButcherShop ButcherShopPrefab => _butcherShopPrefab;

        public Bank BankPrefab => _bankPrefab;
    }
}