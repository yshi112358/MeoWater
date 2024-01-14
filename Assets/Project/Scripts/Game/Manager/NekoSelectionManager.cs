using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoSelectionManager : MonoBehaviour
{
    [SerializeField] private NekoDataBaseList _nekoDataBaseList;
    [SerializeField] private SelectionData _selectionData;
    public static List<NekoDataBase> nekoDataBaseListStatic => _nekoDataBaseListStatic;
    private static List<NekoDataBase> _nekoDataBaseListStatic;
    void Awake()
    {
        _nekoDataBaseListStatic = new List<NekoDataBase>();
        foreach (var nekoIndex in _selectionData.neko)
        {
            _nekoDataBaseListStatic.Add(_nekoDataBaseList.nekoDataBaseList[nekoIndex]);
        }
    }

    public static int GetIndex(string nekoName)
    {
        return _nekoDataBaseListStatic.FindIndex(neko => neko.nekoName == nekoName);
    }
}
