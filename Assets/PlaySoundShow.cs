using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundShow : MonoBehaviour
{

    // UNTUK UI PANEL SUARA BUTTON

    public void playSound(GameObject targetPanel)
    {
        StartCoroutine(openPanel(targetPanel));
    }

    public void playSoundHidePanel(GameObject targetPanel)
    {
        StartCoroutine(hidePanel(targetPanel));
    }

    private System.Collections.IEnumerator openPanel(GameObject targetPanel)
    {
        if (MusicManager.instance != null && MusicManager.instance.buttonAudioSource != null)
        {
            AudioSource music = MusicManager.instance.buttonAudioSource;
            music.Play();
            yield return new WaitForSeconds(music.clip.length);
        }

        if (targetPanel != null)
        {
            targetPanel.SetActive(true);
        }
    }

    private System.Collections.IEnumerator hidePanel(GameObject targetPanel)
    {
        if (MusicManager.instance != null && MusicManager.instance.buttonAudioSource != null)
        {
            AudioSource music = MusicManager.instance.buttonAudioSource;
            music.Play();
            yield return new WaitForSeconds(music.clip.length);
        }

        if (targetPanel != null)
        {
            targetPanel.SetActive(false);
        }
    }
}
