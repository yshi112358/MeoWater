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
        public IReadOnlyReactiveProperty<float> Move => _move;
        private ReactiveProperty<float> _move = new ReactiveProperty<float>(0f);

        private IDisposable _disposable = Disposable.Empty;
        private float _moveMax => Time.deltaTime;

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

            _move.Value = 0;
            var sensorValue = new List<float>();
            var preAve = 0f;
            _disposable.Dispose();
            _disposable = this.UpdateAsObservable()
                .Select(_ => Accel.acceleration.x.ReadValue())
                .Subscribe(x =>
                {
                    if (sensorValue.Count <= 4)
                        sensorValue.Add(x);
                    else
                    {
                        sensorValue.RemoveAt(0);
                        sensorValue.Add(x);
                    }
                    var average = sensorValue.Average();
                    if (preAve * average > 0)
                    {
                        var preValue = _move.Value;
                        var newValue = -average * 1.3f;
                        if (Mathf.Abs(newValue - preValue) > _moveMax / 2)
                            _move.Value += Mathf.Clamp(newValue - preValue, -_moveMax, _moveMax);
                    }
                    preAve = average;
                }).AddTo(this);
            return true;
        }
        public bool EnableTouch()
        {
            var Touch = UnityEngine.InputSystem.Touchscreen.current;
            if (Touch == null)
                return false;

            InputSystem.EnableDevice(Touch);
            _move.Value = 0;
            _disposable.Dispose();
            _disposable = this.UpdateAsObservable()
                .Select(_ => Touch.primaryTouch.position.x.ReadValue())
                .Subscribe(x =>
                {
                    var preValue = _move.Value;
                    var newValue = (x - (float)Screen.width / 2) / (float)Screen.width;
                    _move.Value += Mathf.Clamp(newValue - preValue, -_moveMax, _moveMax);
                }).AddTo(this);
            return true;
        }
        public bool EnableMouse()
        {
            var Mouse = UnityEngine.InputSystem.Mouse.current;
            if (Mouse == null)
                return false;

            InputSystem.EnableDevice(Mouse);
            _move.Value = 0;
            _disposable.Dispose();
            _disposable = this.UpdateAsObservable()
                .Select(_ => Mouse.position.x.ReadValue())
                .Subscribe(x =>
                {
                    var preValue = _move.Value;
                    var newValue = (x - (float)Screen.width / 2) / (float)Screen.width;
                    _move.Value += Mathf.Clamp(newValue - preValue, -_moveMax, _moveMax);
                }).AddTo(this);
            return true;
        }
    }
}
