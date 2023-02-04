using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class DefenderAI : MonoBehaviour, IAIBrain
{
    #region Params
    public Transform patrolPoint;
    public CharacterData data;
    private bool isPatrolling=true;
    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NMAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    #endregion

    private void Update()
    {
        IsDestinationReach();
    }
    #region AIMethods

    private bool IsDestinationReach()
    {
        float distToTarget = Vector3.Distance(transform.position, NMAgent.destination);
        if (distToTarget < NMAgent.stoppingDistance + 0.5f)
        {
            if (isPatrolling)
            {
                StartCoroutine(WaitCO());
                return true;
            }
            return false;
        }
        else return false;
    }
    private Vector3 RandomPos()
    {
        Vector3 newPos = (Random.insideUnitSphere * 20) +  patrolPoint.position;
        newPos.y = transform.position.y;
        return newPos;
    }
    IEnumerator WaitCO()
    {
        yield return new WaitForSeconds(3);
        NMAgent.SetDestination(RandomPos());
    }
    public void Initialize()
    {
        NMAgent.speed = data.Speed;
        patrolPoint = GetComponentInParent<TreeBase>().GetWaitPost();
        NMAgent.SetDestination(RandomPos());
    }
    public void SetTarget()
    {
        throw new System.NotImplementedException();
    }

    public void ArriveTarget()
    {
        throw new System.NotImplementedException();
    }

    public void SelectAI(bool status)
    {
        isSelected = status;
    }
    private bool isSelected;
    #endregion
}
