using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Neko
{
    public class NekoHighLight : MonoBehaviour
    {
        [SerializeField] private GameObject _lineObj;
        private List<GameObject> _neko = new List<GameObject>();
        private List<GameObject> _lineList = new List<GameObject>();
        [SerializeField] private TapNekoMaker _tapNekoMaker;

        void Start()
        {
            _tapNekoMaker.nekoList.ObserveAdd()
                .Select(nekoData => nekoData.Value.gameObject)
                .Subscribe(neko1 =>
                {
                    neko1.GetComponent<NekoCollisionList>().nekoCollisionList.ObserveAdd()
                        .Select(nekoData => nekoData.Value.gameObject)
                        .Subscribe(neko2 =>
                        {
                            if (neko1.GetComponent<NekoData>().nekoName == neko2.GetComponent<NekoData>().nekoName
                                && IsContainNeko(neko1, neko2) == null)
                            {
                                var _line = Instantiate(_lineObj, Vector3.zero, Quaternion.identity);
                                _line.GetComponent<NekoHighLightLine>().SetNeko(neko1, neko2);
                                _lineList.Add(_line);
                            }
                        }).AddTo(this);
                    neko1.GetComponent<NekoCollisionList>().nekoCollisionList.ObserveRemove()
                        .Select(nekoData => nekoData.Value.gameObject)
                        .Subscribe(neko2 =>
                        {
                            var _line = IsContainNeko(neko1, neko2);
                            Debug.Log(_line);
                            if (_line != null)
                            {
                                _lineList.Remove(_line);
                                Destroy(_line);
                            }
                        }).AddTo(this);
                }).AddTo(this);
        }

        private GameObject IsContainNeko(GameObject neko1, GameObject neko2)
        {
            foreach (var line in _lineList)
            {
                var _listInLine = line.GetComponent<NekoHighLightLine>().neko;
                if (_listInLine.Contains(neko1) && _listInLine.Contains(neko2))
                    return line;
            }
            return null;
        }
        public void DestroyLine(GameObject neko1)
        {
            var _line = _lineList.Find(line => line.GetComponent<NekoHighLightLine>().neko.Contains(neko1));
            if (_line != null)
            {
                _lineList.Remove(_line);
                Destroy(_line);
            }
        }
    }
}