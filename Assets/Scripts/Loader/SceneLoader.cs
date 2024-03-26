using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loader
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Load(string name) => StartCoroutine(LoadScene(name));

        private IEnumerator LoadScene(string name)
        {
            if(SceneManager.GetActiveScene().name == name)
                yield break;

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);
            _loadingCurtain.Show();

            while (!waitNextScene.isDone)
            {
                yield return null;
            }

            _loadingCurtain.Hide();
        }
    }
}