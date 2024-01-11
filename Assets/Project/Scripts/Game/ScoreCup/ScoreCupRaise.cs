using UnityEngine;

namespace Game.Score
{
    public class ScoreCupRaise : MonoBehaviour
    {
        [SerializeField] private float _raiseSpeed = 10f;
        public void Raise()
        {
            transform.position += new Vector3(0, _raiseSpeed, 0);
        }
    }
}