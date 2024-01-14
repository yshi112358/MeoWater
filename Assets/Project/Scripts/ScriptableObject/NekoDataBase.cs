using UnityEngine;

[System.Serializable]
public class NekoDataBase
{
    public string nekoName => _nekoName;
    public GameObject nekoPrefab => _nekoPrefab;
    public GameObject nekoCup => _nekoCup;
    public GameObject nekoCupResult => _nekoCupResult;
    public GameObject nekoCupCollection => _nekoCupCollection;


    [SerializeField] private string _nekoName;
    [SerializeField] private GameObject _nekoPrefab;
    [SerializeField] private GameObject _nekoCup;
    [SerializeField] private GameObject _nekoCupResult;
    [SerializeField] private GameObject _nekoCupCollection;
}