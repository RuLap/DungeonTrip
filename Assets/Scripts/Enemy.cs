using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyMusicSO battleMusic;
    private float maxHealth;
    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float seekRadius = 15f;
    public int enemyDamage = 5;
    private Image hpBar;
    private Text hpBarText;
    private BackMusicScript backMusic;
    private Vector3 startPos;
    private AIDestinationSetter destinationSetter;
    private GameObject player;
    private GameObject temp;

    private void Start()
    {
        player = GameObject.Find("Player");
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
        startPos = gameObject.transform.position;
        temp=new GameObject();
        temp.transform.position = startPos;
        maxHealth = health;
        hpBar = GetComponentInChildren<Image>();
        hpBar.fillAmount = health / maxHealth;
        hpBarText = GetComponentInChildren<Text>();
        hpBarText.text = $"{health}/{maxHealth}";
        StartCoroutine(CheckRadius());
    }
    public void ApplyDamage(float damage)
    {
        health -= damage;
        hpBar.fillAmount = health / maxHealth;
        hpBarText.text = $"{health}/{maxHealth}";
        if (health <= 0) {
            backMusic.RemoveFromList(gameObject);
            backMusic.PlayCalmMusic();
            Destroy(gameObject); 
        }
    }
    IEnumerator CheckRadius()
    {
        for (;;)
        {
            Collider2D[] c2d = Physics2D.OverlapCircleAll(transform.position, seekRadius);
            if (c2d[0].GetComponent<Player>() != null)
            {
                backMusic = Camera.main.GetComponentInChildren<BackMusicScript>();
                backMusic.AddToList(gameObject);
                backMusic.PlayBattleMusic(battleMusic.enemyMusic);
                destinationSetter.target = player.transform;
            }
            else
            {
                backMusic = Camera.main.GetComponentInChildren<BackMusicScript>();
                backMusic.RemoveFromList(gameObject);
                backMusic.PlayCalmMusic();
                destinationSetter.target = temp.transform;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
