using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Neko.Bone
{
    public class BoneCupCollision : MonoBehaviour
    {
        public bool isCollision => _isCollision;
        private bool _isCollision = false;
        private NekoData nekoDataMe => this.GetComponentInParent<NekoData>();
        void Awake()
        {
            this.OnCollisionEnter2DAsObservable()
                .Where(_ => transform.parent.gameObject.activeSelf)
                .Select(collision => collision.gameObject.GetComponentInParent<NekoData>())
                .Where(collision => collision != null)
                .Where(nekoData => nekoData != nekoDataMe)
                .Subscribe(nekoData =>
                {
                    gameObject.layer = 0;
                    _isCollision = true;
                })
                .AddTo(this);
        }
    }
}