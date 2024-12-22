using UnityEngine;
using UniRx;
using Game.Neko;

namespace Game.Tap
{
    public class TapAnim : MonoBehaviour
    {
        private TapNekoMaker _nekoMaker => transform.parent.parent.Find("Tap (NekoMaker)").GetComponent<TapNekoMaker>();

        private Animator _animator => GetComponent<Animator>();
        private GameObject _gameObject => this.gameObject;

        [SerializeField] private NekoEnum _nekoEnum;

        public void DropNeko()
        {
            _nekoMaker.MakeNeko(NekoSelectionManager.nekoDataBaseListStatic[(int)_nekoEnum]);
            _animator.speed = 0;
            //次のフレームで削除
            Observable.NextFrame()
                .Subscribe(_ => Destroy(_gameObject));
        }
    }
}