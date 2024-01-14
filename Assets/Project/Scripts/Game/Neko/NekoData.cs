using UnityEngine;

namespace Game.Neko
{
    public class NekoData : MonoBehaviour
    {
        public string nekoName => _nekoName;

        [SerializeField]
        private string _nekoName;
    }
}