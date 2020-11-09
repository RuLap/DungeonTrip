using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    private static GameStartInfo info = GameStartInfo.LoadFromJson();

    public SaveSystem()
    {
        
    }
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

    public void LoadGame()
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

    public void NewGame()
    {
        SceneManager.LoadScene("Beginning");
    }
}
