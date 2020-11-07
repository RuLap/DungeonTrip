using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackMusicScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip calmMusic;
    private AudioSource audioSource;
    private bool battleMusicIsPlaying = false;
    private bool calmMusicIsPlaying = true;
    public List<GameObject> enemies = new List<GameObject>();
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void AddToList(GameObject obj){
        if (!enemies.Any(GameObject => GameObject == obj))
        {
            enemies.Add(obj);
            Debug.Log(enemies.Count);
        }
    }
    public void RemoveFromList(GameObject obj){
        if (enemies.Any(GameObject => GameObject == obj))
        {
            enemies.Remove(obj);
            Debug.Log(enemies.Count);
        }
    }
    public void PlayBattleMusic(AudioClip audioClip)
    {
        if (!battleMusicIsPlaying)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(audioClip);
            battleMusicIsPlaying = true;
            calmMusicIsPlaying = false;
        }
    }
    public void PlayCalmMusic()
    {
        if (!calmMusicIsPlaying && enemies.Count==0)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(calmMusic);
            battleMusicIsPlaying = false;
            calmMusicIsPlaying = true;
        }
    }
}
