using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

namespace Game.Title
{
    public class Title2Home : MonoBehaviour
    {
        public void OnTitle2Home()
        {
            SceneState.SetSceneName("Home");
        }
    }
}
