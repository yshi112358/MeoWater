using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Game.Score;

public class ResultScoreCupAnimationCounter : MonoBehaviour
{
    private static ReactiveProperty<int> _counter = new ReactiveProperty<int>(0);
    public static ReadOnlyReactiveProperty<int> counter => _counter.ToReadOnlyReactiveProperty();

    [SerializeField] private Animator _animator;
    private int index = 0;
    void Start()
    {
        foreach (var cup in ResultScoreCupGenerator.cupList)
        {
            if (transform.IsChildOf(cup.transform))
                break;
            index++;
        }

    }
    public void AddCounter()
    {
        _counter.Value++;
    }

    public void AnimationResume()
    {
        if (ScoreManager.scoreList[index] / 30 > _counter.Value)
            _animator.SetTrigger("JumpAgain");
    }
}
