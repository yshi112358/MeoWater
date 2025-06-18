using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    public void EndTutorialEvent()
    {
        if (TutorialVariable.Tutorial == 0)
        {
            _tutorialCanvas.SetActive(true);
        }
        TutorialVariable.Tutorial = 1;
    }
}