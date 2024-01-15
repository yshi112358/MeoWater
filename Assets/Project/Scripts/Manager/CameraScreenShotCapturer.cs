using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 指定されたカメラの内容をキャプチャするサンプル
/// </summary>
public class CameraScreenShotCapturer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public Sprite sprite => _sprite;

    private Sprite _sprite = null;

    private void Update()
    {
        CaptureScreenShot();
    }

    // カメラのスクリーンショットを保存する
    private void CaptureScreenShot()
    {
        var rt = new RenderTexture(_camera.pixelWidth, _camera.pixelHeight, 24);
        var prev = _camera.targetTexture;
        _camera.targetTexture = rt;
        _camera.Render();
        _camera.targetTexture = prev;
        RenderTexture.active = rt;

        var screenShot = new Texture2D(
            _camera.pixelWidth,
            _camera.pixelHeight,
            TextureFormat.RGB24,
            false);
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();
        _sprite = Sprite.Create(screenShot, new Rect(0, 0, screenShot.width, screenShot.height), Vector2.zero);

        // var bytes = screenShot.EncodeToPNG();
        Destroy(screenShot);

        // File.WriteAllBytes(filePath, bytes);
    }
}
//参照：https://nekojara.city/unity-screenshot