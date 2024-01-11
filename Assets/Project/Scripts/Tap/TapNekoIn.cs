using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using Game.Neko;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Tap
{
    public class TapNekoIn : MonoBehaviour
    {
        private Animator _animator => GetComponent<Animator>();

        public void RunAnimation(NekoData nextNekoData, NekoData currentNekoData)
        {
            if (currentNekoData != null)
                _animator.SetTrigger("2Out");
            _animator.SetTrigger(nextNekoData.nekoName);
        }
    }
}