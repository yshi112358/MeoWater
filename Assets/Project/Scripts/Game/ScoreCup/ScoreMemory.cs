using Game.Score;
using UnityEngine;

public class ScoreMemory : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("RecentScore", ScoreManager.score.Value);
        if(PlayerPrefs.GetInt("MaxScore", 0) < ScoreManager.score.Value)
        {
            PlayerPrefs.SetInt("MaxScore", ScoreManager.score.Value);
        }
    }
}
