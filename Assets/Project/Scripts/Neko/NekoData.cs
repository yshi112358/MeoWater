using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
namespace Game.Neko
{
    public class NekoData : MonoBehaviour
    {
        public string name => _name;

        [SerializeField]
        private string _name;
    }
}