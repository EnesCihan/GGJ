using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class AttackerAI : MonoBehaviour,IAIBrain
{
    #region Params
    Camera myCam;
    public CharacterData data;
    public LayerMask groundLayer;
    public GameObject target;
    bool isAttacking;
    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NMAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    #endregion
    #region MonoBehaviourFunctions

    void Update()
    {
        CheckForEnemy();
        if (!isSelected)
        {
            return;
        }
        IsDestinationReach();
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                NMAgent.SetDestination(hit.point);
            }
        }
    }


    #endregion
    #region AttackMethods
    private void CheckForEnemy()
    {
        if (isAttacking)
            return;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, data.TriggerDistance);
        if (hitColliders.Length == 0)
        {
            return;
        }

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponent<DefenderAI>()|| hitCollider.gameObject.GetComponent<TreeBase>())
            {
                MoveEnemy(hitCollider.gameObject);
            }

        }
    }
    private void MoveEnemy(GameObject enemy)
    {
        isAttacking = true;
        target = enemy;
        NMAgent.SetDestination(target.transform.position);
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
        transform.DOLookAt(target.transform.position,0.2f);
        target.GetComponent<IDamagable>().GetDamage(data.Damage);
    }
    #endregion
    #region AIMethods
    bool IsDestinationReach()
    {
        float distToTarget = Vector3.Distance(transform.position, NMAgent.destination);
        if (distToTarget < NMAgent.stoppingDistance + 1.5f)
        {
            if (!isAttacking)
            {
                NMAgent.SetDestination(transform.position);
                return true;
            }
            else
            {

                AttackCount();
                return false;
            }
        }
        else return false;
    }
    public void Initialize()
    {
        myCam = Camera.main;

        NMAgent.speed = data.Speed;
        NMAgent.SetDestination(transform.position);
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
