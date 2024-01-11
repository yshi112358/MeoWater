using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Score;

namespace Game.Manager
{
    public class NekoDestroyManager : MonoBehaviour
    {
        [SerializeField] private List<ScoreCupData> _scoreCupDataList = new List<ScoreCupData>(4);
        [SerializeField] private List<ScoreCupNekoAnimationGenerator> _scoreCupNekoAnimationGeneratorList = new List<ScoreCupNekoAnimationGenerator>(4);
        public void OnDestroyNeko(string nekoName,Vector2 vector2)
        {
            _scoreCupDataList.Find(x => x.nekoName == nekoName).GetComponent<ScoreCupNekoAnimationGenerator>().RunAnimation(vector2);
            Debug.Log("Destroy " + nekoName);
        }
    }
}