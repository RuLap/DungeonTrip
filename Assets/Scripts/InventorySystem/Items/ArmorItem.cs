using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : EquipmentItem
{
    public int protection;
    public ArmorItem(int _id, Sprite _sprite, string _title, int _quality, int _level, int _protection, int _price) 
        : base(_id, _sprite, _title, _quality, _level, _price)
    {
        quality = _quality;
        level = _level;
        protection = _protection;
    }
}
