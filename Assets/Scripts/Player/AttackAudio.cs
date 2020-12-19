using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip noDamage;
    [SerializeField]
    private AudioClip damage;

    private AudioSource source;

    public AudioSource Source { get { return source; } }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PLayNoDamage()
    {
        source.clip = noDamage;
        source.Play();
    }

    public void PlayDamage()
    {
        source.clip = damage;
        source.Play();
    }
}
