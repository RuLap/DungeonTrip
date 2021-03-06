﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject magic;
    public GameObject selective;
    private MagicManager magicManager;
    private SpellSO spellSO;
    void Start()
    {
        selective.SetActive(false);
        magicManager = GameObject.Find("Player").GetComponent<MagicManager>();
        spellSO = magic.GetComponent<Spell>().scriptableObject;
        gameObject.GetComponentInChildren<Text>().text = spellSO.name;
    }
    public void ClickOnButton()
    {
        selective.SetActive(true);
        selective.transform.position = gameObject.transform.position;
        switch (spellSO.school)
        {
            case SpellSO.School.Fire:
                magicManager.testSpell1 = magic;
                break;
            case SpellSO.School.Water:
                magicManager.testSpell2 = magic;
                break;
            case SpellSO.School.Earth:
                magicManager.testSpell3 = magic;
                break;
            case SpellSO.School.Ice:
                magicManager.testSpell4 = magic;
                break;
        }
    }
}
