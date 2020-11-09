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
    /// Загрузка игры
    /// </summary>
    public static void LoadGame()
    {
        if (info.Level == 0)
        {
            NewGame();
        }
        else
        {
            SceneManager.LoadScene($"Level{info.Level}");
        }
    }

    /// <summary>
    /// Запуск новой игры
    /// </summary>
    public static void NewGame()
    {
        SceneManager.LoadScene("Beginning");
    }
}
