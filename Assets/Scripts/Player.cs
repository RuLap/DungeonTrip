using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private string name = "Jack";
    private PlayerAttackAnimation attackAnim;
    private float health = 100;
    private float mana = 100;
    private float maxHealth = 100;
    private float maxMana = 100;
    private Inventory inventory;
    private AttackAudio audio;
    private PlayerXP playerXP;

    private Text healthText;
    private Text manaText;
    [SerializeField]
    private Text nameText;
    private Text xpText;

    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Image manaBar;
    [SerializeField]
    private Image xpBar;

    public float Health { get { return health; } }
    public float Mana { get { return mana; } }
    public PlayerXP PlayerXP { get { return playerXP; } }
    void Start()
    {
        playerXP = PlayerXP.LoadFromJson();
        xpBar = xpBar.GetComponent<Image>();
        xpText = xpBar.GetComponentInChildren<Text>();
        xpText.text = playerXP.CurrentLevel.ToString();
        xpBar.fillAmount = playerXP.GetFillAmount();
        attackAnim = GetComponentInChildren<PlayerAttackAnimation>();
        healthText = hpBar.GetComponentInChildren<Text>();
        hpBar = hpBar.GetComponent<Image>();
        manaText = manaBar.GetComponentInChildren<Text>();
        manaBar = manaBar.GetComponent<Image>();
        nameText.text = name;
        inventory = GetComponent<Inventory>();
        audio = GetComponentInChildren<AttackAudio>();
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

    public void AddXP(int xp)
    {
        var isLevelUp = playerXP.AddPoints(xp);
        if (isLevelUp)
        {
            xpText.text = playerXP.CurrentLevel.ToString();
        }
        xpBar.fillAmount = playerXP.GetFillAmount();
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
                if (collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    //вызов получения урона у противников
                    enemy.ApplyDamage((inventory.Items[12] as WeaponItem).damage);
                    audio.PlayDamage();
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

    /// <summary>
    /// Получение урона
    /// </summary>
    /// <param name="damage">Урон</param>
    private void ApplyDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        hpBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString();
    }

    /// <summary>
    /// Отнимает очки магии
    /// </summary>
    /// <param name="value">Сколько отнять</param>
    private void ReduceMana(int value)
    {
        mana -= value;
        if (mana < 0) mana = 0;
        manaBar.fillAmount = mana / maxMana;
        manaText.text = mana.ToString();
    }
}
