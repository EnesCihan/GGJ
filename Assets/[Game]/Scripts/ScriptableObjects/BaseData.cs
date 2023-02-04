using UnityEngine;

[CreateAssetMenu]
public class BaseData : ScriptableObject
{
    public GameObject SpawnPrefab;
    public Factions factionType;
    public int totalHealth;
    public float spawnRate;
    public float spawningTime;
}
