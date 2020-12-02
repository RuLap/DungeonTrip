using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDrop : Drop
{
    private int count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            count = Random.Range(player.PlayerXP.currentLevel * 5, player.PlayerXP.currentLevel * 10);
            player.AddMoney(count);
            Destroy(gameObject);
        }
    }
}
