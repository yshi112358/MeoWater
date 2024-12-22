using System.Collections;
using System.Collections.Generic;
using Game.Score;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

[ExecuteInEditMode]
public class DisplayNumber : MonoBehaviour
{
    [SerializeField] private List<Sprite> _numberSpriteList = new List<Sprite>(10);
    [SerializeField] public int num;

    void Awake()
    {
        GetComponent<Image>().sprite = _numberSpriteList[num];
    }
    public void SetNumber(int num)
    {
        GetComponent<Image>().sprite = _numberSpriteList[num];
    }
}
