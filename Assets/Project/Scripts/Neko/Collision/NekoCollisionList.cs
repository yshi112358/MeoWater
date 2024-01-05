using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Neko
{
    public class NekoCollisionList : MonoBehaviour
    {
        public ReactiveCollection<NekoData> nekoCollisionList => _nekoCollisionList;
        private ReactiveCollection<NekoData> _nekoCollisionList = new ReactiveCollection<NekoData>();

        public void AddCollisionData(NekoData nekoData)
        {
            if (!_nekoCollisionList.Contains(nekoData))
                _nekoCollisionList.Add(nekoData);
        }
        public void RemoveCollisionData(NekoData nekoData)
        {
            if (_nekoCollisionList.Contains(nekoData))
                _nekoCollisionList.Remove(nekoData);
        }
    }
}
