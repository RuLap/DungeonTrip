using System;
using UnityEngine;

public class Item
{
    protected int id;
    public string title;
    public string description;
    public Sprite sprite;

    public string Title { get { return title; } }
    public string Description { get { return description; } set { description = value; } }

    public Sprite Sprite { get { return sprite; } }

    public Item()
    {

    }
    public Item(int _id, Sprite _sprite, string _title)
    {
        id = _id;
        sprite = _sprite;
        title = _title;
    }
}
