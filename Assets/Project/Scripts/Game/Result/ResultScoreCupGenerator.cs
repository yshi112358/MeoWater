using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Score;

public class ResultScoreCupGenerator : MonoBehaviour
{
    private List<Animator> _cupAnimatorList = new List<Animator>();

    public static List<GameObject> cupList => _cupList;
    private static List<GameObject> _cupList = new List<GameObject>();
    void Awake()
    {
        int index = 1;
        foreach (var neko in NekoSelectionManager.nekoDataBaseListStatic)
        {
            var nekoIndex = NekoSelectionManager.GetIndex(neko.nekoName);
            var nekoScoreCup = Instantiate(neko.nekoCupResult, transform);
            _cupAnimatorList.Add(nekoScoreCup.transform.GetChild(2).GetComponent<Animator>());
            _cupList.Add(nekoScoreCup);
            nekoScoreCup.name = "Cup " + index;
            index++;
        }
    }

    public void OnScoreCupAnimation()
    {
        foreach (var child in _cupAnimatorList)
        {
            child.Rebind();
            child.SetInteger("Amount", ScoreManager.scoreList[_cupAnimatorList.IndexOf(child)] % 30);
            child.SetTrigger("Trigger");
        }
    }
}
