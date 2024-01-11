using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Score
{
    public class ScoreCupNekoAnimationGenerator : MonoBehaviour
    {
        [SerializeField] private ScoreCupData _scoreCupData;
        [SerializeField] private Camera _targetCamera;
        public void RunAnimation(Vector2 vector2)
        {
            var animation = Instantiate(_scoreCupData.nekoAnimation, Vector3.zero, Quaternion.identity, transform);
            animation.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            animation.GetComponent<ScoreCupNekoAnimationDestroy>().SetScoreCupRaise(GetComponent<ScoreCupRaise>());
            var size = _targetCamera.WorldToScreenPoint(vector2);
            var basis = GetComponent<RectTransform>().position;
            var gap = size - basis;
            Debug.Log(size);
            Debug.Log(basis);

            var rect= animation.GetComponent<RectTransform>();
            rect.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(gap.y, gap.x) * Mathf.Rad2Deg + 90);
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, gap.magnitude);
        }
    }
}