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
                SceneStateManager.Instance.LoadScene("Title", true, false);
                SceneStateManager.Instance.LoadScene("Home", true, true);
                SceneState.SetSceneName("Title");
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