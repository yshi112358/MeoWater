using UnityEngine;
using UniRx;
using Game.Neko;
using System.Linq;

namespace Game.Tap
{
    public class TapMain : MonoBehaviour
    {
        public NekoDataBase nextNekoData => _nextNekoData;
        private NekoDataBase _nextNekoData;
        public NekoDataBase currentNekoData => _currentNekoData;
        private NekoDataBase _currentNekoData;

        [SerializeField] private float _time = 3f;
        [SerializeField] private TapNekoIn _tapNekoIn;
        [SerializeField] private TapNekoOut _tapNekoOut;

        [SerializeField] SelectionData _selectionData;
        void Start()
        {
            _time = (_selectionData.level == 0) ? 3f : 2f;
            
            Observable
                .Interval(System.TimeSpan.FromSeconds(_time))
                .Subscribe(_ =>
                {
                    _currentNekoData = _nextNekoData;
                    _nextNekoData = NekoSelectionManager.nekoDataBaseListStatic[Random.Range(0, 4)];

                    _tapNekoIn.RunAnimation(_nextNekoData, _currentNekoData);
                    _tapNekoOut.RunAnimation(_nextNekoData, _currentNekoData);
                }).AddTo(this);
        }
    }
}