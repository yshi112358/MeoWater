using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;

namespace Game.Loading
{
    public class LoadingOut : MonoBehaviour
    {
        private Animator _animator => GetComponent<Animator>();
        [SerializeField] SceneStateManager _sceneStateManager;
        void Start()
        {
            SceneState.loadEnd
                .Where(loadEnd => loadEnd)
                .Subscribe(_ => _animator.SetTrigger("End"))
                .AddTo(this);
        }
        public void OnLoadingOut()
        {
            SceneState.SetLoadEnd(false);
            StartCoroutine(_sceneStateManager.UnLoadLoadingSceneCo());
        }
    }
}