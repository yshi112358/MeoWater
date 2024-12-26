using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    public void EndTutorialEvent()
    {
        if(PlayerPrefs.GetInt("Tutorial", 0) == 0)
        {
            _tutorialCanvas.SetActive(true);
        }
        PlayerPrefs.SetInt("Tutorial", 1);
    }
}
