using UnityEngine;
using UnityEngine.Events;

public class InvokeEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;
    public void InvokeUnityEvent()
    {
        _unityEvent.Invoke();
    }
}
