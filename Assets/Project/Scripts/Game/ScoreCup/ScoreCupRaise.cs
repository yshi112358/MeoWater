using UnityEngine;

namespace Game.Score
{
    public class ScoreCupRaise : MonoBehaviour
    {
        [SerializeField] private float _raiseSpeed = 10f;
        public void Raise()
        {
            GetComponent<RectTransform>().anchoredPosition += new Vector2(0, _raiseSpeed);
        }
    }
}