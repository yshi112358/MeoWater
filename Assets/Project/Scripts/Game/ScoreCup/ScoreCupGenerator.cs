using Game.Manager;
using UnityEngine;
using System.Collections.Generic;

namespace Game.Score
{
    public class ScoreCupGenerator : MonoBehaviour
    {
        [SerializeField] private Camera _targetCamera;

        public static List<GameObject> scoreCupList => _scoreCupList;
        private static List<GameObject> _scoreCupList;

        void Start()
        {
            _scoreCupList = new List<GameObject>();
            foreach (var neko in NekoSelectionManager.nekoDataBaseListStatic)
            {
                var obj = Instantiate(neko.nekoCup, transform.position, Quaternion.identity, transform);
                obj.GetComponent<ScoreCupNekoAnimationGenerator>().SetTargetCamera(_targetCamera);
                _scoreCupList.Add(obj);
            }
        }
    }
}