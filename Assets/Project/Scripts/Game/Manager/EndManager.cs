using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Events;

namespace Game.Manager
{
    public class EndManager : MonoBehaviour
    {
        [SerializeField] private PauseManager _pauseManager;
        [SerializeField] private GameObject _endPanel;
        [SerializeField] private UnityEvent _unityEvent;
        void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Where(collider => collider.gameObject.tag == "Neko")
                .Subscribe(_ =>
                {
                    _pauseManager.Pause();
                    _endPanel.SetActive(true);
                    _unityEvent.Invoke();
                    Time.timeScale = 0;
                })
                .AddTo(this);
        }
    }
}