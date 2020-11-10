using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Shop shop;
    private Inventory inv;

    private int Money = 100;
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

    //количество монет у игрока
    [SerializeField]
    private Text money;

    int productPrice = 40;

    void Start()
    {
        //определили магазин
        shop = player.GetComponent<Shop>();

        inv = player.GetComponent<Inventory>();

        //создали ячейки
        cells = new List<Image>();
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            if (image.CompareTag("ShopCell"))
            {
                cells.Add(image);
            }
        }
        money.text = Money.ToString();
        Potions.SetActive(true);
        Armor.SetActive(false);
        Swords.SetActive(false);
        BuyButton.interactable = false;
        Time.timeScale = 0f;
    }
    /// <summary>
    /// Сбрасывает элементы UI к виду, где нет активных кнопок
    /// и выбранных предметов в магазине
    /// </summary>
    public void OnShopOpen()
    {
        UIReset();
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
    public void OnCickRight()
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
    public void OnCickLeft()
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
    public void OnClickArmor()
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
    public void OnClickSwords()
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
    public void OnClickPotions()
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
    public void OnSelect(GameObject obj)
    {
        UIReset();
        OnItemFocus(obj);
        ButtonClicked(obj);
        if(Money>=productPrice)
            BuyButton.interactable = true;
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
        switch(index){
            case 0: 
                productPrice = shop.db.Potions[i].price; 
                price.text = shop.db.Potions[i].price.ToString();
                description.text = $"{color}{shop.db.Potions[i].Title}</color>\n{shop.db.Potions[i].Description}";
                break;
            case 1:
                productPrice = shop.db.Armors[i-6].price;
                price.text = shop.db.Armors[i-6].price.ToString();
                description.text = $"{color}{shop.db.Armors[i-6].Title}</color>\n{shop.db.Armors[i-6].Description}\n";
                description.text += $"{color}Уровень:</color> {shop.db.Armors[i-6].level}\n";
                description.text += $"{color}Защита:</color> {shop.db.Armors[i-6].protection}\n";
                break;
            case 2:
                productPrice = shop.db.Swords[i-12].price;
                price.text = shop.db.Swords[i-12].price.ToString();
                description.text = $"{color}{shop.db.Swords[i-12].Title}</color>\n{shop.db.Swords[i-12].Description}\n";
                description.text += $"{color}Уровень:</color> {shop.db.Swords[i-12].level}\n";
                description.text += $"{color}Урон:</color> {shop.db.Swords[i-12].damage}\n";
                break;
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
    public void ToBuy()
    {
        var i = GetSelectionIndex();
        switch(index)
        {
            case 0:
                if(inv.AddItem(shop.db.Potions[i])){
                    Money -= productPrice;
                    money.text = Money.ToString();
                }
                break;
            case 1:
                if(inv.AddItem(shop.db.Armors[i-6])){
                    Money -= productPrice;
                    money.text = Money.ToString();
                }
                break;
            case 2:
                if(inv.AddItem(shop.db.Swords[i-12])){
                    Money -= productPrice;
                    money.text = Money.ToString();
                }
                break;
        }
    }
}