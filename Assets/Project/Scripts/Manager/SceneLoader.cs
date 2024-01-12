using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Home
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        public void LoadScene()
        {
            SceneStateManager.Instance.LoadScene(_sceneName);
        }
    }
}
