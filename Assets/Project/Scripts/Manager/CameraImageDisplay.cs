using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CameraImageDisplay : MonoBehaviour
{
    [SerializeField] private CameraScreenShotCapturer _cameraScreenShotCapturer;
    void Update()
    {
        GetComponent<Image>().sprite = _cameraScreenShotCapturer.sprite;
    }
}
