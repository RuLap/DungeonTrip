using System;
using UnityEngine;
using System.IO;

public abstract class Item
{
    public int id;
    public string title;
    public string description;
    public int price;
    public Sprite sprite;

    public string Title { get { return title; } }
    public string Description { get { return description; } set { description = value; } }

    public Sprite Sprite { get { return sprite; } }

    public Item()
    {

    }
    public Item(int _id, Sprite _sprite, string _title, int _price)
    {
        id = _id;
        sprite = _sprite;
        title = _title;
        price = _price;
    }
}
