using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Game.Neko.Bone
{
    public class BoneNekoCollision : MonoBehaviour
    {
        private NekoData nekoDataMe => this.GetComponentInParent<NekoData>();
        private BoneNekoCollisionList boneNekoCollisionList => this.GetComponent<BoneNekoCollisionList>();
        void Awake()
        {
            this.OnCollisionEnter2DAsObservable()
                .Where(_ => transform.parent.gameObject.activeSelf)
                .Select(collision => collision.gameObject.GetComponentInParent<NekoData>())
                .Where(collision => collision != null)
                .Where(nekoData => nekoData != nekoDataMe)
                .Where(nekoData => nekoData.name == nekoDataMe.name)
                .Subscribe(nekoData => boneNekoCollisionList.AddNekoCollisionList(nekoData))
                .AddTo(this);

            this.OnCollisionExit2DAsObservable()
                .Where(_ => transform.parent.gameObject.activeSelf)
                .Select(collision => collision.gameObject.GetComponentInParent<NekoData>())
                .Where(collision => collision != null)
                .Where(nekoData => nekoData != nekoDataMe)
                .Where(nekoData => nekoData.name == nekoDataMe.name)
                .Subscribe(nekoData => boneNekoCollisionList.RemoveNekoCollisionList(nekoData))
                .AddTo(this);
        }
    }
}