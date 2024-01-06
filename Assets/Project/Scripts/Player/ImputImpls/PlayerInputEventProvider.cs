using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Player;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

namespace Game.Player.InputImpls
{
    public class PlayerInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        public IReadOnlyReactiveProperty<float> Move => _move;
        private ReactiveProperty<float> _move = new ReactiveProperty<float>(0f);
        private PlayerInputAction _playerInputAction;

        [SerializeField]
        private Text text1;
        [SerializeField]
        private Text text2;

        void Awake()
        {
            _playerInputAction = new PlayerInputAction();
            _playerInputAction.bindingMask = InputBinding.MaskByGroup("Gyroscope");
            _playerInputAction.Enable();
            _playerInputAction.Player.Move.ObserveEveryValueChanged(x => x.ReadValue<float>())
                .TakeUntilDestroy(this)
                .Subscribe(x =>
                {
                    _move.Value = x / 5f;
                }).AddTo(this);

            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    var Gyro = UnityEngine.InputSystem.Gyroscope.current;
                    string str = "";
                    if (Gyro != null)
                    {
                        str += "Gyro: ";
                        if (Gyro.enabled)
                        {
                            str += "On";
                            str += "Value: " + Gyro.angularVelocity.ReadValue();
                        }
                        else
                        {
                            str += "Off";
                        }
                    }


                    text1.text = str;
                }).AddTo(this);

            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    var Accel = UnityEngine.InputSystem.Accelerometer.current;
                    string str = "";
                    if (Accel != null)
                    {
                        str += "Accel: ";
                        if (Accel.enabled)
                        {
                            str += "On";
                            str += "Value: " + Accel.acceleration.ReadValue();
                        }
                        else
                        {
                            str += "Off";
                        }
                    }


                    text2.text = str;
                }).AddTo(this);

        }

        public void EnableGyro()
        {
            _playerInputAction.Dispose();
            _playerInputAction = new PlayerInputAction();
            _playerInputAction.bindingMask = InputBinding.MaskByGroup("Gyro");
            _playerInputAction.Enable();
            _playerInputAction.Player.Move.ObserveEveryValueChanged(x => x.ReadValue<float>())
                .Subscribe(x =>
                {
                    _move.Value = x / 5f;
                }).AddTo(this);
        }
        public void EnableTouch()
        {
            _playerInputAction.Dispose();
            _playerInputAction = new PlayerInputAction();
            _playerInputAction.bindingMask = InputBinding.MaskByGroup("Touch");
            _playerInputAction.Enable();
            _playerInputAction.Player.Move.ObserveEveryValueChanged(x => x.ReadValue<float>())
                .Subscribe(x =>
                {
                    _move.Value = x / 200f;
                }).AddTo(this);
        }
    }
}
