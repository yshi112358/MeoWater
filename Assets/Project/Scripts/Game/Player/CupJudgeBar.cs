using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Game.Neko.Bone;
using Game.Manager;

namespace Game
{
    public class CupJudgeBar : MonoBehaviour
    {
        [SerializeField] private EndManager _endManager;
        void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(x =>
                {
                    if (x.CompareTag("Neko") && x.GetComponent<BoneCupCollision>().isCollision)
                    {
                        _endManager.End();
                    }
                }).AddTo(this);
        }
    }
}