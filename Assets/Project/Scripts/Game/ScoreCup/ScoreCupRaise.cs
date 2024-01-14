using UnityEngine;

namespace Game.Score
{
    public class ScoreCupRaise : MonoBehaviour
    {
        private RectTransform _rectTransform => GetComponent<RectTransform>();
        private float _defaultPositionY;
        [SerializeField] private float _raiseSpeed = 3f;
        [SerializeField] private int _max = 30;
        [SerializeField] private ScoreCupData _scoreCupData;

        private void Start()
        {
            _defaultPositionY = _rectTransform.anchoredPosition.y;
        }

        public void Raise()
        {
            _rectTransform.anchoredPosition = new Vector2(0, ScoreManager.scoreList[_scoreCupData.index] % _max * _raiseSpeed + _defaultPositionY);
        }
    }
}