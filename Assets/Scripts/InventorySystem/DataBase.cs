using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> itemsSprites;
    public List<Sprite> ItemsSprites { get { return itemsSprites; } }
}
