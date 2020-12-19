using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    public string nextSceneName;

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
                SaveSystem.Info.name = nextSceneName.Remove(nextSceneName.Length - 1);
                SaveSystem.Info.Level = int.Parse(nextSceneName.Substring(nextSceneName.Length - 1, 1));
                SaveSystem.SaveGame();
                PlayerPrefs.SetString("Scene", nextSceneName);
                SceneManager.LoadScene("LoadScreen");
            }
        }
    }
}
