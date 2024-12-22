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

        [SerializeField] SelectionData _selectionData;
        [SerializeField] private GameObject _tapAnimObj;
        void Start()
        {
            _time = (_selectionData.level == 0) ? 1.5f : 1f;
            
            Observable
                .Interval(System.TimeSpan.FromSeconds(_time))
                .Subscribe(_ =>
                {
                    Instantiate(NekoSelectionManager.nekoDataBaseListStatic[(int)Random.Range(0,4)].tapAnimObj, transform.position, Quaternion.identity, transform);
                }).AddTo(this);
        }
    }
}