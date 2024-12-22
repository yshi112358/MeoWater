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
        public void End()
        {
            _unityEvent.Invoke();
        }
    }
}