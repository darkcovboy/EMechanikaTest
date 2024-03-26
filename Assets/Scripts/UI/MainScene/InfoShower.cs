using PersistentData;
using UnityEngine;
using Zenject;

namespace UI.MainScene
{
    public class InfoShower : MonoBehaviour
    {
        [SerializeField] private Menu _menu;

        [Inject]
        public void Constructor(Progress progress)
        {
            if (progress.ProgressData.IntroduceCutsceneShowed == true)
            {
                _menu.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                progress.ProgressData.IntroduceCutsceneShowed = true;
                progress.Save();
            }
        }
    }
}