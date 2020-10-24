using UnityEngine;

[CreateAssetMenu(fileName = "SpellSO", menuName = "ScriptableObjects/SpellSO", order = 1)]
public class SpellSO : ScriptableObject
{
    public School school;
    public enum School {Fire,Water,Wind,Earth};
    public float Damage;
    public GameObject speelPrefab;
}