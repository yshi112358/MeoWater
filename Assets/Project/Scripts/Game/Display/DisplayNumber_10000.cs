using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DisplayNumber_10000 : MonoBehaviour
{
    [SerializeField] public ReactiveProperty<int> num = new ReactiveProperty<int>();
    [SerializeField] private List<DisplayNumber> _displayNumber = new List<DisplayNumber>(5);
    void Awake()
    {
        num.ObserveEveryValueChanged(x => x.Value)
            .Subscribe(x =>
            {
                var numStr = x.ToString();
                for (int i = 0; i < 5 - numStr.Length; i++)
                {
                    _displayNumber[i].SetNumber(0);
                }
                for (int i = 5 - numStr.Length; i < 5; i++)
                {
                    _displayNumber[i].SetNumber(int.Parse(numStr[i - 5 + numStr.Length].ToString()));
                }
            }).AddTo(this);
    }
}
