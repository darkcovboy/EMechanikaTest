using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PointsHandler : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        public List<Transform> Points => _points;
    }
}