using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace PersistentData
{
    public class ProgressSaver : MonoBehaviour
    {
        private Progress _progress;

        [Inject]
        public void Constructor(Progress progress)
        {
            _progress = progress;
        }
        private void Start()
        {
            StartCoroutine(SaveProgress());
        }

        private IEnumerator SaveProgress()
        {
            while (true)
            {
                _progress.Save();
                yield return new WaitForSeconds(15f);
            }
        }
    }
}