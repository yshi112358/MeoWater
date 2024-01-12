using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingOff : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;
    public void InvokeEvent()
    {
        _unityEvent.Invoke();
    }
}
