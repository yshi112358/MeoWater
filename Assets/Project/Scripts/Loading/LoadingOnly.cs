using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Loading
{
    public class LoadingOnly : MonoBehaviour
    {
        void Start()
        {
            if (CheckOnlyLoading())
            {
                SceneState.SetSceneName("Loading");
                SceneStateManager.Instance.LoadScene("Home", true, false, false);
                SceneStateManager.Instance.LoadScene("Title", true, true, true);
            }
        }
        private bool CheckOnlyLoading()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name != "Loading")
                {
                    return false;
                }
            }
            return true;
        }
    }
}