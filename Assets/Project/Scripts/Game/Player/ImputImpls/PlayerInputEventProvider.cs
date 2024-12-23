using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Player;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using System;
using System.Linq;

namespace Game.Player.InputImpls
{
    public class PlayerInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        public IReadOnlyReactiveProperty<float> point => _point;
        private ReactiveProperty<float> _point = new ReactiveProperty<float>(0f);

        private IDisposable _disposable = Disposable.Empty;
        private float _pointMax => Time.deltaTime;

        void Awake()
        {
#if UNITY_ANDROID
            EnableTouch();
#elif UNITY_IPHONE
            EnableTouch();
#else
            EnableMouse();
#endif
        }

        public bool EnableTouch()
        {
            var Touch = UnityEngine.InputSystem.Touchscreen.current;
            if (Touch == null)
                return false;

            InputSystem.EnableDevice(Touch);
            _point.Value = Screen.width / 2;
            _disposable.Dispose();
            _disposable = this.UpdateAsObservable()
                .Where(_ => Touch.primaryTouch.press.isPressed || Touch.primaryTouch.press.wasPressedThisFrame)
                .Select(_ => Touch.primaryTouch.position.x.ReadValue())
                .Subscribe(x =>
                {
                    _point.Value = x;
                }).AddTo(this);
            return true;
        }

        public bool EnableMouse()
        {
            var Mouse = UnityEngine.InputSystem.Mouse.current;
            if (Mouse == null)
                return false;

            InputSystem.EnableDevice(Mouse);
            _point.Value = Screen.width / 2;
            _disposable.Dispose();
            _disposable = this.UpdateAsObservable()
                .Where(_ => Mouse.leftButton.isPressed || Mouse.leftButton.wasPressedThisFrame)
                .Select(_ => Mouse.position.x.ReadValue())
                .Subscribe(x =>
                {
                    _point.Value = x;
                }).AddTo(this);
            return true;
        }
    }
}
