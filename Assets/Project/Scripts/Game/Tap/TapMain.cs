using UnityEngine;
using UniRx;
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
        private bool _paused = false;

        public void init()
        {
            _time = (_selectionData.level == 0) ? 1.5f : 1f;

            Observable
                .Interval(System.TimeSpan.FromSeconds(_time))
                .Where(_ => !_paused)
                .Subscribe(_ =>
                {
                    Instantiate(NekoSelectionManager.nekoDataBaseListStatic[(int)Random.Range(0, 4)].tapAnimObj, transform.position, Quaternion.identity, transform);
                }).AddTo(this);
        }

        public void PauseAnim()
        {
            _paused = !_paused;
            foreach (Transform child in transform)
            {
                child.GetComponent<Animator>().speed = 0;
            }
        }
    }
}