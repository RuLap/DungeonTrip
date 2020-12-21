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
    public int money;

    public static PlayerStats LoadFromJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/PS.dt";
        var jsonString = Coder.EncodeDecrypt(File.ReadAllText(jsonPath));
        return JsonUtility.FromJson<PlayerStats>(jsonString);
    }

    public void SaveToJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/PS.dt";
        var jsonString = Coder.EncodeDecrypt(JsonUtility.ToJson(this));
        File.WriteAllText(jsonPath, jsonString);
    }
}
