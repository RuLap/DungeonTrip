using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    private PlayerAttackAnimation attackAnim;
    


    void Start()
    {
        attackAnim = GetComponentInChildren<PlayerAttackAnimation>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameController.IsPaused)
            {
                Attack();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpeakToNpc();
        }
    }

    /// <summary>
    /// Поиск противников в радиусе 1 юнита и отнятие у них здоровья в случае успеха
    /// </summary>
    private void Attack()
    {
        attackAnim.PlayAttackAnimation();
        var colliders = Physics2D.OverlapCircleAll(transform.position, 1);
        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemie"))
                {
                    //вызов получения урона у противников
                }
            }
        }
    }

    /// <summary>
    /// Поиск npc в радиусе 1 юнита и вывод сообщения в случае успеха
    /// </summary>
    private void SpeakToNpc()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 1);
        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if(collider.TryGetComponent<Npc>(out Npc npc))
                {
                    npc.TellInfo();
                    return;
                }
            }
        }
    }
}
