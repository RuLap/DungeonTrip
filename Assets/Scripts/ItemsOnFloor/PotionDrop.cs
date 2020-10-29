using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDrop : Drop
{
    private PotionItem item;
    private Inventory inventory;
    private GameObject dbHolder;
    private DataBase db;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        dbHolder = Camera.main.gameObject;
        db = dbHolder.GetComponent<DataBase>();
        item = GetRandomItem();
        sprite = LoadFromDb();
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    /// <summary>
    /// Берет случайный предмет из базы
    /// </summary>
    /// <returns>Новый предмет</returns>
    private PotionItem GetRandomItem()
    {
        int type = Random.Range(0, 2);
        if (type == 0)
        {
            return inventory.Items[Random.Range(0, 3)] as PotionItem;
        }
        else
        {
            return inventory.Items[Random.Range(3, 6)] as PotionItem;
        }
    }

    private Sprite LoadFromDb()
    {
        if(item.RefillType == RefillType.Health)
        {
            if (item.RefillValue == 15) return db.DropPotionsSprites[0];
            if (item.RefillValue == 45) return db.DropPotionsSprites[1];
            if (item.RefillValue == 90) return db.DropPotionsSprites[2];
        }
        else if(item.RefillType == RefillType.Mana)
        {
            if (item.RefillValue == 15) return db.DropPotionsSprites[3];
            if (item.RefillValue == 45) return db.DropPotionsSprites[4];
            if (item.RefillValue == 90) return db.DropPotionsSprites[5];
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool added = inventory.AddItem(item);
            if (added) Destroy(gameObject);
        }
    }
}
