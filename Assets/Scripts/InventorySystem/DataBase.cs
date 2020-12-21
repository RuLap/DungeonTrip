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
    public List<Sprite> DropPotionsSprites { get; } = new List<Sprite>();

    public List<WeaponItem> Swords { get; } = new List<WeaponItem>();
    public List<ArmorItem> Armors { get; } = new List<ArmorItem>();
    public List<PotionItem> Potions { get; } = new List<PotionItem>();

    private void Awake()
    {
        InitPotions();
        LoadFromJson();
        for (int i = 0; i < 6; i++)
        {
            DropPotionsSprites.Add(Resources.Load<Sprite>($"DropPotions/{(i + 1).ToString()}"));
        }
    }

    private void LoadFromJson()
    {
        for (int i = 0; i < swordsInt.Length; i++)
        {
            var jsonPath = Application.dataPath + "/StreamingAssets/S" + (i + 1).ToString() + ".dt";
            var jsonString = Coder.EncodeDecrypt(File.ReadAllText(jsonPath));
            Swords.Add(JsonUtility.FromJson<WeaponItem>(jsonString));
            Swords[i].sprite = Resources.LoadAll<Sprite>("Swords")[swordsInt[i]];
        }

        for (int i = 0; i < 6; i++)
        {
            var jsonPath = Application.dataPath + "/StreamingAssets/A" + (i + 1).ToString() + ".dt";
            var jsonString = Coder.EncodeDecrypt(File.ReadAllText(jsonPath));
            Armors.Add(JsonUtility.FromJson<ArmorItem>(jsonString));
            Armors[i].sprite = Resources.Load<Sprite>($"Armor/{(i + 1).ToString()}");
        }
    }

    /// <summary>
    /// Инициализирует зелья
    /// </summary>
    private void InitPotions()
    {
        Potions.Add(new HealPotion(0, ItemsSprites[0], "Большое зельче лечения\n", 90, 100, 0));
        Potions[0].Description = $"Восстанавливает {(Potions[0] as PotionItem).RefillValue} очков здоровья";
        Potions.Add(new HealPotion(1, ItemsSprites[1], "Среднее зелье лечения\n", 45, 50, 10));
        Potions[1].Description = $"Восстанавливает {(Potions[1] as PotionItem).RefillValue} очков здоровья";
        Potions.Add(new HealPotion(2, ItemsSprites[2], "Малое зелье лечения\n", 15, 25, 99));
        Potions[2].Description = $"Восстанавливает {(Potions[2] as PotionItem).RefillValue} очков здоровья";
        Potions.Add(new ManaPotion(3, ItemsSprites[3], "Большое зелье маны\n", 90, 100, 12));
        Potions[3].Description = $"Восстанавливает {(Potions[3] as PotionItem).RefillValue} очков маны";
        Potions.Add(new ManaPotion(4, ItemsSprites[4], "Среднее зелье маны\n", 45, 50, 5));
        Potions[4].Description = $"Восстанавливает {(Potions[4] as PotionItem).RefillValue} очков маны";
        Potions.Add(new ManaPotion(5, ItemsSprites[5], "Малое зелье маны\n", 15, 25, 45));
        Potions[5].Description = $"Восстанавливает {(Potions[5] as PotionItem).RefillValue} очков маны";
    }
}
