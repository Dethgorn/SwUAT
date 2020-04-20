using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }

    public void Begin()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(1);
    }

    public void LoadScene(int a)
    {

        SceneManager.LoadScene(a);
    }


}