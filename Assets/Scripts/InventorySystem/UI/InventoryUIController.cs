﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Inventory inventory;

    //Выбранная ячейка
    private GameObject selected;
    
    //Цвет для выделения выбранной ячейки
    private Color selectionColor = new Color(0.14f, 1, 0.1f, 0.62f);

    //Ячейки инвентаря(14)
    private List<Image> cells;

    //Открытое свойство для доступа из других классов
    public List<Image> Cells { get { return cells; } }

    //Кнопки использования/выбрасывания/надевания/снятия в инвентаре
    [SerializeField]
    private Button useButton;
    [SerializeField]
    private Button dropButton;
    [SerializeField]
    private Button equipButton;
    [SerializeField]
    private Button takeOffButton;

    //описание предмета
    [SerializeField]
    private Text description;

    void Start()
    {
        //определили инвентарь
        inventory = player.GetComponent<Inventory>();
        //создали ячейки
        cells = new List<Image>();
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            if (image.CompareTag("InventoryCell"))
            {
                cells.Add(image);
            }
        }
        //отключили пока инвентаря, так как он открывается по кнопке
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Сбрасывает элементы UI к виду, где нет активных кнопок
    /// и выбранных предметов в инвентаре
    /// </summary>
    public void OnInventoryOpen()
    {
        UIReset();
        OnInventoryChanged();

        //Перезаписываем количество зелий, на случай если оно изменилось
        for (int i = 0; i < 6; i++)
        {
            var count = cells[i].GetComponentInChildren<Image>(true).GetComponentInChildren<Text>(true);
            count.text = (inventory.Items[i] as PotionItem).Count.ToString();
        }
    }

    /// <summary>
    /// Делает кнопку недоступной для нажатия
    /// </summary>
    /// <param name="button">Кнопка</param>
    private void SetButtonUnactive(Button button)
    {
        button.interactable = false;
    }

    /// <summary>
    /// Активирует нужные кнопки 
    /// и перекрашивает ячейку выбарнного зелья
    /// </summary>
    /// <param name="obj">Выбранная ячейка</param>
    public void OnPotionSelect(GameObject obj)
    {
        UIReset();
        SetButtonActive(useButton);
        OnItemFocus(obj);
        ButtonClicked(obj);
    }

    /// <summary>
    /// Активирует нужные кнопки
    /// и перекрашивает ячейку выбранной экипировки
    /// </summary>
    /// <param name="obj">Выбранная ячейка</param>
    public void OnEquipmentSelect(GameObject obj)
    {
        UIReset();
        SetButtonActive(dropButton);
        SetButtonActive(equipButton);
        OnItemFocus(obj);
        ButtonClicked(obj);
    }

    /// <summary>
    /// Активирует нужные кнопки
    /// и перекрашивает ячейку выбранной экипировки
    /// </summary>
    /// <param name="obj">Выбранная ячейка</param>
    public void OnEquipedSelect(GameObject obj)
    {
        UIReset();
        SetButtonActive(takeOffButton);
        SetButtonActive(dropButton);
        OnItemFocus(obj);
        ButtonClicked(obj);
    }

    /// <summary>
    /// Меняет выбраную ячейку
    /// и вставляет описание предмета
    /// </summary>
    /// <param name="obj">Выбранная ячейка</param>
    private void ButtonClicked(GameObject obj)
    {
        selected = obj;
        var index = GetSelectionIndex();
        description.text = inventory.Items[index].Title + inventory.Items[index].Description;
    }

    /// <summary>
    /// Убирает фокус с выбранного предмета,
    /// делает кнопки ндоступными для нажатия,
    /// очищает поле описания предмета
    /// </summary>
    private void UIReset()
    {
        OffItemsFocus();
        SetButtonUnactive(useButton);
        SetButtonUnactive(dropButton);
        SetButtonUnactive(equipButton);
        SetButtonUnactive(takeOffButton);
        description.text = string.Empty;
    }

    /// <summary>
    /// Делает кнопку доступной для нажатия
    /// </summary>
    /// <param name="button">Кнопка</param>
    private void SetButtonActive(Button button)
    {
        button.interactable = true;
    }

    /// <summary>
    /// Выделяет выбранную ячйку инвентаря
    /// </summary>
    /// <param name="obj">Выбранная ячейка</param>
    private void OnItemFocus(GameObject obj)
    {
        obj.GetComponent<Image>().color = selectionColor;
    }

    /// <summary>
    /// Убирает выделение с выбранной ячейки
    /// </summary>
    private void OffItemsFocus()
    {
        //проходимся по всем ячейкам и убираем цвет выделения
        foreach (var image in cells)        
        {
            image.color = new Color(1, 1, 1, 1);
        }
    }

    /// <summary>
    /// Удаление экипировки
    /// </summary>
    public void OnItemRemove()
    {
        //находим индекс выбраного предмета
        int index = GetSelectionIndex();
        //вызываем метод модели
        inventory.RemoveItem(index);
        //изменяем отображение
        OnInventoryChanged();
        UIReset();
    }

    /// <summary>
    /// Надеть предмет из инвентаря
    /// </summary>
    public void OnEquip()
    {
        int index = GetSelectionIndex();
        inventory.ReplaceToEquipment(index);
        OnInventoryChanged();
        UIReset();
    }

    /// <summary>
    /// Перерисовка инвентаря, если что то было удалено/изменено/перемещено
    /// </summary>
    private void OnInventoryChanged()
    {
        for(int i = 0; i < cells.Count; i++)
        {
            Button btn = cells[i].GetComponentInChildren<Button>(true);

            Image btnImage = btn.GetComponent<Image>();

            if(inventory.Items[i] is null)
            {
                btn.gameObject.SetActive(false);
            }
            else
            {
                btnImage.sprite = inventory.Items[i].Sprite;
                btn.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// При изменении числа зелий(использовано)
    /// меняет отображаемый счетчик
    /// </summary>
    private void OnPotionCountChanged()
    {
        int index = GetSelectionIndex();
        var count = cells[index].GetComponentInChildren<Image>().GetComponentInChildren<Text>();
        count.text = (inventory.Items[index] as PotionItem).Count.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Индекс выделенного предета в инвентаре</returns>
    private int GetSelectionIndex()
    {
        return cells.IndexOf(selected.GetComponent<Image>());
    }

    /// <summary>
    /// Снимает вещь и перемещает ее в инвентарь, 
    /// если есть свободные ячейки
    /// </summary>
    public void OnUnequip()
    {
        int index = GetSelectionIndex();
        inventory.ReplaceFromEquipment(index);
        OnInventoryChanged();
        UIReset();
    }

    /// <summary>
    /// Использование зелья
    /// </summary>
    public void OnPotionUse()
    {
        int index = GetSelectionIndex();
        inventory.UsePotion(index);
        OnInventoryChanged();
        OnPotionCountChanged();
    }
}