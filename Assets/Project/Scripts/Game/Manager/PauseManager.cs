using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Manager
{
    public class PauseManager : MonoBehaviour
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = Mathf.Clamp(LevelManager.speed, 1f, LevelManager.speedMax);
        }
    }
}