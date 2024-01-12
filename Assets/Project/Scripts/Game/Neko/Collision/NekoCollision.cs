using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Neko.Bone;
using System.Linq;

namespace Game.Neko
{
    public class NekoCollision : MonoBehaviour
    {
        private NekoCollisionList _nekoCollisionList => this.GetComponent<NekoCollisionList>();
        private List<BoneNekoCollisionList> _boneNekoCollisionList => this.GetComponentsInChildren<BoneNekoCollisionList>().ToList();
        void Awake()
        {
            foreach (var boneNekoCollisionList in _boneNekoCollisionList)
            {
                boneNekoCollisionList.nekoCollisionList.ObserveAdd()
                    .Subscribe(nekoData =>
                    {
                        _nekoCollisionList.AddCollisionData(nekoData.Value);
                        
                        // 相手のリストを取得
                        foreach (var nekoDataOnOpponent in nekoData.Value.gameObject.GetComponent<NekoCollisionList>().nekoCollisionList)
                        {
                            // 重複していないか確認
                            if (nekoDataOnOpponent != gameObject.GetComponent<NekoData>() && !_nekoCollisionList.nekoCollisionList.Contains(nekoDataOnOpponent))
                                _nekoCollisionList.AddCollisionData(nekoDataOnOpponent);
                        }
                    })
                    .AddTo(this);
                boneNekoCollisionList.nekoCollisionList.ObserveRemove()
                    .Subscribe(nekoData =>
                    {
                        bool isRemove = true;
                        foreach (var boneNekoCollisionListOther in _boneNekoCollisionList)
                        {
                            if (boneNekoCollisionListOther != boneNekoCollisionList && boneNekoCollisionListOther.nekoCollisionList.Contains(nekoData.Value))
                            {
                                isRemove = false;
                                break;
                            }
                        }
                        if (isRemove)
                            _nekoCollisionList.RemoveCollisionData(nekoData.Value);
                    })
                    .AddTo(this);
            }
        }
    }
}