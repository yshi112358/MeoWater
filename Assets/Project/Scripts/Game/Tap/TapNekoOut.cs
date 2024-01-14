using UnityEngine;
using Game.Neko;

namespace Game.Tap
{
    public class TapNekoOut : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private TapNekoMaker _nekoMaker;

        private NekoDataBase _currentNekoData;

        public void RunAnimation(NekoDataBase nextNekoData, NekoDataBase currentNekoData)
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