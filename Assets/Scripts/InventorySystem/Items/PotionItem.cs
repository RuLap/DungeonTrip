﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Класс описывает зелья
/// </summary>
public class PotionItem : Item
{
    private int count;
    protected int maxCount;
    protected RefillType refillType;
    protected int refillValue;

    public int Count { get { return count; } }
    public int RefillValue { get { return refillValue; } }
    public RefillType RefillType { get; set; }

    public PotionItem(int _id, Sprite _sprite, string _title, int _refillValue, int _count) : base(_id, _sprite, _title)
    {
        maxCount = 99;
        count = _count;
        refillValue = _refillValue;
    }

    /// <summary>
    /// Помещает предметы в стак
    /// </summary>
    public void AddToStack()
    {
        if (count < maxCount)
        {
            count++;
        }
    }

    public void Use()
    {
        if (count > 0)
        {
            count--;
        }
    }
}

[System.Serializable]
public class HealPotion : PotionItem
{
    public HealPotion(int _id, Sprite _sprite, string _title, int _refillValue, int _count = 0) 
        : base(_id, _sprite, _title, _refillValue, _count)
    {
        refillType = RefillType.Health;
    }
}

[System.Serializable]
public class ManaPotion : PotionItem
{
    public ManaPotion(int _id, Sprite _sprite, string _title, int _refillValue, int _count = 0) 
        : base(_id, _sprite, _title, _refillValue, _count)
    {
        refillType = RefillType.Mana;
    }
}
