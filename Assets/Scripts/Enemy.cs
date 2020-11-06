using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float maxHealth = 100;
    private float health = 100;
    private Image hpBar;

    private void Start()
    {
        hpBar = GetComponentInChildren<Image>();
        hpBar.fillAmount = health / maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        hpBar.fillAmount = health / maxHealth;
    }
}
