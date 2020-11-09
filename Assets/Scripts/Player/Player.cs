using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    private PlayerAttackAnimation attackAnim;

    // Start is called before the first frame update
    void Start()
    {
        attackAnim = GetComponentInChildren<PlayerAttackAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameController.IsPaused)
            {
                Attack();
            }
        }
<<<<<<< Updated upstream
=======
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpeakToNpc();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ApplyDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ReduceMana(5);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerXP.SaveToJson();
        }
    }

    /// <summary>
    /// Добавление опыта при убийстве врага
    /// </summary>
    /// <param name="xp">Опыт</param>
    public void AddXP(int xp)
    {
        var isLevelUp = playerXP.AddPoints(xp);
        if (isLevelUp)
        {
            xpText.text = playerXP.CurrentLevel.ToString();
        }
        xpBar.fillAmount = playerXP.GetFillAmount();
>>>>>>> Stashed changes
    }

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
}
