using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

namespace Game.Home
{
    public class HomeGameNekoTap : MonoBehaviour
    {
        [SerializeField] private SceneStateManager _sceneStateManager;
        private Animator _animator => GetComponent<Animator>();
        public void OnHomeGameNekoTap()
        {
            _animator.SetTrigger("Tap");
            Debug.Log("HomeGameNekoTap");
        }
        public void MoveSceneToGame()
        {
            _sceneStateManager.LoadScene("Main");
        }
    }
}
