using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

namespace Game.Home
{
    public class HomeAnimationRandom : MonoBehaviour
    {
        private Animator _animator => GetComponent<Animator>();
        [SerializeField] private float _interval = 3f;
        [SerializeField] private int _percent = 25;
        [SerializeField] private int _random = 3;
        void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(_interval))
                .Where(_ => UnityEngine.Random.Range(0, 100 / _percent) == 0)
                .Subscribe(_ => OnHomeGameNekoRandom())
                .AddTo(this);
        }

        private void OnHomeGameNekoRandom()
        {
            var random = UnityEngine.Random.Range(0, _random);
            _animator.SetTrigger("RandomAnimation");
            _animator.SetInteger("Random", random);

        }
    }
}