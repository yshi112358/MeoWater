using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

namespace Game.Home
{
    public class HomeNekoTap : MonoBehaviour
    {
        [SerializeField] private SceneStateManager _sceneStateManager;
        [SerializeField] private string _sceneName = "Main";
        private Animator _animator => GetComponent<Animator>();
        public void OnHomeGameNekoTap()
        {
            _animator.SetTrigger("Tap");
        }
        public void MoveSceneToGame()
        {
            _sceneStateManager.LoadScene(_sceneName);
        }
    }
}
