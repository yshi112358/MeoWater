using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEvent : MonoBehaviour
{
    [SerializeField] private List<UnityEvent> _unityEvents;

    public void InvokeUnityEvent()
    {
        _unityEvents[0].Invoke();
    }
    public void InvokeUnityEventNum(int n)
    {
        _unityEvents[n].Invoke();
    }
}
