using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != nextSceneName)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                if(SaveSystem.Info.name == "Boss6")
                {
                    SaveSystem.SaveGame();
                    PlayerPrefs.SetString("Scene", "Ending");
                    SceneManager.LoadScene("LoadScreen");
                    return;
                }
                if (!nextSceneName.Contains("Boss"))
                {
                    SaveSystem.Info.name = "Level";
                    SaveSystem.Info.Level++;
                }
                else
                {
                    SaveSystem.Info.name = "Boss";
                }
                SaveSystem.SaveGame();
                PlayerPrefs.SetString("Scene", nextSceneName);
                SceneManager.LoadScene("LoadScreen");
            }
        }
    }
}
