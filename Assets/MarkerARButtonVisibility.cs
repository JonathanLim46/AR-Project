using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MarkerARButtonVisibility : MonoBehaviour
{
    public GameObject buttonIdle;
    public GameObject buttonAnim;

    private void Start()
    {
        buttonIdle.SetActive(false);
        buttonAnim.SetActive(false);

        var observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isVisible = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        buttonIdle.SetActive(isVisible);
        buttonAnim.SetActive(isVisible);
    }
}
