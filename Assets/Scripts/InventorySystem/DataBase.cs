using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataBase : MonoBehaviour
{
    private int[] swordsInt = { 3, 13, 33, 38, 53, 56, 73, 78, 93, 99 };
    [SerializeField]
    private List<Sprite> itemsSprites;
    public List<Sprite> ItemsSprites { get { return itemsSprites; } }

    public List<WeaponItem> Swords { get; } = new List<WeaponItem>();
    public List<ArmorItem> Armors { get; } = new List<ArmorItem>();

    private void Start()
    {
        LoadFromJson();
    }

    private void LoadFromJson()
    {
        for (int i = 0; i < swordsInt.Length; i++)
        {
            var jsonPath = Application.dataPath + "/StreamingAssets/Sword" + (i + 1).ToString() + ".json";
            var jsonString = File.ReadAllText(jsonPath);
            Swords.Add(JsonUtility.FromJson<WeaponItem>(jsonString));
            Swords[i].sprite = Resources.LoadAll<Sprite>("Swords")[swordsInt[i]];
        }

        for (int i = 0; i < 6; i++)
        {
            var jsonPath = Application.dataPath + "/StreamingAssets/Armor" + (i + 1).ToString() + ".json";
            var jsonString = File.ReadAllText(jsonPath);
            Armors.Add(JsonUtility.FromJson<ArmorItem>(jsonString));
            Armors[i].sprite = Resources.Load<Sprite>($"Armor/{(i + 1).ToString()}");
        }
    }
}
