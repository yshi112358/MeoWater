using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;

public class HomeAnimationFromTitle : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
        SceneState.sceneName
            .Where(sceneName => sceneName == "Home")
            .Subscribe(_ => _animator.SetTrigger("Home"))
            .AddTo(this);
    }

    public void UnloadTitle()
    {
        SceneStateManager.Instance.UnloadScene("Title");
    }
}
