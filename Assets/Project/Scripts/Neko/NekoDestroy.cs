using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Manager;

namespace Game.Neko
{
    public class NekoDestroy : MonoBehaviour
    {
        private NekoCollisionList _nekoCollisionList => GetComponent<NekoCollisionList>();
        private NekoDestroyManager _nekoDestroyManager => FindObjectOfType<NekoDestroyManager>();
        private bool _isDestroy = false;
        void Start()
        {
            _nekoCollisionList.nekoCollisionList.ObserveAdd()
                .Where(_ => !_isDestroy)
                .Subscribe(x =>
                {
                    if (_nekoCollisionList.nekoCollisionList.Count >= 2)
                    {
                        var sum = Vector2.zero;
                        foreach (var nekoData in _nekoCollisionList.nekoCollisionList)
                            for (int i = 0; i < nekoData.transform.childCount; i++)
                                sum += (Vector2)nekoData.transform.GetChild(i).position;
                        for (int i = 0; i < transform.childCount; i++)
                            sum += (Vector2)transform.GetChild(i).position;

                        sum /= (_nekoCollisionList.nekoCollisionList.Count + 1) * 8;


                        _nekoDestroyManager.OnDestroyNeko(x.Value.nekoName, sum);
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
            gameObject.SetActive(false);
        }
    }
}