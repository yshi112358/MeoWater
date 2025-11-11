using Game.Tap;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
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
        Observable.NextFrame()
            .Subscribe(_ =>
            {
                Physics2D.simulationMode = SimulationMode2D.Update;
                Time.timeScale = 1f;
            })
            .AddTo(this);
        _tapMain.init();
        Debug.Log("StartGame!!!!!!!!!!!");
    }
}
