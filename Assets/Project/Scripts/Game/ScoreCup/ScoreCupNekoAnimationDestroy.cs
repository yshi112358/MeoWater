using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Score
{
    public class ScoreCupNekoAnimationDestroy : MonoBehaviour
    {
        private ScoreCupRaise _scoreCupRaise;
        public void Destroy()
        {
            _scoreCupRaise.Raise();
            Destroy(gameObject);
        }

        public void SetScoreCupRaise(ScoreCupRaise scoreCupRaise)
        {
            _scoreCupRaise = scoreCupRaise;
        }
    }
}