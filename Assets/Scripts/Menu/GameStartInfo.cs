using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

public class GameStartInfo
{
    public string name;
    public int Level;
    public static GameStartInfo LoadFromJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/GSI.dt";
        var jsonString = File.ReadAllText(jsonPath);
        var encoded = Coder.EncodeDecrypt(jsonString);
        return JsonUtility.FromJson<GameStartInfo>(encoded);
    }

    public void SaveToJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/GSI.dt";
        var jsonString = JsonUtility.ToJson(this);
        var coded = Coder.EncodeDecrypt(jsonString);
        File.WriteAllText(jsonPath, coded);
    }
}
