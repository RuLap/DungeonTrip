using UnityEngine;

[CreateAssetMenu(fileName = "SpellSO", menuName = "ScriptableObjects/SpellSO", order = 1)]
public class SpellSO : ScriptableObject
{
    public School school;
    public string name;
    public enum School {Fire,Water,Wind,Earth};
    public float damage;
    public float duration;
    public float speed;
    public ParticleSystem particle;
}