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
        void Awake()
        {
            _inputEventProvider.Move
                .Subscribe(x =>
                {
                    if(transform.position.x+x<-1f)
                        transform.position = new Vector3(-1f, transform.position.y, 0);
                    else if(transform.position.x+x>1f)
                        transform.position = new Vector3(1f, transform.position.y, 0);
                    else
                        transform.position += new Vector3(x, 0, 0);
                }).AddTo(this);
        }
    }
}