using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameStartInfo
{
    public int Level;
    public static GameStartInfo LoadFromJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/GameStartInfo.json";
        var jsonString = File.ReadAllText(jsonPath);
        return JsonUtility.FromJson<GameStartInfo>(jsonString);
    }

    public void SaveToJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/GameStartInfo.json";
        var jsonString = JsonUtility.ToJson(this);
        File.WriteAllText(jsonPath, jsonString);
    }
}
