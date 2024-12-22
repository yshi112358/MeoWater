using UnityEngine;
using UniRx;
using Game.Score;

public class ScorePopup : MonoBehaviour
{
    [SerializeField] private GameObject _scorePopup;
    void Start()
    {
        ScoreManager.score
            .Subscribe(x =>
            {
                if (x > 0)
                {
                    ScoreAdded();
                }
            }).AddTo(this);
    }
    public void ScoreAdded()
    {
        Instantiate(_scorePopup, Vector3.zero, Quaternion.identity, transform);
    }
}
