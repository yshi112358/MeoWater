using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Game.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static List<int> scoreList => _scoreList;

        private static List<int> _scoreList = new List<int>();

        private static ReactiveProperty<int> _score = new ReactiveProperty<int>(0);
        public static IReadOnlyReactiveProperty<int> score => _score;

        void Awake()
        {
            _scoreList = new List<int>() { 0, 0, 0, 0 };
            _score.Value = 0;
        }

        public static void AddScore(int index, int score)
        {
            _scoreList[index] += score;
            _score.Value += score;
        }
    }
}