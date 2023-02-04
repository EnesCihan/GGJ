using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour,IDamagable
{
    public Slider HealthBar;
    public float currentHealth;
    public float maxHealth;
    bool isDead;
    private void Update()
    {
        if (isDead)
            return;
        HealthBar.maxValue = maxHealth;
        HealthBar.value = currentHealth;
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
        }
    }

    public void Die()
    {
        HealthBar.enabled = false;
        if(GetComponent<AttackerAI>()!=null)
            RTSManager.Instance.RemoveSelectable(gameObject);
        Destroy(gameObject, 3);
    }
}
