using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Neko.Bone
{
    public class BoneNekoCollisionList : MonoBehaviour
    {
        public ReactiveCollection<NekoData> nekoCollisionList => _nekoCollisionList;
        private ReactiveCollection<NekoData> _nekoCollisionList = new ReactiveCollection<NekoData>();

        public void AddNekoCollisionList(NekoData nekoData)
        {
            if (_nekoCollisionList.Contains(nekoData) == false)
                _nekoCollisionList.Add(nekoData);
        }
        public void RemoveNekoCollisionList(NekoData nekoData)
        {
            if (_nekoCollisionList.Contains(nekoData) == true)
                _nekoCollisionList.Remove(nekoData);
        }
    }
}