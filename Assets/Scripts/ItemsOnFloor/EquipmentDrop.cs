using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDrop : Drop
{
    private EquipmentItem item;
    private GameObject dbHolder;
    private DataBase db;
    private bool isDescriprionActive = false;
    private GameObject dropStatsPanel;
    private Text stats;
    private Inventory inventory;
    private AudioSource source;

    [SerializeField]
    private AudioClip take;
    [SerializeField]
    private AudioClip full;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        dropStatsPanel = GameObject.FindGameObjectWithTag("DropInfo");
        stats = dropStatsPanel.GetComponentInChildren<Text>();
        dbHolder = Camera.main.gameObject;
        db = dbHolder.GetComponent<DataBase>();
        item = GetRandomItem();
        sprite = item.Sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;
        source = GameObject.FindGameObjectWithTag("UIAudio").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var atMouse = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (atMouse.transform != null)
            {
                if (!atMouse.transform.gameObject.CompareTag("Drop")) return;
                GameObject objAtMouse = atMouse.transform.gameObject;
                if (objAtMouse == gameObject)
                {
                    var drop = objAtMouse.GetComponent<EquipmentDrop>();
                    bool added = false;
                    if (drop.item is ArmorItem)
                    {
                        added = inventory.AddItem(item);
                    }
                    else if (drop.item is WeaponItem)
                    {
                        added = inventory.AddItem(item);
                    }
                    if (added)
                    {
                        source.clip = take;
                        source.Play();
                        Destroy(gameObject);
                    }
                    else
                    {
                        source.clip = full;
                        source.Play();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Берет случайный предмет из базы
    /// </summary>
    /// <returns>Новый предмет</returns>
    private EquipmentItem GetRandomItem()
    {
        int type = Random.Range(0, 2);
        if(type == 0)
        {
            return db.Armors[Random.Range(0, db.Armors.Count)];
        }
        else
        {
            return db.Swords[Random.Range(0, db.Swords.Count)];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Inventory>(out Inventory inventory))
        {
            ShowInfo();
            isDescriprionActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isDescriprionActive = false;
        stats.text = string.Empty;
        dropStatsPanel.GetComponent<Image>().enabled = false;
    }

    /// <summary>
    /// Вывод информации о предмете, к которму подошел игрок
    /// </summary>
    public void ShowInfo()
    {
        string color = "<color=\"#ff5500\">";
        if (item is ArmorItem)
        {
            stats.text = $"{color}Уровень:</color> {(item as ArmorItem).level}\n";
            stats.text += $"{color}Защита:</color> {(item as ArmorItem).protection}\n";
        }
        else
        {
            stats.text = $"{color}Уровень:</color> {(item as WeaponItem).level}\n";
            stats.text += $"{color}Урон:</color> {(item as WeaponItem).damage}\n";
        }
        dropStatsPanel.GetComponent<Image>().enabled = true;
    }


}
