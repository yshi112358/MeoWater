using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class DisplayTutorial : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial", 0) == 0) {
                _unityEvent.Invoke();
        }
    }
}
