using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NpcInfo
{
    public string name;
    public string message;

    /// <summary>
    /// Парсит JSON в объект NpcInfo
    /// </summary>
    /// <param name="json">Имя файла JSON</param>
    /// <returns>Объект NpcInfo</returns>
    public static NpcInfo CreateFromJSON(string json)
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/" + json + ".json";
        var jsonString = File.ReadAllText(jsonPath);
        if (jsonString.Contains("[Имя героя]"))
            jsonString = jsonString.Replace("[Имя героя]", PlayerStats.LoadFromJson().name);
        return JsonUtility.FromJson<NpcInfo>(jsonString);
    }
}
