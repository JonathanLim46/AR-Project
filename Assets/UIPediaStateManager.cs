using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPediaStateManager : MonoBehaviour
{
    // STATE untuk kembali ke UI Pedia 
    
    public static UIPediaStateManager Instance;

    public bool openPediaOnReturn = false;
    public Sprite spriteToShow;

    private Image panelDetailImage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetPanelDetailImage(Image img)
    {
        panelDetailImage = img;
    }

    public void GoToSceneXFromPanel()
    {
        if (panelDetailImage != null)
        {
            openPediaOnReturn = true;
            spriteToShow = panelDetailImage.sprite;
        }

        SceneManager.LoadScene(3);
    }
}
