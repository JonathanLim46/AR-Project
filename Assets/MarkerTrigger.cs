using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MarkerTrigger : MonoBehaviour
{
    public QuizManager quizManager;
    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnStatusChanged;
        }
    }

    private void OnDestroy()
    {
        if (observer)
        {
            observer.OnTargetStatusChanged -= OnStatusChanged;
        }
    }

    private void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Marker terlihat
        if ((status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
            && quizManager.quizPanel.activeSelf == false
            && quizManager.isPanelStatusClose) // <-- tambah ini
        {
            quizManager.ShowRandomQuiz();
        }

        if (status.Status == Status.NO_POSE || status.Status == Status.LIMITED)
        {
            quizManager.HideQuiz();
        }
    }
}
