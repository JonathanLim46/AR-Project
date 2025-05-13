using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPediaManager : MonoBehaviour
{

    public GameObject panel;
    public Image panelImage;   

    void Start()
    {
        if (UIPediaStateManager.Instance != null)
        {
            UIPediaStateManager.Instance.SetPanelDetailImage(panelImage);
            if (UIPediaStateManager.Instance.openPediaOnReturn)
            {
                SetPanelImage(UIPediaStateManager.Instance.spriteToShow);
                UIPediaStateManager.Instance.openPediaOnReturn = false;
            }
        }
    } 

    public void SetPanelImage(Sprite sprite)
    {
        StartCoroutine(showPedia(sprite));
    }

    private System.Collections.IEnumerator showPedia(Sprite sprite)
    {
        if (MusicManager.instance != null && MusicManager.instance.buttonAudioSource != null)
        {
            AudioSource music = MusicManager.instance.buttonAudioSource;
            music.Play();
            yield return new WaitForSeconds(music.clip.length);
        }

        if (panelImage != null && panel != null)
        {
            panelImage.sprite = sprite;
            panel.SetActive(true);
        }
    }
}
