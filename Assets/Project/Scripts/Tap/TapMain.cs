using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Neko;
using System.Linq;

namespace Game.Tap
{
    public class TapMain : MonoBehaviour
    {
        public NekoData nextNekoData => _nextNekoData;
        private NekoData _nextNekoData;
        public NekoData currentNekoData => _currentNekoData;
        private NekoData _currentNekoData;

        public GameObject[] neko => _neko;
        [SerializeField] private GameObject[] _neko;

        [SerializeField] private float _time = 3f;
        [SerializeField] private TapNekoIn _tapNekoIn;
        [SerializeField] private TapNekoOut _tapNekoOut;
        void Start()
        {
            Observable
                .Interval(System.TimeSpan.FromSeconds(_time))
                .Subscribe(_ =>
                {
                    _currentNekoData = _nextNekoData;
                    _nextNekoData = _neko[Random.Range(0, _neko.Count())].GetComponent<NekoData>();

                    _tapNekoIn.RunAnimation(_nextNekoData, _currentNekoData);
                    _tapNekoOut.RunAnimation(_nextNekoData, _currentNekoData);
                }).AddTo(this);
        }
    }
}