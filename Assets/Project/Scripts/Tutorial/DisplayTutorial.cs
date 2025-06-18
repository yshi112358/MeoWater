using UnityEngine;
using UnityEngine.Events;

public class DisplayTutorial : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;
    void Start()
    {
        if (TutorialVariable.Tutorial == 0)
        {
            _unityEvent.Invoke();
        }
    }
}
