using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BookDetailSwitcher : MonoBehaviour
{
    public ReadOnlyReactiveProperty<int> index => _index.ToReadOnlyReactiveProperty();
    private ReactiveProperty<int> _index = new ReactiveProperty<int>(-1);

    public void SetSetectedNekoIndex(int index)
    {
        _index.Value = index;
    }

    public void SetNextNekoIndex()
    {
        _index.Value++;
        if (_index.Value >= 6)
        {
            _index.Value = 0;
        }
    }
    public void SetPrevNekoIndex()
    {
        _index.Value--;
        if (_index.Value < 0)
        {
            _index.Value = 5;
        }
    }
}
