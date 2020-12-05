using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;

public class MenuWork : MonoBehaviour
{
    public int quality = 2; //Качество
    public bool isFullScreen = true; //Полноэкранный режим
    public AudioMixer AudioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    public Dropdown qualityDropdown;//Список с уровнями качества

    public bool isOpened = false; //Открыто ли внутриигровое меню

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
    //методы изменения настроек
    public void ChangeVolume(float val)
    {
        //volume = val;
        AudioMixer.SetFloat("MasterVolume", val);
    }
    public void ChangeResolution()
    {
        //currResolutionIndex = index;
        if (resolutionDropdown.value == 0)
        {
            Screen.SetResolution(1366, 768, true);
        }
        if (resolutionDropdown.value == 1)
        {
            Screen.SetResolution(1080, 720, true);
        }
        if (resolutionDropdown.value == 2)
        {
            Screen.SetResolution(1024, 768, true);
        }
        if (resolutionDropdown.value == 3)
        {
            Screen.SetResolution(1440, 900, true);
        }
    }
    public void ChangeFullScreenMode()
    {
        //isFullScreen = val;
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        isFullScreen = false;
    }
    public void ChangeQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
        //quality = index;
    }
    //методы внутриигрового меню

    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;  //Включение или отключение Canvas. Ещё тут можно использовать метод SetActive()
    }

    void Update()
    {
        
    }

    public static void EnterMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ContinueGame()
    {

    }
}
