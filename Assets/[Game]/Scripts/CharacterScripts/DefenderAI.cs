using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class DefenderAI : MonoBehaviour, IAIBrain
{
    #region Params
    public Transform patrolPoint;
    public CharacterData data;
    private bool isPatrolling = true;
    private bool isAttacking = false;
    public GameObject target;
    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NMAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    #endregion
    private void Update()
    {
        IsDestinationReach();
        if (isPatrolling)
            CheckForEnemy();
    }
    #region AIMethods
    private void BackToPatrol()
    {
        isAttacking = false;
        isPatrolling = true;
    }
    private void CheckForEnemy()
    {
        if (isAttacking)
            return;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, data.TriggerDistance);
        if (hitColliders.Length == 0)
        {
            BackToPatrol();
            return;
        }

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponent<AttackerAI>())
            {
                MoveEnemy(hitCollider.gameObject);
            }
        }
    }
    private void MoveEnemy(GameObject enemy)
    {
        isAttacking = true;
        isPatrolling = false;
        target = enemy;
        NMAgent.SetDestination(target.transform.position);
    }
    private bool IsDestinationReach()
    {
        float distToTarget = Vector3.Distance(transform.position, NMAgent.destination);
        TargetFollow();
        if (distToTarget < NMAgent.stoppingDistance + 0.5f)
        {
            if (isPatrolling)
            {
                StartCoroutine(WaitCO());
                return true;
            }
            else
                return false;
        }
        else return false;
    }
    private float lastAttackTime;
    private void AttackCount()
    {
        if (Time.time >= lastAttackTime + data.AttackRate)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }
    private void Attack()
    {
        if (target == null)
        {
            isAttacking = false;
            return;
        }
        target.GetComponent<IDamagable>().GetDamage(data.Damage);
    }
    private void TargetFollow()
    {
        if (target == null)
        {
            isAttacking=false;
            return;
        }
        float distToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distToTarget <= NMAgent.stoppingDistance)
            AttackCount();
        else
            NMAgent.SetDestination(target.transform.position);
    }
    private Vector3 RandomPos()
    {
        Vector3 newPos = (Random.insideUnitSphere * 20) + patrolPoint.position;
        newPos.y = transform.position.y;
        target = null;
        return newPos;
    }
    IEnumerator WaitCO()
    {
        yield return new WaitForSeconds(3);
        if (isPatrolling)
        {
            NMAgent.SetDestination(RandomPos());
        }
    }
    public void Initialize()
    {
        NMAgent.speed = data.Speed;
        patrolPoint = GetComponentInParent<TreeBase>().GetWaitPost();
        NMAgent.SetDestination(RandomPos());
        GetComponent<CharacterHealth>().currentHealth = data.Health;
        GetComponent<CharacterHealth>().maxHealth = data.Health;
    }

    public void SelectAI(bool status)
    {
        isSelected = status;
    }
    private bool isSelected;
    #endregion
}
