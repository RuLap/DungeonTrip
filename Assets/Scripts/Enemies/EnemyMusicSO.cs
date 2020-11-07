using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicSO", menuName = "MusicSO/EnemyMusicSO", order = 1)]
public class EnemyMusicSO : ScriptableObject
{
    public AudioClip enemyMusic;
}
