using UnityEngine;
using UniRx;
using Game.Score;

public class ScoreNumber : MonoBehaviour
{
    void Start()
    {
        ScoreManager.score
            .Subscribe(x =>
            {
                GetComponent<DisplayNumber_10000>().num.Value = x*100;
            }).AddTo(this);
    }
}
