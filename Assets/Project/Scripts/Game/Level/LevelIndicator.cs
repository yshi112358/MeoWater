using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIndicator : MonoBehaviour
{
    [SerializeField] private SelectionData _selectionData;
    [SerializeField] GameObject _normal;
    [SerializeField] GameObject _hard;
    void Start()
    {
        if (_selectionData.level == 0)
        {
            _normal.SetActive(true);
            _hard.SetActive(false);
        }
        else
        {
            _normal.SetActive(false);
            _hard.SetActive(true);
        }
    }
}
