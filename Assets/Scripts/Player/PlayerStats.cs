using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStats
{
    public string name;
    public float health;
    public float mana;
    public float maxHealth;
    public float maxMana;

    public static PlayerStats LoadFromJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/PlayerStats.json";
        var jsonString = File.ReadAllText(jsonPath);
        return JsonUtility.FromJson<PlayerStats>(jsonString);
    }

    public void SaveToJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/PlayerStats.json";
        var jsonString = JsonUtility.ToJson(this);
        File.WriteAllText(jsonPath, jsonString);
    }
}
