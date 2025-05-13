using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource musicSource;
    public AudioSource buttonAudioSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        
    }

    void Start()
    {
        musicSource.mute = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        buttonAudioSource.mute = PlayerPrefs.GetInt("SoundMuted", 0) == 1;
    }

    public void ToggleMusic()
    {
        bool isMuted = !musicSource.mute;
        musicSource.mute = isMuted;
        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ToggleSound()
    {
        bool isMuted = !buttonAudioSource.mute;
        buttonAudioSource.mute = isMuted;
        PlayerPrefs.SetInt("SoundMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
