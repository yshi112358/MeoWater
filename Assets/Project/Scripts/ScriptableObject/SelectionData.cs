using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionData", menuName = "Project/SelectionData", order = 0)]
public class SelectionData : ScriptableObject
{
    /// <summary>
    /// 0: ふつう
    /// 1: むずかしい
    /// </summary>    
    public int level => _level;
    
    /// <summary>
    /// 0: ろうか
    /// </summary>
    public int location => _location;

    /// <summary>
    /// 0: しろねこ
    /// 1: くろねこ
    /// 2: ちゃねこ
    /// 3: みけねこ
    /// </summary>
    public List<int> neko => _neko;

    [SerializeField] private int _level = 0;
    [SerializeField] private int _location = 0;
    [SerializeField] private List<int> _neko = new List<int>();
    
    public void SetLevel(int level)
    {
        _level = level;
    }
}