using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Manager
{
    public class SceneStateManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        public static SceneStateManager Instance { get; private set; }
        void Awake()
        {
            CheckInstance();
            // シーンがない場合は、最初のシーンをセットする
            // if (SceneState.sceneName.Value == null)
            //     SceneState.SetSceneName(SceneManager.GetSceneAt(0).name);
        }

        private void CheckInstance(){
            if(Instance == null){
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }else{
                Destroy(gameObject);
            }
        }
        
        public void LoadScene(string sceneName)
        {
            StartCoroutine(Load(sceneName));
        }
        public void LoadScene(string sceneName, bool isAdditive, bool setLoadEnd)
        {
            StartCoroutine(Load(sceneName, isAdditive, setLoadEnd));
        }
        public void LoadScene(string sceneName, bool isAdditive, bool setLoadEnd, bool setSceneName)
        {
            StartCoroutine(Load(sceneName, isAdditive, setLoadEnd, setSceneName));
        }
        public void UnloadScene(string sceneName)
        {
            StartCoroutine(UnLoadSceneCo(sceneName));
        }

        private IEnumerator Load(string sceneName, bool isAdditive = false, bool setLoadEnd = true, bool setSceneName = true)
        {
            var activeScene = SceneManager.GetActiveScene().name;
            yield return StartCoroutine(LoadSceneCo("Loading"));
            _text.text += "Loading" + "\n";

            if (activeScene != "Loading")
            {
                var loadingPath = SceneManager.GetSceneByName("Loading");
                _text.text += "Path: Loading" + "\n";
                yield return new WaitUntil(() => SceneManager.SetActiveScene(loadingPath));
                _text.text += "Active: Loading" + "\n";
            }

            if (!isAdditive)
                yield return StartCoroutine(UnLoadSceneCo(activeScene));
            _text.text += "UnLoad: " + activeScene + "\n";

            Resources.UnloadUnusedAssets();
            _text.text += "UnloadUnusedAssets" + "\n";

            // yield return new WaitForSeconds(10f);

            yield return StartCoroutine(LoadSceneCo(sceneName));
            _text.text += "Load: " + sceneName + "\n";

            var scenePath = SceneManager.GetSceneByName(sceneName);
            _text.text += "Path: " + scenePath + "\n";

            yield return new WaitUntil(() => SceneManager.SetActiveScene(scenePath));
            _text.text += "Active: " + sceneName + "\n";

            // yield return new WaitForSeconds(5f);
            _text.text += "Wait" + "\n";

            if(setLoadEnd)
                SceneState.SetLoadEnd(true);
            _text.text += "LoadEnd" + "\n";

            if (setSceneName)
                SceneState.SetSceneName(sceneName);
        }

        private IEnumerator LoadSceneCo(string sceneName)
        {
            SceneState.SetSceneName("Loading");
            var isSceneExist = false;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                _text.text += SceneManager.GetSceneAt(i).name + "\n";
                if (SceneManager.GetSceneAt(i).name == sceneName)
                {
                    isSceneExist = true;
                    break;
                }
            }
            _text.text += "isSceneExist: " + isSceneExist + "\n";
            if (isSceneExist)
                yield break;

            _text.text += "LoadSceneAsync" + "\n";
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
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