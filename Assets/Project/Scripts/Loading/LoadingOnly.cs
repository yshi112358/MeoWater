using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Loading
{
    public class LoadingOnly : MonoBehaviour
    {
        [SerializeField] SceneStateManager _sceneStateManager;
        void Awake()
        {
            if (CheckOnlyLoading())
            {
                _sceneStateManager.LoadScene("Title", true);
                _sceneStateManager.LoadScene("Home", true);
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