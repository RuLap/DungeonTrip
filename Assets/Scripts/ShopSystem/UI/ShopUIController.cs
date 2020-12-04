using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    private Shop shop;

    private int index = 0;

    //панели с товарами
    [SerializeField]
    public GameObject Swords;
    [SerializeField]
    public GameObject Armor;
    [SerializeField]
    public GameObject Potions;

    //кнопка покупки
    [SerializeField]
    public Button BuyButton;

    //Ячейки магазина(18)
    private List<Image> cells;

    //Выбранная ячейка
    private GameObject selected;

    //Цвет для выделения выбранной ячейки
    private Color selectionColor = new Color(0.14f, 1, 0.1f, 0.62f);

    //описание предмета
    [SerializeField]
    private Text description;

    //стоимость товара
    [SerializeField]
    private Text price;
    private int priceProduct;

    //количество монет у игрока
    [SerializeField]
    private Text money;
    private int moneyPlayer;

    void Start()
    {
        //определили магазин
        shop = GameObject.FindObjectOfType<Shop>();
        
        //создали ячейки
        cells = new List<Image>();
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            if (image.CompareTag("ShopCell"))
            {
                cells.Add(image);
            }
        }
        Potions.SetActive(true);
        Armor.SetActive(false);
        Swords.SetActive(false);
        BuyButton.interactable = false;
        //отключили магазин
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Сбрасывает элементы UI к виду, где нет активных кнопок
    /// и выбранных предметов в магазине
    /// </summary>
    public void OnShopOpen()
    {
        UIReset();
        SetMoney();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Убирает фокус с выбранного предмета,
    /// очищает поле описания предмета
    /// делает неактивной кнопку покупки
    /// </summary>
    private void UIReset()
    {
        OffItemsFocus();
        description.text = string.Empty;
        price.text = string.Empty;
        BuyButton.interactable = false;
    }

    /// <summary>
    /// Закрывает магазин
    /// </summary>
    public void OnShopClose()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        shop.ShopIsClosed();
    }

    /// <summary>
    /// Изменить видимую панель на одну вправо
    /// </summary>
    private void OnCickRight()
    {
        switch (index)
        {
            case 0:
                Potions.SetActive(false);
                index++;
                Armor.SetActive(true);
                break;
            case 1:
                Armor.SetActive(false);
                index++;
                Swords.SetActive(true);
                break;
            case 2:
                Swords.SetActive(false);
                index = 0;
                Potions.SetActive(true);
                break;
        }
        UIReset();
    }
    /// <summary>
    /// Изменить видимую панель на одну влево
    /// </summary>
    private void OnCickLeft()
    {
        switch (index)
        {
            case 0:
                Potions.SetActive(false);
                index = 2;
                Swords.SetActive(true);
                break;
            case 1:
                Armor.SetActive(false);
                index--;
                Potions.SetActive(true);
                break;
            case 2:
                Swords.SetActive(false);
                index--;
                Armor.SetActive(true);
                break;
        }
        UIReset();
    }
    /// <summary>
    /// Открыть панель с броней
    /// </summary>
    private void OnClickArmor()
    {
        Potions.SetActive(false);
        Swords.SetActive(false);
        Armor.SetActive(true);
        index = 1;
        UIReset();
    }
    /// <summary>
    /// Открыть панель с оружием
    /// </summary>
    private void OnClickSwords()
    {
        Potions.SetActive(false);
        Armor.SetActive(false);
        Swords.SetActive(true);
        index = 2;
        UIReset();
    }

    /// <summary>
    /// Открыть панель с зельями
    /// </summary>
    private void OnClickPotions()
    {
        Armor.SetActive(false);
        Swords.SetActive(false);
        Potions.SetActive(true);
        index = 0;
        UIReset();
    }

    /// <summary>
    /// Перекрашивает выбранную ячейку
    /// </summary>
    /// <param name="obj">Выбранная ячейка</param>
    private void OnSelect(GameObject obj)
    {
        UIReset();
        OnItemFocus(obj);
        ButtonClicked(obj);
        IsPriceMoreMoney();
    }

    /// <summary>
    /// Выделяет выбранную ячейку в магазине
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
    /// Меняет выбраную ячейку
    /// и вставляет описание предмета
    /// </summary>
    /// <param name="obj">Выбранная ячейка</param>
    private void ButtonClicked(GameObject obj)
    {
        selected = obj;
        var i = GetSelectionIndex();
        string color = "<color=\"#ff5500\">";
        priceProduct = shop.Items[i].price; 
        price.text = shop.Items[i].price.ToString();
        description.text = $"{color}{shop.Items[i].Title}</color>\n{shop.Items[i].Description}\n";
        if(index == 1)
        {
            description.text += $"{color}Уровень:</color> {(shop.Items[i] as ArmorItem).level}\n";
            description.text += $"{color}Защита:</color> {(shop.Items[i] as ArmorItem).protection}\n";
        }
        else if(index == 2)
        {
            description.text += $"{color}Уровень:</color> {(shop.Items[i] as WeaponItem).level}\n";
            description.text += $"{color}Урон:</color> {(shop.Items[i] as WeaponItem).damage}\n";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Индекс выделенного предмета в магазине</returns>
    private int GetSelectionIndex()
    {
        return cells.IndexOf(selected.GetComponent<Image>());
    }
    /// <summary>
    /// Покупка товара
    /// </summary>
    private void ToBuy()
    {
        var i = GetSelectionIndex();
        shop.BuyProduct(shop.Items[i]);
        SetMoney();
        IsPriceMoreMoney();
    }

    /// <summary>
    /// Установить/обновить количество денег 
    /// </summary>
    private void SetMoney()
    {
        moneyPlayer = GameObject.FindObjectOfType<Player>().PlayerStats.money;
        money.text = moneyPlayer.ToString();
    }

    /// <summary>
    /// Проверка, что денег у игрока не меньше стоимости товара
    /// </summary>
    private void IsPriceMoreMoney()
    {
        if(moneyPlayer>=priceProduct)
            BuyButton.interactable = true;
        else BuyButton.interactable = false;
    }
}