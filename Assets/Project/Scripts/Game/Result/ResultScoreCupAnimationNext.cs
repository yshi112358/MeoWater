using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Game.Score;
using UnityEngine.Events;

public class ResultScoreCupAnimationNext : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;
    private void Awake()
    {
        var numRepeat = 0;
        foreach (var score in ScoreManager.scoreList)
            numRepeat += score / 30 + 1;

        ResultScoreCupAnimationCounter.counter
            .Where(x => x == numRepeat)
            .Subscribe(_ => _unityEvent.Invoke())
            .AddTo(this);
    }
}
