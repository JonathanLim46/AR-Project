using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    public string namaScene;

    public void gotoScene(){
        SceneManager.LoadScene(namaScene);
    }
}
