using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentItem : Item
{
    protected int quality;
    public int level;

    public EquipmentItem(int _id, Sprite _sprite, string _title, int _quality, int _level) : base(_id, _sprite, _title)
    {
        quality = _quality;
        level = _level;
    }
}
