using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
namespace Game.Neko
{
    public class NekoData : MonoBehaviour
    {
        public string nekoName => _nekoName;

        [SerializeField]
        private string _nekoName;
    }
}