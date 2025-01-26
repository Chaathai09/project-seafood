using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource ambienceSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] bgmTracks;
    public AudioClip[] ambienceClips;
    public AudioClip[] sfxClips;

    [Header("Volumes")]
    public float bgmVolume;
    public float ambienceVolume;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the audio manager persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start(){
        PlayBGM(0);
        PlayAmbience(0);
    }

    public void PlayBGM(int trackIndex)
    {
        if (bgmSource.isPlaying) bgmSource.Stop();
        bgmSource.clip = bgmTracks[trackIndex];
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayAmbience(int trackIndex)
    {
        if (ambienceSource.isPlaying) ambienceSource.Stop();
        ambienceSource.clip = ambienceClips[trackIndex];
        ambienceSource.loop = true;
        ambienceSource.Play();
    }

    public void PlaySFX(int clipIndex)
    {
        sfxSource.PlayOneShot(sfxClips[clipIndex]);
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}