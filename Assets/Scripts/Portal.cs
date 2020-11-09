using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                string sceneName = SceneManager.GetActiveScene().name;
                if (sceneName.Contains("Boss"))
                {
                    SaveSystem.Info.Level++;
                }
                SaveSystem.SaveGame();
                PlayerPrefs.SetString("Scene", sceneName);
                SceneManager.LoadScene("LoadScreen");
            }
        }
    }
}
