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
    [SerializeField] private SceneStateManager _sceneStateManager;
    void Start()
    {
        SceneState.sceneName
            .Where(sceneName => sceneName == "Home")
            .Subscribe(_ => _animator.SetTrigger("Home"));
    }

    public void UnloadTitle()
    {
        _sceneStateManager.UnloadScene("Title");
    }
}
