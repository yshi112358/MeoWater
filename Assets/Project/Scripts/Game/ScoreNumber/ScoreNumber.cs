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
                GetComponent<DisplayNumber_10000>().num.Value = System.Math.Min(x,99999);//upto 99999
            }).AddTo(this);
    }
}
