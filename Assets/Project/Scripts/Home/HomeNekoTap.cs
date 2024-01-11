using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

namespace Game.Home
{
    public class HomeNekoTap : MonoBehaviour
    {
        [SerializeField] private string _sceneName = "Main";
        private Animator _animator => GetComponent<Animator>();
        public void OnHomeGameNekoTap()
        {
            _animator.SetTrigger("Tap");
        }
        public void MoveSceneToGame()
        {
            SceneStateManager.Instance.LoadScene(_sceneName);
        }
    }
}
