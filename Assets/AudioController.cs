using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public GameObject buttonToggleMusicOn;
    public GameObject buttonToggleMusicOff;
    public GameObject buttonToggleSoundOn;
    public GameObject buttonToggleSoundOff;

    void Start()
    {
        UpdateUI();

        buttonToggleMusicOn.GetComponent<Button>().onClick.AddListener(() =>
        {
            MusicManager.instance.ToggleMusic();
            UpdateUI();
        });

        buttonToggleMusicOff.GetComponent<Button>().onClick.AddListener(() =>
        {
            MusicManager.instance.ToggleMusic();
            UpdateUI();
        });

        buttonToggleSoundOn.GetComponent<Button>().onClick.AddListener(() =>
        {
            MusicManager.instance.ToggleSound();
            UpdateUI();
        });

        buttonToggleSoundOff.GetComponent<Button>().onClick.AddListener(() =>
        {
            MusicManager.instance.ToggleSound();
            UpdateUI();
        });
    }

    void UpdateUI()
    {
        bool isMusicMuted = MusicManager.instance.musicSource.mute;
        bool isSoundMuted = MusicManager.instance.buttonAudioSource.mute;

        buttonToggleMusicOn.SetActive(!isMusicMuted);
        buttonToggleMusicOff.SetActive(isMusicMuted);

        buttonToggleSoundOn.SetActive(!isSoundMuted);
        buttonToggleSoundOff.SetActive(isSoundMuted);
    }
}
