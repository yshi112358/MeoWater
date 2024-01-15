using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class SelectionLevelSelected : MonoBehaviour
{
    [SerializeField] private SelectionData _selectionData;
    public void Selected(int level)
    {
        _selectionData.SetLevel(level);
        GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
    }
    public void UnSelected()
    {
        GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0.4f);
    }
}
