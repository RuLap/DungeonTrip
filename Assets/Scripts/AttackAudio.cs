using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip noDamage;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PLayNoDamage()
    {
        source.clip = noDamage;
        source.Play();
    }

}
