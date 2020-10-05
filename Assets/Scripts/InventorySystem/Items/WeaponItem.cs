using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : EquipmentItem
{
    protected int damage;

    public WeaponItem(int _id, Sprite _sprite, string _title, int _quality, int _level, int _damage) 
        : base(_id, _sprite, _title, _quality, _level)
    {
        damage = _damage;
    }
}
