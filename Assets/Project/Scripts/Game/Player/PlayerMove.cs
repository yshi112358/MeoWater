using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerMove : MonoBehaviour
    {
        private IInputEventProvider _inputEventProvider => GetComponent<IInputEventProvider>();
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _max = 1.5f;
        void Awake()
        {
            _inputEventProvider.Move
                .Select(x => x * _max)
                .Subscribe(x =>
                {
                    transform.position = new Vector3(Mathf.Clamp(x, -_max, _max), transform.position.y, 0);
                    transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(-x, -_max, _max) * 7);
                }).AddTo(this);
        }
    }
}