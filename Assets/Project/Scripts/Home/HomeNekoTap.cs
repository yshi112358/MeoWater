using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Home
{
    public class HomeNekoTap : MonoBehaviour
    {
        [SerializeField] private UnityEvent _unityEvent; 
        private Animator _animator => GetComponent<Animator>();
        public void OnHomeGameNekoTap()
        {
            _animator.SetTrigger("Tap");
        }
        public void InvokeEvent()
        {
            _unityEvent.Invoke();
        }
    }
}
