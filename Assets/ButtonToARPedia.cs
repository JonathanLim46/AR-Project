using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToARPedia : MonoBehaviour
{
    public Button buttonToAR;
    
    void Start()
    {
        buttonToAR.onClick.AddListener(() =>
        {
            UIPediaStateManager.Instance.GoToSceneXFromPanel();
        });
    }
}
