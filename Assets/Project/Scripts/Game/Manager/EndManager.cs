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
        private bool _end=false;
        public void End()
        {
            if(!_end)
            {
                Physics2D.simulationMode = SimulationMode2D.Script;
                _end=true;
                _unityEvent.Invoke();
            }
        }
    }
}