using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Game.Manager;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance { get; private set; }
    public List<BGMset> bgmSets;

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private float _volume = 1;

    void Awake()
    {
        CheckInstance();

        var audioSource = GetComponent<AudioSource>();
        SceneState.sceneName
            .Subscribe(x =>
            {
                foreach (var bgmSet in bgmSets)
                {
                    audioSource1 = transform.GetChild(0).GetComponent<AudioSource>();
                    audioSource2 = transform.GetChild(1).GetComponent<AudioSource>();
                    if (x == bgmSet.scene)
                    {
                        PlayBGM(bgmSet.bgm);
                    }
                }
            }).AddTo(this);

    }

    private void CheckInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private AudioSource SelectAudioSource()
    {
        if (audioSource1.isPlaying)
        {
            return audioSource2;
        }
        else
        {
            return audioSource1;
        }
    }

    private void PlayBGM(AudioClip audioClip)
    {
        var audioSource = SelectAudioSource();
        var otherAudioSource = audioSource == audioSource1 ? audioSource2 : audioSource1;
        audioSource.clip = audioClip;
        StartCoroutine(FadeIn(audioSource, 1f));
        StartCoroutine(FadeOut(otherAudioSource, 1f));
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(_volume, 0, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
        yield break;
    }
    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        float currentTime = 0;

        audioSource.Play();
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, _volume, currentTime / duration);
            yield return null;
        }
        audioSource.volume = 1;
        yield break;
    }
}

[System.Serializable]
public class BGMset
{
    public string scene;
    public AudioClip bgm;
}
