using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NpcInfo
{
    public string name;
    public string message;

    public static NpcInfo CreateFromJSON(string json)
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/" + json + ".json";
        var jsonString = File.ReadAllText(jsonPath);
        return JsonUtility.FromJson<NpcInfo>(jsonString);
    }
}
