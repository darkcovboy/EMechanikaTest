using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.MainScene
{
    public class ContinueButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _thisScreen;
        [SerializeField] private GameObject _nextScreen;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _thisScreen.SetActive(false);
            _nextScreen.SetActive(true);
        }
    }
}