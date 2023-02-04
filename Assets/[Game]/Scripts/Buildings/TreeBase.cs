using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBase : MonoBehaviour,IDamagable
{
    #region Params
    public TreeData TreeBaseData;
    private float currentHealth;
    private float healthRegeration;
    private float lastRegenerate;
    private bool canRegenerate;
    public bool canSpawn;
    public List<Spawner> Spawners;
    public List<Transform> WaitingPost;
    public List<DefenderAI> defenders;
    #endregion
    #region MyMethods
    private void Initialize()
    {
        currentHealth = TreeBaseData.totalHealth;
        healthRegeration = TreeBaseData.HealthRegenerate;
        canRegenerate = true;
        canSpawn = true;
    }
    public Transform GetWaitPost()
    {
        int randomIndex = Random.Range(0,WaitingPost.Count);
        return WaitingPost[randomIndex];
    }
    public void GetDamage(int damage)
    {
        if(currentHealth-damage<=0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            currentHealth -= damage;
            if (TreeBaseData.totalHealth - (TreeBaseData.totalHealth / (6-Spawners.Count)) >= currentHealth)
            {
                GetComponentInChildren<RootController>().RemoveRoot();
            }
        }
    }
    private void Regenerate()
    {
        if(Time.time< lastRegenerate + 1)
        {
            if (currentHealth + healthRegeration > TreeBaseData.totalHealth)
                currentHealth = TreeBaseData.totalHealth;
            else
                currentHealth += healthRegeration;
        }
    }
    public void Die()
    {
        canSpawn = false;
        canRegenerate = false;
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
        if (canRegenerate)
            Regenerate();
        if (canSpawn)
        {
            if (defenders.Count >= TreeBaseData.MaxSpawnCount)
                return;
            for (int i = 0; i < Spawners.Count; i++)
            {
                Spawners[i].SpawnClock();
            }
        }

    }
    private void CheckDefenders()
    {

    }
    #endregion

}
