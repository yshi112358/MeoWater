using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class HomeUIScaler : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    private float _basisRasioVertical = 1.0f / 2.0f;
    private float _basisRasioHorizontal = 3.0f / 4.0f;

    void Start()
    {
        UpdateRatio();
    }
    void Update()
    {
        UpdateRatio();
    }
    private void UpdateRatio()
    {
        var _scaler = GetComponent<CanvasScaler>();
        var _rectTransformWidth = _rectTransform.rect.width;

        var _ratio = (float)Screen.width / (float)Screen.height;


        if (_ratio > _basisRasioHorizontal)
        {
            //横長の場合 ホームのUIを固定する

            _scaler.matchWidthOrHeight = 1.0f;
            _rectTransform.sizeDelta = new Vector2(1000, 2000);
        }
        else if (_ratio < _basisRasioVertical)
        {
            //縦長の場合 ホームのUIを固定する
            _scaler.matchWidthOrHeight = 0.0f;
            _rectTransform.sizeDelta = new Vector2(1000, 2000);
        }
        else
        {
            //通常 ホームのUIは縦に可変する
            _scaler.matchWidthOrHeight = 0.0f;
            _rectTransform.sizeDelta = new Vector2(_rectTransformWidth, _rectTransformWidth / _ratio);
        }
    }
}
