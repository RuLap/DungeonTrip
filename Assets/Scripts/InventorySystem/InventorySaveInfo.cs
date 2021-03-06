﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventorySaveInfo
{
    public int[] id;
    public int[] counts;

    public static InventorySaveInfo LoadFromJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/ISI.dt";
        var jsonString = Coder.EncodeDecrypt(File.ReadAllText(jsonPath));
        return JsonUtility.FromJson<InventorySaveInfo>(jsonString);
    }

    public void SaveToJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/ISI.dt";
        var jsonString = Coder.EncodeDecrypt(JsonUtility.ToJson(this));
        File.WriteAllText(jsonPath, jsonString);
    }

    public void Refresh(List<Item> items)
    {
        for(int i = 0; i < 6; i++)
        {
            counts[i] = (items[i] as PotionItem).Count;
        }
        for(int i = 6; i < 14; i++)
        {
            id[i] = items[i] is null ? -1 : items[i].id;
        }
    }
}
