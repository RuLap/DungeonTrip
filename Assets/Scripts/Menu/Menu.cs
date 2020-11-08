using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ContinuePressed()
    {
        SceneManager.LoadScene("TestScene4");
    }

    public void NewGamePressed()
    {
        SceneManager.LoadScene("TestScene5");
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
