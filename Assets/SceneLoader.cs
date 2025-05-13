using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    int sceneIndex;

    int[] backSceneMap = {0, 0, 0, 2};

    public AudioSource audioSource;

    public GameObject QuitGamePanel;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneIndex == 0 && Input.GetKeyDown(KeyCode.Escape)){
            QuitGamePanel.SetActive(true);
        } else if(Input.GetKeyDown(KeyCode.Escape)) {
            int targetIndex = backSceneMap[sceneIndex];
            SceneManager.LoadScene(targetIndex);
        }
    }

    public void loadScene(int index)
    {
        StartCoroutine(PlaySoundAndLoad(index));
    }

    private IEnumerator PlaySoundAndLoad(int indexBuild)
    {
        if (MusicManager.instance != null && MusicManager.instance.buttonAudioSource != null)
        {
            AudioSource music = MusicManager.instance.buttonAudioSource;
            music.Play();
            yield return new WaitForSeconds(music.clip.length);
        }

        SceneManager.LoadScene(indexBuild);
    }
}
