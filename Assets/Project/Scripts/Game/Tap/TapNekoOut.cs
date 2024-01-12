using UnityEngine;
using Game.Neko;

namespace Game.Tap
{
    public class TapNekoOut : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NekoMaker _nekoMaker;

        private NekoData _currentNekoData;

        public void RunAnimation(NekoData nextNekoData, NekoData currentNekoData)
        {
            if (currentNekoData != null)
                _animator.SetTrigger(currentNekoData.nekoName);
            _currentNekoData = currentNekoData;
        }

        public void DropNeko()
        {
            _nekoMaker.MakeNeko(_currentNekoData);
        }
    }
}