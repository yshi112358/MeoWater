using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Manager
{
    public class SceneStateManager : MonoBehaviour
    {
        void Awake()
        {
            // シーンがない場合は、最初のシーンをセットする
            if (SceneState.sceneName.Value == null)
                SceneState.SetSceneName(SceneManager.GetSceneAt(0).name);
        }
        public void LoadScene(string sceneName)
        {
            StartCoroutine(Load(sceneName));
        }
        public void LoadScene(string sceneName, bool isAdditive)
        {
            StartCoroutine(Load(sceneName, isAdditive));
        }
        public void UnloadScene(string sceneName)
        {
            StartCoroutine(UnLoadSceneCo(sceneName));
            Debug.Log("SceneStateManager.UnloadScene: " + sceneName + " is not found.");
        }

        private IEnumerator Load(string sceneName, bool isAdditive = false)
        {
            var activeScene = SceneManager.GetActiveScene().name;
            yield return StartCoroutine(LoadSceneCo("Loading"));

            yield return new WaitForSeconds(1f);

            yield return StartCoroutine(LoadSceneCo(sceneName));
            yield return new WaitUntil(() => SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName)));

            SceneState.SetLoadEnd(true);

            if (!isAdditive)
                yield return StartCoroutine(UnLoadSceneCo(activeScene));
        }

        private IEnumerator LoadSceneCo(string sceneName)
        {
            var isSceneExist = false;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == sceneName)
                {
                    isSceneExist = true;
                    break;
                }
            }
            if (isSceneExist)
                yield break;

            var async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!async.isDone)
            {
                yield return null;
            }
        }
        private IEnumerator UnLoadSceneCo(string sceneName)
        {
            var isSceneExist = false;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == sceneName)
                {
                    isSceneExist = true;
                    break;
                }
            }
            if (!isSceneExist)
                yield break;

            var async = SceneManager.UnloadSceneAsync(sceneName);
            while (!async.isDone)
            {
                yield return null;
            }
        }

        public IEnumerator UnLoadLoadingSceneCo()
        {
            var async = SceneManager.UnloadSceneAsync("Loading");
            while (!async.isDone)
            {
                yield return null;
            }
        }
    }
}