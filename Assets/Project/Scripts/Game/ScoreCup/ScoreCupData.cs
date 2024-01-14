using UnityEngine;

namespace Game.Score
{
    public class ScoreCupData : MonoBehaviour
    {
        public string nekoName => _nekoName;
        [SerializeField] private string _nekoName;

        public GameObject nekoAnimation => _nekoAnimation;
        [SerializeField] private GameObject _nekoAnimation;

        public int index => _index;
        private int _index;

        private void Start()
        {
            _index = NekoSelectionManager.GetIndex(_nekoName);
        }
    }
}