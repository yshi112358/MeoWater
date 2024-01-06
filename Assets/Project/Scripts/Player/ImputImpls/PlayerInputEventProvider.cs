using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Player;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Game.Player.InputImpls
{
    public class PlayerInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        public IReadOnlyReactiveProperty<float> Move => _move;
        private ReactiveProperty<float> _move = new ReactiveProperty<float>(0f);
        private PlayerInputAction _playerInputAction;

        void Awake()
        {
            _playerInputAction = new PlayerInputAction();
            _playerInputAction.bindingMask = InputBinding.MaskByGroup("Gyro");
            _playerInputAction.Enable();
            _playerInputAction.Player.Move.ObserveEveryValueChanged(x => x.ReadValue<float>())
                .Subscribe(x =>
                {
                    _move.Value = x/5f;
                }).AddTo(this);
            
        }
    }
}
