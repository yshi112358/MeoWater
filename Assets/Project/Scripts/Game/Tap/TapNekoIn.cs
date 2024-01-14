using Game.Neko;
using UnityEngine;

namespace Game.Tap
{
    public class TapNekoIn : MonoBehaviour
    {
        private Animator _animator => GetComponent<Animator>();

        public void RunAnimation(NekoDataBase nextNekoData, NekoDataBase currentNekoData)
        {
            if (currentNekoData != null)
                _animator.SetTrigger("2Out");
            _animator.SetTrigger(nextNekoData.nekoName);
        }
    }
}