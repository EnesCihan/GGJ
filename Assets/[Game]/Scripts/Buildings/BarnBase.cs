using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnBase : MonoBehaviour, IDamagable
{
    #region Params
    public BarnData BarnData;
    private float currentHealth { get => BarnData.totalHealth; set => currentHealth = value; }
    public bool canSpawn;
    public List<Spawner> Spawners;
    public List<AttackerAI> attackers;

    #endregion
    #region MyMethods
    private void Initialize()
    {
        canSpawn = true;
    }
    public void GetDamage(int damage)
    {
        if (currentHealth - damage <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            currentHealth -= damage;
            if (BarnData.totalHealth - (BarnData.totalHealth / (6 - Spawners.Count)) >= currentHealth)
            {
                GetComponentInChildren<RootController>().RemoveRoot();
            }
        }
    }
    public void Die()
    {
        canSpawn = false;
        GameManager.OnGameWin.Invoke();
    }
    #endregion
    #region MonoBehaviourFunctions

    private void OnEnable()
    {
        Initialize();
    }
    private void OnDisable()
    {
    }
    void Update()
    {
        if (canSpawn)
        {
            if (attackers.Count >= BarnData.MaxSpawnCount)
                return;
            for (int i = 0; i < Spawners.Count; i++)
            {
                Spawners[i].SpawnClock();
            }
        }
    }

    #endregion

}
