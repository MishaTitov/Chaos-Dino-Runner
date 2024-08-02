using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource effectsSource;
    [SerializeField] AudioSource jumpSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("VolumeMusicSource", 0.3f);
        effectsSource.volume = PlayerPrefs.GetFloat("VolumeEffectsSource", 0.5f);
    }

    #region Play
    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void PlayMusic(AudioClip audioClip, float timeToStart = 0f)
    {
        musicSource.clip = audioClip;
        musicSource.time = timeToStart;
        musicSource.Play();
    }
    public void PlayDefaultMusic()
    {
        musicSource.clip = audioClips[0];
        musicSource.Play();
        //musicSource.clip = null;
    }

    public void PlayEffect(AudioClip audioClip)
    {
        effectsSource.clip = audioClip;
        effectsSource.Play();
    }

    public void PlayJumpEffect()
    {
        jumpSource.Play();
    }
    #endregion

    #region Stop and Pause
    public void StopEffect()
    {
        effectsSource.Stop();
        //effectsSource.volume = 1f;
        effectsSource.clip = null;
    }

    public void PauseAll()
    {
        //jumpSource.Pause();
        effectsSource.Pause();
        musicSource.Pause();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }
    #endregion

    #region Sets

    public void SetMusicPitch(float value)
    {
        musicSource.pitch = value;
        jumpSource.pitch = value;
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
    }

    public void SetEffectsVolume(float value)
    {
        effectsSource.volume = value;
        jumpSource.volume = value;
    }

    public void SetEffectClip(AudioClip effectClip)
    {
        effectsSource.clip = effectClip;
    }
    #endregion

    #region Fade Effect
    public void StartFadeEffect(AudioClip audioEffect, float duration, float targetVolume = 0f)
    {
        StartCoroutine(FadeEffect(audioEffect, duration, targetVolume));
    }

    IEnumerator FadeEffect(AudioClip audioEffect, float duration, float targetVolume = 0f)
    {
        float currentTime = 0;
        float start = effectsSource.volume;
        effectsSource.clip = audioEffect;
        effectsSource.Play();
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            effectsSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        StopEffect();
        effectsSource.volume = start;
    }
    #endregion

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetEffectsVolume()
    {
        return effectsSource.volume;
    }

    public void GameOverMenu()
    {
        musicSource.Stop();
        effectsSource.Stop();
        //effectsSource.clip and Play()
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("VolumeMusicSource", musicSource.volume);
        PlayerPrefs.SetFloat("VolumeEffectsSource", effectsSource.volume);
    }
}
