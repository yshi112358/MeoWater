using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Score
{
    public class ScoreCupNekoAnimationGenerator : MonoBehaviour
    {
        [SerializeField] private ScoreCupData _scoreCupData;
        [SerializeField] private ScoreCupRaise _scoreCupRaise;

        private Camera _targetCamera;

        public void RunAnimation(Vector2 vector2)
        {
            var animationObject = Instantiate(_scoreCupData.nekoAnimation, Vector3.zero, Quaternion.identity, transform);
            var rect = animationObject.GetComponent<RectTransform>();

            rect.anchoredPosition = Vector3.zero;
            animationObject.GetComponent<ScoreCupNekoAnimationDestroy>().SetScoreCupRaise(_scoreCupRaise);

            var pos = Vector2.zero;
            var screenPos = RectTransformUtility.WorldToScreenPoint(_targetCamera, vector2);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), screenPos, _targetCamera, out pos);

            rect.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg + 90);
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, pos.magnitude);
        }
        public void SetTargetCamera(Camera targetCamera)
        {
            _targetCamera = targetCamera;
        }
    }
}