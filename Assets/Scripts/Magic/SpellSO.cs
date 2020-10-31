using UnityEngine;

[CreateAssetMenu(fileName = "SpellSO", menuName = "MagicSO/SpellSO", order = 1)]
public class SpellSO : ScriptableObject
{
    public School school;
    public string name;
    public SpellType spellType;
    public float damage;
    public float duration;
    public float speed;
    public AudioClip sound;
    public enum School { Fire, Water, Ice, Earth };
    public enum SpellType {За_мышкой,На_земле,В_сторону_курсора};
}