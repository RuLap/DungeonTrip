using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWork : MonoBehaviour
{
    private void Start()
    {
    }
    public void ContinuePressed()
    {
        PlayerPrefs.SetString("PlayerJson", "PlayerXP");
        SaveSystem.LoadGame();
        //SceneManager.LoadScene("TestScene4");
    }

    public void NewGamePressed()
    {
        PlayerPrefs.SetString("PlayerJson", "NewPlayerXP");
        SaveSystem.NewGame();
        //SceneManager.LoadScene("TestScene5");
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
