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
    }
}