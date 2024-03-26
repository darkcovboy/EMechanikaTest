using UI.AddButtons;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ClickDisappearObject : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ButtonsHolder _buttonsHolder;


        public void OnPointerClick(PointerEventData eventData)
        {
            gameObject.SetActive(false);
            _buttonsHolder.gameObject.SetActive(true);
        }
    }
}