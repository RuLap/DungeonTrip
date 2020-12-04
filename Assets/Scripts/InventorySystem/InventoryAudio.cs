using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip healPotionUse;
    [SerializeField]
    private AudioClip manaPotionUse;
    [SerializeField]
    private AudioClip equipArmor;
    [SerializeField]
    private AudioClip unequipArmor;
    [SerializeField]
    private AudioClip equipSword;
    [SerializeField]
    private AudioClip unequipSword;
    [SerializeField]
    private AudioClip dropArmor;
    [SerializeField]
    private AudioClip dropSword;
    [SerializeField]
    private AudioClip exitButton;

    private AudioSource source;

    public AudioSource Source { get { return source; } }

    private void Start()
    {
        source = GetComponent<AudioSource>();    
    }

    /// <summary>
    /// Проигрывает звук использования зелья здоровья
    /// </summary>
    public void PlayHealUse()
    {
        source.clip = healPotionUse;
        source.Play();
    }

    /// <summary>
    /// Проигрывает звук использования зелья магии
    /// </summary>
    public void PlayManaUse()
    {
        source.clip = manaPotionUse;
        source.Play();
    }

    /// <summary>
    /// Проигрывает звук надевания брони
    /// </summary>
    public void PlayEquipArmor()
    {
        source.clip = equipArmor;
        source.Play();
    }

    /// <summary>
    /// Проигрывает звук снятия брони
    /// </summary>
    public void PlayUnequipArmor()
    {
        source.clip = unequipArmor;
        source.Play();
    }

    /// <summary>
    /// Проигрывает звук надевания меча
    /// </summary>
    public void PlayEquipSword()
    {
        source.clip = equipSword;
        source.Play();
    }

    /// <summary>
    /// Проигрывает звук снятия меча
    /// </summary>
    public void PlayUnequipSword()
    {
        source.clip = unequipSword;
        source.Play();
    }

    /// <summary>
    /// Проигрывает звук выкидывания брони
    /// </summary>
    public void PlayDropArmor()
    {
        source.clip = dropArmor;
        source.Play();
    }

    /// <summary>
    /// Проигрывает звук выкидывания меча
    /// </summary>
    public void PlayDropSword()
    {
        source.clip = dropSword;
        source.Play();
    }

    public void PlayExitButton()
    {
        source.clip = exitButton;
        source.Play();
    }
}
