using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private EquipmentDrop equipmentDrop;
    [SerializeField]
    private PotionDrop potionDrop;
    [SerializeField]
    private Sprite openedChest;

    /// <summary>
    /// Открытие сундука
    /// </summary>
    public void Open()
    {
        StartCoroutine("Drop");
    }

    /// <summary>
    /// Анимация вылета вещей
    /// </summary>
    /// <returns></returns>
    IEnumerator Drop()
    {
        var dx = 0.1f;
        var dy = 0.1f;
        var equip = Instantiate(equipmentDrop);
        var potion = Instantiate(potionDrop);
        equip.transform.position = transform.position;
        potion.transform.position = transform.position;
        var equipCol = equip.GetComponent<BoxCollider2D>();
        var moneyCol = potion.GetComponent<CapsuleCollider2D>();
        equipCol.enabled = false;
        moneyCol.enabled = false;
        GetComponent<SpriteRenderer>().sprite = openedChest;

        while (Math.Abs(equip.transform.position.x - potion.transform.position.x) < 1.5f)
        {
            equip.transform.position = new Vector2(equip.transform.position.x - dx, equip.transform.position.y - dy);
            potion.transform.position = new Vector2(potion.transform.position.x + dx, potion.transform.position.y - dy);
            yield return new WaitForSecondsRealtime(0.05f);
        }
        equipCol.enabled = true;
        moneyCol.enabled = true;
    }
}
