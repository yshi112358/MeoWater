using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultScoreCupAnimationCounter : MonoBehaviour
{
    private static ReactiveProperty<int> _counter = new ReactiveProperty<int>(0);
    public static ReadOnlyReactiveProperty<int> counter => _counter.ToReadOnlyReactiveProperty();
    public void AddCounter()
    {
        _counter.Value ++;
    }
}
