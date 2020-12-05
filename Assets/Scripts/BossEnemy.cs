using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    private string[] levels = { "Level2", "Level3", "Level4", "Level5", "Level6", "Ending" };
    private string[] bossnames = {"Cyclop","Minotaur","Skelet","Slime","Hero","Mage"};
    public GameObject Portal;
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
    private Animator animator;
    private bool hasAttacked = false;
    private bool dead = false;
    private bool attacking = false;
    [SerializeField]
    private GameObject attackObj;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
        startPos = gameObject.transform.position;
        temp = new GameObject();
        temp.transform.position = startPos;
        maxHealth = health;
        hpBar = GameObject.Find("BossHp").GetComponentInChildren<Image>();
        hpBar.fillAmount=health/maxHealth;
        hpBarText = GameObject.Find("BossHp").GetComponentInChildren<Text>();
        hpBarText.text = $"{health}";
        StartCoroutine(CheckRadius());
        StartCoroutine(Attack());
    }
    private void SetPortalLevel()
    {
        Portal.SetActive(true);
        for(int i = 0; i < levels.Length; i++)
        {
            if (gameObject.name == bossnames[i])
                Portal.GetComponent<Portal>().nextSceneName = levels[i];
        }
    }
    public void ApplyDamage(float damage)
    {
        if(!dead)
        health -= damage;
        if(health>0)
        StartCoroutine(GetDamage());
        hpBar.fillAmount = health / maxHealth;
        hpBarText.text = $"{health}";
        if (health <= 0)
        {
            backMusic.RemoveFromList(gameObject);
            backMusic.PlayCalmMusic();
            animator.Play("Dead");
            destinationSetter.target = transform;
            dead = true;
            SetPortalLevel();
            Destroy(hpBarText);
        }
    }
    IEnumerator CheckRadius()
    {
        for (;dead==false; )
        {
            if (hasAttacked == false&&attacking==false)
            {
                Collider2D[] c2d = Physics2D.OverlapCircleAll(transform.position, seekRadius);
                bool tempb = false;
                foreach(Collider2D cl2d in c2d)
                {
                    if (cl2d.gameObject.GetComponent<Player>() != null)
                        tempb = true;
                }
                if (tempb)
                {
                   
                    backMusic = Camera.main.GetComponentInChildren<BackMusicScript>();
                    backMusic.AddToList(gameObject);
                    backMusic.PlayBattleMusic(battleMusic.enemyMusic);
                    destinationSetter.target = player.transform;
                    animator.Play("Move");
                }
                else
                {
                    backMusic = Camera.main.GetComponentInChildren<BackMusicScript>();
                    backMusic.RemoveFromList(gameObject);
                    backMusic.PlayCalmMusic();
                    destinationSetter.target = temp.transform;
                    animator.Play("Idle");
                }
            }
            yield return new WaitForSeconds(1f);

        }
    }
    IEnumerator Attack()
    {
        for(;dead==false;)
        {
            attacking = false;
            yield return new WaitForSeconds(5f);
            if (dead == false)
            {
                attacking = true;
                destinationSetter.target = transform;
                animator.Play("Attack");
                yield return new WaitForSeconds(2.85f);
                GameObject obj = Instantiate(attackObj);
                obj.transform.position = gameObject.transform.position;
                obj.transform.LookAt2D(player.transform.position);
            }

        }
    }
    IEnumerator GetDamage()
    {
        hasAttacked = true;
        if(!attacking)
        animator.Play("Hit");
        yield return new WaitForSeconds(0.5f);
        if(!attacking)
        animator.Play("Move");
        hasAttacked = false;
    }
}
