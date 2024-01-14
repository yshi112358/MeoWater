using UnityEngine;
using Game.Score;

namespace Game.Manager
{
    public class NekoDestroyManager : MonoBehaviour
    {
        public void OnDestroyNeko(int index,Vector2 vector2)
        {
            ScoreCupGenerator.scoreCupList[index].GetComponent<ScoreCupNekoAnimationGenerator>().RunAnimation(vector2);
        }
    }
}