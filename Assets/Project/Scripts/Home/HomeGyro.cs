using Game.Player.InputImpls;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class HomeGyro : MonoBehaviour
{
    [SerializeField] private PlayerInputEventProvider _playerInputEventProvider;
    [SerializeField] private float _moveDistance = 100f;
    private float _defoultPosition;
    void Start()
    {
        _playerInputEventProvider.EnableGyro();

        var rect = GetComponent<RectTransform>();
        _defoultPosition = rect.anchoredPosition.x;
        _playerInputEventProvider.Move
            .Subscribe(x =>
            {
                var gap = rect.anchoredPosition.x - _defoultPosition + x * _moveDistance;
                if (gap < -100f)
                    rect.anchoredPosition = new Vector2(_defoultPosition + -100f, rect.anchoredPosition.y);
                else if (gap > 100f)
                    rect.anchoredPosition = new Vector2(_defoultPosition + 100f, rect.anchoredPosition.y);
                else
                    rect.anchoredPosition += new Vector2(x * _moveDistance, 0);
            }).AddTo(this);
    }
}
