using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StoryData
{
    public string story;

    public static StoryData CreateFromJSON(string json)
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/" + json + ".dt";
        var jsonString = Coder.EncodeDecrypt(File.ReadAllText(jsonPath));
        return JsonUtility.FromJson<StoryData>(jsonString);
    }
}
