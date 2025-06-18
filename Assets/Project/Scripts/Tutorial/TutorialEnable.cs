using UnityEngine;

public class TutorialEnable : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    void Awake()
    {
        if (TutorialVariable.Tutorial == 0)
        {
            _tutorialCanvas.SetActive(true);
        }
    }
}
