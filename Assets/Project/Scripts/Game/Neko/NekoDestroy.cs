using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Manager;
using Game.Score;

namespace Game.Neko
{
    public class NekoDestroy : MonoBehaviour
    {
        private NekoCollisionList _nekoCollisionList => GetComponent<NekoCollisionList>();
        private NekoDestroyManager _nekoDestroyManager => FindObjectsByType<NekoDestroyManager>(FindObjectsSortMode.None)[0];
        private bool _isDestroy = false;
        private NekoHighLight _nekoHighLight => FindObjectsByType<NekoHighLight>(FindObjectsSortMode.None)[0];

        [SerializeField] SelectionData _selectionData;
        void Start()
        {
            _nekoCollisionList.nekoCollisionList.ObserveAdd()
                .Where(_ => !_isDestroy)
                .Subscribe(x =>
                {
                    var nekoCount = _nekoCollisionList.nekoCollisionList.Count;
                    if (nekoCount >= 2)
                    {
                        var sum = Vector2.zero;
                        foreach (var nekoData in _nekoCollisionList.nekoCollisionList)
                            for (int i = 0; i < nekoData.transform.childCount; i++)
                                sum += (Vector2)nekoData.transform.GetChild(i).position;
                        for (int i = 0; i < transform.childCount; i++)
                            sum += (Vector2)transform.GetChild(i).position;

                        sum /= (nekoCount + 1) * 8;

                        var nekoIndex = NekoSelectionManager.GetIndex(x.Value.nekoName);
                        _nekoDestroyManager.OnDestroyNeko(nekoIndex, sum);
                        ScoreManager.AddScore(nekoIndex, nekoCount + 1);
                        foreach (var nekoData in _nekoCollisionList.nekoCollisionList)
                        {
                            nekoData.GetComponent<NekoDestroy>().DestroyNeko();
                        }
                        DestroyNeko();
                    }
                }).AddTo(this);
        }

        public void DestroyNeko()
        {
            _isDestroy = true;
            _nekoHighLight.DestroyLine(gameObject);
            gameObject.SetActive(false);
        }
    }
}