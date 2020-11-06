using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>
/// Класс отвечает за взаимодействие с инвентарем
/// </summary>
public class Inventory : MonoBehaviour
{
    const int size = 14;

    [SerializeField]
    protected List<Item> items = new List<Item>(size);
    public List<Item> Items { get { return items; } }

    private int potionsCount = 6;
    private int equipsCount = 6;
    private int equipedCount = 2;

    public GameObject inventory;
    private bool isInventoryOpened = false;

    private bool isStarted = false;

    private DataBase db;
    [SerializeField]
    private GameObject dbHolder;

    void Start()
    {
        dbHolder = Camera.main.gameObject;
        db = dbHolder.GetComponent<DataBase>();
        InitPotions();
        InitEquipments();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseInventory();
        }
    }

    /// <summary>
    /// Открывает инвентарь, если он закрыт
    /// и закрывает, если открыт
    /// </summary>
    private void OpenCloseInventory()
    {
        if (isInventoryOpened)
        {
            Time.timeScale = 1f;
            CloseInventory();
        }
        else
        {
            Time.timeScale = 0f;
            OpenInventory();
        }
    }

    /// <summary>
    /// Открывает инвентарь
    /// </summary>
    private void OpenInventory()
    {
        inventory.GetComponent<InventoryUIController>().OnInventoryOpen();
        isInventoryOpened = true;
    }

    /// <summary>
    /// Закрывает инвентарь
    /// </summary>
    public void CloseInventory()
    {
        inventory.GetComponent<InventoryUIController>().OnInventoryClose();
        isInventoryOpened = false;
    }

    /// <summary>
    /// Метод вызывается при закрытии инвентаря нажатием UI кнопки крестика
    /// </summary>
    public void InventoryIsClosed()
    {
        isInventoryOpened = false;
    }

    /// <summary>
    /// Инициализирует все виды зелий
    /// </summary>
    private void InitPotions()
    {
        /*items.Add(new HealPotion(0, db.ItemsSprites[0], "Большое зельче лечения\n", 90, 0));
        items[0].Description = $"Восстанавливает {(items[0] as PotionItem).RefillValue} очков здоровья";
        items.Add(new HealPotion(1, db.ItemsSprites[1], "Среднее зелье лечения\n", 45, 10));
        items[1].Description = $"Восстанавливает {(items[1] as PotionItem).RefillValue} очков здоровья";
        items.Add(new HealPotion(2, db.ItemsSprites[2], "Малое зелье лечения\n", 15, 99));
        items[2].Description = $"Восстанавливает {(items[2] as PotionItem).RefillValue} очков здоровья";
        items.Add(new ManaPotion(3, db.ItemsSprites[3], "Большое зелье маны\n", 90, 12));
        items[3].Description = $"Восстанавливает {(items[3] as PotionItem).RefillValue} очков маны";
        items.Add(new ManaPotion(4, db.ItemsSprites[4], "Среднее зелье маны\n", 45, 5));
        items[4].Description = $"Восстанавливает {(items[4] as PotionItem).RefillValue} очков маны";
        items.Add(new ManaPotion(5, db.ItemsSprites[5], "Малое зелье маны\n", 15, 45));
        items[5].Description = $"Восстанавливает {(items[5] as PotionItem).RefillValue} очков маны";*/
        for(int i = 0; i < 6; i++)
        {
            items.Add(db.Potions[i]);
        }
    }

    /// <summary>
    /// Инициализирует примеры отображения экипировки
    /// </summary>
    private void InitEquipments()
    {
        items.Add(db.Armors[0]);
        items.Add(db.Armors[1]);
        items.Add(db.Armors[2]);
        items.Add(db.Armors[3]);
        items.Add(db.Swords[5]);
        items.Add(db.Swords[6]);
        items.Add(db.Swords[7]);
        items.Add(db.Armors[4]);
    }

    /// <summary>
    /// Добавляет предмет в инвентарь
    /// </summary>
    /// <param name="item">Предмет</param>
    public bool AddItem(Item item)
    {
        if (item is PotionItem)
        {
            for(int i = 0; i < 6; i++)
            {
                if((item as PotionItem).RefillType == (items[i] as PotionItem).RefillType)
                {
                    if((item as PotionItem).RefillValue == (items[i] as PotionItem).RefillValue)
                    {
                        if((items[i] as PotionItem).Count == 99)
                        {
                            return false;
                        }
                        (items[i] as PotionItem).AddToStack();
                        return true;
                    }
                } 
            }
            return false;
        }
        else
        {
            for(int i = 6; i < items.Count; i++)
            {
                if(items[i] is null)
                {
                    items[i] = item;
                    return true;
                }
            }
            Debug.Log("Инвентарь заполнен!");
        }
        return false;
    }

    /// <summary>
    /// Убирает предмет из инвентаря
    /// </summary>
    /// <param name="index">Индекс предмета в инвентаре</param>
    public void RemoveItem(int index)
    {
        items[index] = null;
    }

    /// <summary>
    /// Поместить предмет в экипировку
    /// </summary>
    /// <param name="index">Индекс предмета в инвентаре</param>
    public void ReplaceToEquipment(int index)
    {
        var item = items[index];

        if(item is WeaponItem)
        {
            if(items[size - 2] is null)
            {
                items[size - 2] = item;
                items[index] = null;
            }
            else
            {
                var temp = items[size - 2];
                items[size - 2] = item;
                items[items.IndexOf(item)] = temp;
            }
        }
        if (item is ArmorItem)
        {
            if (items[size - 1] is null)
            {
                items[size - 1] = item;
                items[index] = null;
            }
            else
            {
                var temp = items[size - 1];
                items[size - 1] = item;
                items[items.IndexOf(item)] = temp;
            }
        }
    }

    /// <summary>
    /// Убирает предмет из экипировки в инвентарь
    /// </summary>
    /// <param name="index">Индекс предмета в инвентаре</param>
    public void ReplaceFromEquipment(int index)
    {
        var item = items[index];
        int nonEmptyCount = 0;
        int emptyIndex = 0;
        for(int i = potionsCount; i < potionsCount + equipsCount; i++)
        {
            if(items[i] != null)
            {
                nonEmptyCount++;
            }
            else
            {
                emptyIndex = i;
            }
        }
        if (nonEmptyCount < equipsCount)
        {
            items[emptyIndex] = items[index];
            items[index] = null;
        }
    }

    /// <summary>
    /// Использует зелье
    /// </summary>
    /// <param name="index">Индекс выбранного зелья</param>
    public void UsePotion(int index)
    {
        var item = items[index] as PotionItem;
        item.Use();
    }

    /// <summary>
    /// Пуст ли слот меча
    /// </summary>
    /// <returns>Есть ли что то в слоте с надетым мечом</returns>
    public bool HasEmptyWeaponSlot()
    {
        return items[12] == null;
    }

    /// <summary>
    /// Пуст ли слот брони
    /// </summary>
    /// <returns>Есть ли что то в слоте с надетой броней</returns>
    public bool HasEmptyArmorSlot()
    {
        return items[13] == null;
    }
}
