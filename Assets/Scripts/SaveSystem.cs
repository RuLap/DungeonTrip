using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    private static GameStartInfo info = GameStartInfo.LoadFromJson();
    public static GameStartInfo Info { get { return info; } }

    /// <summary>
    /// Сохранение игры
    /// </summary>
    public static void SaveGame()
    {
        var player = GameObject.FindObjectOfType<Player>();
        player.PlayerStats.SaveToJson();
        player.PlayerXP.SaveToJson();
        var inventory = GameObject.FindObjectOfType<Inventory>();
        inventory.InventorySaveInfo.Refresh(inventory.Items);
        inventory.InventorySaveInfo.SaveToJson();
        info.SaveToJson(); 
    }

    /// <summary>
    /// Загрузка игры(если сохранения нет, то начало новой игры)
    /// </summary>
    public static void LoadGame()
    {
        if (info.Level == 0)
        {
            NewGame();
        }
        else
        {
            PlayerPrefs.SetString("Scene", info.name + info.Level);
            SceneManager.LoadScene($"LoadScreen");
        }
    }

    /// <summary>
    /// Новая игра
    /// </summary>
    public static void NewGame()
    {
        info.Level = 1;
        info.name = "Level";
        info.SaveToJson();
        SceneManager.LoadScene("Beginning");
    }
}
