using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>
/// Класс отвечает за взаимодействие с магазином
/// </summary>
public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public GameObject shop;
    private bool isShopOpened = false;

    private DataBase db;
    private GameObject dbHolder;

    const int size = 18;

    [SerializeField]
    protected List<Item> items = new List<Item>(size);
    public List<Item> Items { get { return items; } }

    void Start()
    {
        dbHolder = Camera.main.gameObject;
        db = dbHolder.GetComponent<DataBase>();
        for(int i = 0; i < 6; i++)
        {
            items.Add(db.Potions[i]);
        }
        for(int i = 6; i < 12; i++)
        {
            items.Add(db.Armors[i-6]);
        }
        for(int i = 12; i < 18; i++)
        {
            items.Add(db.Swords[i-12]);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenCloseShop();
        }
    }

    /// <summary>
    /// Открывает магазин, если он закрыт
    /// и закрывает, если открыт
    /// </summary>
    private void OpenCloseShop()
    {
        if (isShopOpened)
        {
            Time.timeScale = 1f;
            CloseShop();
        }
        else
        {
            Time.timeScale = 0f;
            OpenShop();
        }
    }

    /// <summary>
    /// Открывает магазин
    /// </summary>
    private void OpenShop()
    {
        shop.GetComponent<ShopUIController>().OnShopOpen();
        isShopOpened = true;
    }

    /// <summary>
    /// Закрывает магазин
    /// </summary>
    public void CloseShop()
    {
        shop.GetComponent<ShopUIController>().OnShopClose();
        isShopOpened = false;
    }

    /// <summary>
    /// Метод вызывается при закрытии магазина нажатием UI кнопки крестика
    /// </summary>
    public void ShopIsClosed()
    {
        isShopOpened = false;
    }
    
    /// <summary>
    /// Метод вызывается при покупке предмета
    /// </summary>
    public void BuyProduct(Item item)
    {
        if(GameObject.FindObjectOfType<Inventory>().AddItem(item))
        {
            GameObject.FindObjectOfType<Player>().PlayerStats.money -= item.price;
        }
    }
}