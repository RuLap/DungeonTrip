using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWork : MonoBehaviour
{
    private SaveSystem saveSystem;
    private void Start()
    {
        saveSystem = new SaveSystem();
    }
    public void ContinuePressed()
    {
        saveSystem.LoadGame();
        //SceneManager.LoadScene("TestScene4");
    }

    public void NewGamePressed()
    {
        saveSystem.NewGame();
        //SceneManager.LoadScene("TestScene5");
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
