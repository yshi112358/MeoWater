using System.Collections;
using System.Collections.Generic;
using Game.Score;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class DisplayNumber : MonoBehaviour
{
    [SerializeField] private List<Sprite> _numberSpriteList = new List<Sprite>(10);
    [SerializeField] private int _index;

    void Start()
    {
        ScoreManager.scoreList.ObserveEveryValueChanged(x => x[_index])
            .Subscribe(x =>
            {
                GetComponent<Image>().sprite = _numberSpriteList[x / 30];
            });
    }
}
