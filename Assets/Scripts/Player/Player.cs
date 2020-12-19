using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerAttackAnimation attackAnim;
    private Inventory inventory;
    private AttackAudio audio;
    private PlayerXP playerXP;
    private PlayerStats playerStats;
    private IEnumerator plusMoneyCoroutine;
  

    private Text healthText;
    private Text manaText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text money;
    [SerializeField]
    private Text plusMoney;
    private Text xpText;


    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Image manaBar;
    [SerializeField]
    private Image xpBar;
    [SerializeField]

    public float Health { get { return playerStats.health; } }
    public float Mana { get { return playerStats.mana; } }
    public PlayerXP PlayerXP { get { return playerXP; } }

    public PlayerStats PlayerStats { get { return playerStats; } }
    public Inventory Inventory { get { return inventory; } }

    public bool isOpened = false; //Открыто ли внутриигровое меню

    void Start()
    {
        playerXP = PlayerXP.LoadFromJson("NewPlayerXP"); 
        //Commented for debug
        //playerXP = PlayerXP.LoadFromJson(PlayerPrefs.GetString("PlayerJson"));
        playerStats = PlayerStats.LoadFromJson();
        xpBar = xpBar.GetComponent<Image>();
        xpText = xpBar.GetComponentInChildren<Text>();
        xpText.text = playerXP.CurrentLevel.ToString();
        xpBar.fillAmount = playerXP.GetFillAmount();
        attackAnim = GetComponentInChildren<PlayerAttackAnimation>();
        healthText = hpBar.GetComponentInChildren<Text>();
        hpBar = hpBar.GetComponent<Image>();
        manaText = manaBar.GetComponentInChildren<Text>();
        manaBar = manaBar.GetComponent<Image>();
        nameText.text = playerStats.name;
        money.text = playerStats.money.ToString();
        inventory = GetComponent<Inventory>();
        audio = GetComponentInChildren<AttackAudio>();
        plusMoneyCoroutine = ShowAddedMoney();
    }

    void Update()
    {
        money.text = playerStats.money.ToString();
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            ShopOpen();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }

    /// <summary>
    /// Добавляет опыт
    /// </summary>
    /// <param name="xp"></param>
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
    /// Добавляет игроку деньги
    /// </summary>
    /// <param name="count">Количество денег</param>
    public void AddMoney(int count)
    {
        StopCoroutine(plusMoneyCoroutine);
        plusMoneyCoroutine = ShowAddedMoney();
        playerStats.money += count;
        plusMoney.text = "+" + count.ToString();
        StartCoroutine(plusMoneyCoroutine);
    }

    /// <summary>
    /// Отображение добавленного количества монет
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowAddedMoney()
    {
        var color = plusMoney.color;
        plusMoney.color = new Color(color.r, color.g, color.b, 1);
        yield return new WaitForSecondsRealtime(1);
        while(plusMoney.color.a > 0)
        {
            plusMoney.color = new Color(color.r, color.g, color.b, plusMoney.color.a - 0.05f);
            yield return new WaitForSecondsRealtime(0.0025f);
        }
        plusMoney.text = string.Empty;
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
                if(collider.TryGetComponent<BossEnemy>(out BossEnemy bossenemy))
                {
                    bossenemy.ApplyDamage((inventory.Items[12] as WeaponItem).damage);
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
                if (collider.TryGetComponent<Npc>(out Npc npc))
                {
                    npc.TellInfo();
                    return;
                }
                else if(collider.TryGetComponent<Chest>(out Chest chest))
                {
                    chest.Open();
                }
            }
        }
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    /// <param name="damage">Урон</param>
    public void ApplyDamage(float damage)
    {
        playerStats.health -= damage;
        if (playerStats.health < 0) playerStats.health = 0;
        hpBar.fillAmount = playerStats.health / playerStats.maxHealth;
        healthText.text = playerStats.health.ToString();
    }

    /// <summary>
    /// Отнимает очки магии
    /// </summary>
    /// <param name="value">Сколько отнять</param>
    private void ReduceMana(int value)
    {
        playerStats.mana -= value;
        if (playerStats.mana < 0) playerStats.mana = 0;
        manaBar.fillAmount = playerStats.mana / playerStats.maxMana;
        manaText.text = playerStats.mana.ToString();
    }

    /// <summary>
    /// Поиск магазина в радиусе 1 юнита и его открытие в случае успеха
    /// </summary>
    private void ShopOpen()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 1);
        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<Shop>(out Shop table))
                {
                    table.OpenCloseShop();
                    return;
                }
            }
        }
    }
    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;  //Включение или отключение Canvas. Ещё тут можно использовать метод SetActive()
    }
}
