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
    public GameObject shop;
    private bool isShopOpened = true;

    public DataBase db;
    [SerializeField]
    private GameObject dbHolder;

    void Start()
    {
        db = dbHolder.GetComponent<DataBase>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
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
}