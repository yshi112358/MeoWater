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
        void Awake()
        {
            _inputEventProvider.Move
                .Select(x => x * _speed)
                .Subscribe(x =>
                {
                    if (transform.position.x + x * Time.deltaTime < -1f)
                        transform.position = new Vector3(-1f, transform.position.y, 0);
                    else if (transform.position.x + x * Time.deltaTime > 1f)
                        transform.position = new Vector3(1f, transform.position.y, 0);
                    else
                        transform.position += new Vector3(x * Time.deltaTime, 0, 0);
                }).AddTo(this);
        }
    }
}