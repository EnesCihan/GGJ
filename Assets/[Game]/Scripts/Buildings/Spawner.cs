using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Params
    public BaseData baseData;
    private float spawnRate { get => baseData.spawnRate; set => spawnRate = value; }
    public GameObject spawnPrefab { get => baseData.SpawnPrefab; set => spawnPrefab = value; }
    private float lastSpawnTime;
    public Transform spawnPoint;
    #endregion
    #region MyMethods
    public void SpawnClock()
    {
        if (Time.time > lastSpawnTime + spawnRate)
        {
            Spawn(1);
            lastSpawnTime = Time.time;
        }
    }
    private void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var go=Instantiate(spawnPrefab, spawnPoint.position,Quaternion.identity,transform);
            go.transform.SetParent(null);
            go.transform.localScale=Vector3.one;
            go.GetComponent<CharacterSetter>().Faction = baseData.factionType;
            go.GetComponent<CharacterSetter>().SetCharacter();
        }
    }

    #endregion


}
