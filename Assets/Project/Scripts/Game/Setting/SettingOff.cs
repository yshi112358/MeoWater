using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingOff : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    public void SettingPanelOff()
    {
        _settingPanel.SetActive(false);
    }
}
