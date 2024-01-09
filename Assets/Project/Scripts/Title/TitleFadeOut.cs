using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Title
{
    public class TitleFadeOut : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public void OnTitleFadeOut()
        {
            _animator.SetTrigger("Title2Home");
        }
    }
}