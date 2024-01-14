using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static List<int> scoreList => _scoreList;

        private static List<int> _scoreList = new List<int>();

        void Awake()
        {
            _scoreList = new List<int>(){0, 0, 0, 0};
        }

        public static void AddScore(int index, int score)
        {
            _scoreList[index] += score;
        }
    }
}