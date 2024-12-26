using UnityEngine;
using UnityEngine.UI;

public class MusicSwitch : MonoBehaviour
{
    [SerializeField] private Image _musicOn;
    [SerializeField] private Image _musicOff;
    void Start()
    {
        SwitchColor();
    }
    public void MusicSwitchEvent()
    {
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            SwitchColor();
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            SwitchColor();
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    private void SwitchColor(){
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            Color _color1 = _musicOn.color;
            _color1.a = 1.0f;
            _musicOn.color = _color1;

            Color _color2 = _musicOn.color;
            _color2.a = 0.3f;
            _musicOff.color = _color2;
        }
        else
        {
            Color _color1 = _musicOn.color;
            _color1.a = 0.3f;
            _musicOn.color = _color1;

            Color _color2 = _musicOn.color;
            _color2.a = 1.0f;
            _musicOff.color = _color2;
        }
    }
}
