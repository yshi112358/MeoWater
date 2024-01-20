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
        [SerializeField] private UnityEvent _unityEvent;
        void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Where(collider => collider.gameObject.tag == "Neko")
                .Subscribe(_ =>
                {
                    _unityEvent.Invoke();
                })
                .AddTo(this);
        }
    }
}