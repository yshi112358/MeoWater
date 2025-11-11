using UnityEngine;
using Game.Manager;

public class TutorialEnable : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    [SerializeField] private StartManager _startManager;
    void Awake()
    {
        if (TutorialVariable.Tutorial == 0)
        {
            _tutorialCanvas.SetActive(true);
        }
        else
        {
            _startManager.StartGame();
        }
    }
}
