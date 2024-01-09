using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

namespace Game.Home
{
    public class HomeGameNekoRandom : MonoBehaviour
    {
        private Animator _animator => GetComponent<Animator>();
        void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(3))
                .Where(_=>UnityEngine.Random.Range(0, 4) == 0)
                .Subscribe(_ => OnHomeGameNekoRandom())
                .AddTo(this);
        }

        private void OnHomeGameNekoRandom()
        {
            var random = UnityEngine.Random.Range(0, 3);
            _animator.SetTrigger("RandomAnimation");
            _animator.SetInteger("Random", random);

        }
    }
}