using Game.Tap;
using UnityEngine;
using UnityEngine.Events;

public class StartManager : MonoBehaviour
{
    [SerializeField] TapMain _tapMain;
    [SerializeField] private UnityEvent _unityEvent;
    void Awake()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
        if (PlayerPrefs.GetInt("Tutorial", 0) != 0)
            StartGame();
        else
            _unityEvent.Invoke();
    }
    public void StartGame()
    {
        Physics2D.simulationMode = SimulationMode2D.Update;
        _tapMain.init();
    }
}
