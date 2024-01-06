using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Neko
{
    public class NekoDestroy : MonoBehaviour
    {
        private NekoCollisionList _nekoCollisionList => GetComponent<NekoCollisionList>();
        void Start()
        {
            _nekoCollisionList.nekoCollisionList.ObserveAdd().Subscribe(x =>
            {
                if(_nekoCollisionList.nekoCollisionList.Count >= 2)
                {
                    foreach(var nekoData in _nekoCollisionList.nekoCollisionList)
                    {
                        nekoData.gameObject.SetActive(false);
                    }
                    gameObject.SetActive(false);
                }
            }).AddTo(this);
        }
    }
}