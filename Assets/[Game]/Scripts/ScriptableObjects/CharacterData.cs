using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public Factions FactionType;
    [Range(0, 5)]
    public float Speed;
    [Range(0, 100)]
    public int Health;
    [Range(0, 100)]
    public int Damage;
    [Range(0,10)]
    public float AttackRange;
    [Range(0, 5)]
    public float AttackRate;
    [Range(0, 20)]
    public float TriggerDistance;
    [Range(0, 2)]
    public float LevelMultiplier;
}
