using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NekoDataBaseList", menuName = "Project/NekoDataBaseList")]
public class NekoDataBaseList : ScriptableObject
{
    /// <summary>
    /// 0: しろねこ
    /// 1: くろねこ
    /// 2: ちゃねこ
    /// 3: みけねこ
    /// </summary>
    public List<NekoDataBase> nekoDataBaseList => _nekoDataBaseList;
    [SerializeField] private List<NekoDataBase> _nekoDataBaseList = new List<NekoDataBase>(4);
}