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

namespace Game.Player.InputImpls
{
    public class PlayerInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        public IReadOnlyReactiveProperty<float> Move => _move;
        private ReactiveProperty<float> _move = new ReactiveProperty<float>(0f);

        private IDisposable _disposable = Disposable.Empty;

        void Awake()
        {
            EnableAccel();
        }

        public bool EnableGyro()
        {
            var Gyro = UnityEngine.InputSystem.Gyroscope.current;
            if (Gyro == null)
                return false;

            InputSystem.EnableDevice(Gyro);
            _disposable.Dispose();
            _disposable = Gyro.angularVelocity.y.ObserveEveryValueChanged(x => x.ReadValue())
                .Subscribe(x =>
                {
                    _move.Value = x / 20f;
                }, () => Debug.Log("Gyro Complete")).AddTo(this);
            return true;
        }
        public bool EnableAccel()
        {
            var Accel = UnityEngine.InputSystem.Accelerometer.current;
            if (Accel == null)
                return false;

            InputSystem.EnableDevice(Accel);
            _disposable.Dispose();
            _disposable = Accel.acceleration.x.ObserveEveryValueChanged(x => x.ReadValue())
                .Subscribe(x =>
                {
                    _move.Value = -x / 20f;
                }).AddTo(this);
            return true;
        }
        public bool EnableTouch()
        {
            var Touch = UnityEngine.InputSystem.Touchscreen.current;
            if (Touch == null)
                return false;

            InputSystem.EnableDevice(Touch);
            _disposable.Dispose();
            _disposable = Touch.primaryTouch.position.x.ObserveEveryValueChanged(x => x.ReadValue())
                .Subscribe(x =>
                {
                    _move.Value = (x / (float)Screen.width - 0.5f) / 2f;
                }).AddTo(this);
            return true;
        }
    }
}
