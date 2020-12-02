using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerXP
{
    public int currentLevel;
    public int maxPoints;
    public int points;

    public int CurrentLevel { get { return currentLevel; } }

    public static PlayerXP LoadFromJson(string json)
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/" + json + ".json";
        var jsonString = File.ReadAllText(jsonPath);
        return JsonUtility.FromJson<PlayerXP>(jsonString);
    }

    public void SaveToJson()
    {
        var jsonPath = Application.dataPath + "/StreamingAssets/PlayerXP.json";
        var jsonString = JsonUtility.ToJson(this);
        File.WriteAllText(jsonPath, jsonString);
    }

    /// <summary>
    /// Добавить очки опыта
    /// </summary>
    /// <param name="value">Количество</param>
    /// <returns>Переход на новый ровень</returns>
    public bool AddPoints(int value)
    {
        points += value;
        if(points >= maxPoints)
        {
            LevelUp();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Повышение уровня
    /// </summary>
    private void LevelUp()
    {
        int overflow = maxPoints - points;
        points = points - maxPoints;
        currentLevel++;
        maxPoints = currentLevel * 200;
    }

    /// <summary>
    /// Считает заполненность шкалы
    /// </summary>
    /// <returns></returns>
    public float GetFillAmount()
    {
        if (points == 0) return 0;
        return (float)points / maxPoints;
    }
}
