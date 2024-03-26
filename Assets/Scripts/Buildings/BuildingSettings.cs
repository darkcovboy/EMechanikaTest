using UnityEngine;

namespace Buildings
{
    [CreateAssetMenu(fileName = "Building", menuName = "Buildings/Settings")]
    public class BuildingSettings : ScriptableObject
    {
        [SerializeField] private int _currency;

        public int Currency => _currency;
    }
}