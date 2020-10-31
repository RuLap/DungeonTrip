using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IntroData
{
    public string story;

    public static IntroData CreateFromJSON(string json)
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/" + json + ".json";
        var jsonString = File.ReadAllText(jsonPath);
        return JsonUtility.FromJson<IntroData>(jsonString);
    }
}
