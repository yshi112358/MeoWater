using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Neko;
using UniRx;
using UnityEngine;

namespace Game.Manager
{
    public class NekoManager : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<NekoData> nextNekoData => _nextNekoData;
        private readonly ReactiveProperty<NekoData> _nextNekoData = new ReactiveProperty<NekoData>();
        public IReadOnlyReactiveProperty<NekoData> currentNekoData => _currentNekoData;
        private readonly ReactiveProperty<NekoData> _currentNekoData = new ReactiveProperty<NekoData>();

        public GameObject[] neko => _neko;
        [SerializeField] private GameObject[] _neko;

        private float _time = 3f;

        void Start()
        {
            Observable
                .Interval(System.TimeSpan.FromSeconds(_time))
                .Subscribe(_ =>
                {
                    _currentNekoData.Value = _nextNekoData.Value;
                    Debug.Log(_currentNekoData.Value);
                    _nextNekoData.Value = _neko[Random.Range(0, _neko.Count())].GetComponent<NekoData>();
                }).AddTo(this);
        }
    }
}