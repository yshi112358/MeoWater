using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Neko
{
    public class NekoHighLightLine : MonoBehaviour
    {
        public List<GameObject> neko => _neko;
        [SerializeField] private List<GameObject> _neko = new List<GameObject>();
        private LineRenderer _line => GetComponent<LineRenderer>();

        void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    for (int i = 0; i < _neko.Count; i++)
                    {
                        var sum = Vector3.zero;
                        for (int j = 0; j < _neko[i].transform.childCount; j++)
                        {
                            sum += _neko[i].transform.GetChild(j).position;
                        }
                        _line.SetPosition(i, sum / _neko[i].transform.childCount);
                    }
                }).AddTo(this);
        }

        public void SetNeko(GameObject neko1, GameObject neko2)
        {
            _neko.Add(neko1);
            _neko.Add(neko2);
        }
    }
}
