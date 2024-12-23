using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.InputSystem;
using TMPro;

namespace Game.Player
{
    public class PlayerMove : MonoBehaviour
    {
        private IInputEventProvider _inputEventProvider => GetComponent<IInputEventProvider>();
        void Awake()
        {
            var _initPosition = transform.position;
            _inputEventProvider.point
                .Subscribe(x =>
                {
                    var _worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(x, 0, 1));
                    if(_worldPoint.x < -1)
                        _worldPoint.x = -1;
                    if(_worldPoint.x > 1)
                        _worldPoint.x = 1;
                    var _position = _initPosition + new Vector3(_worldPoint.x, 0, 0);
                    transform.position = _position;
                }).AddTo(this);
        }
    }
}