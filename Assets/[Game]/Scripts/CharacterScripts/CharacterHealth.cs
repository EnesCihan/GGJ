using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour,IDamagable
{
    public Slider HealthBar;
    public float currentHealth;
    public float maxHealth; 
    public bool isDead;
    private CharacterAnimationController cAnimController;

    private void Start()
    {
        cAnimController = GetComponentInChildren<CharacterAnimationController>();
    }
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
        if (isDead)
            return;
        HealthBar.enabled = false;
        if(GetComponent<AttackerAI>()!=null)
            RTSManager.Instance.RemoveSelectable(gameObject);
        cAnimController.Animator.SetTrigger("isDead");
        Destroy(gameObject, 3);
    }
}
