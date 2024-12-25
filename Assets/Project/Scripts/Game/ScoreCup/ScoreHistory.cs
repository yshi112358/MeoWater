using UnityEngine;
using TMPro;
using System;
public class ScoreHistory : MonoBehaviour
{
    [SerializeField] private String _key = "RecentScore";
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(_key, 0).ToString().PadLeft(5, '0');
    }
}
