using Game.Score;
using UnityEngine;
using UniRx;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float _levelSpan = 100f;
    public static float speedMax = 3f;
    public static float speed;

    void Start()
    {

        Time.timeScale = 1;
        ScoreManager.score
            .Subscribe(x =>
            {
                speed = 1f + x / _levelSpan;
                Time.timeScale = Mathf.Clamp(speed, 1f, speedMax);
            });
    }
}
