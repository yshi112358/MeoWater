using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.NekoDebug
{
    public class DebugSwitch : MonoBehaviour
    {
        public ReactiveProperty<bool> isDebug => _isDebug;
        private ReactiveProperty<bool> _isDebug = new ReactiveProperty<bool>(true);
        public void OnDebugSwitch()
        {
            _isDebug.Value = !_isDebug.Value;
        }
    }
}