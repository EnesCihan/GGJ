using UnityEngine;
using UnityEngine.AI;

public class AttackerAI : MonoBehaviour,IAIBrain
{
    #region Params
    Camera myCam;
    public CharacterData data;
    public LayerMask groundLayer;

    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NMAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    #endregion
    #region MyMethods
    #endregion
    #region MonoBehaviourFunctions


    void Update()
    {
        if (!isSelected)
            return;
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
    #region AIMethods

    public void Initialize()
    {
        myCam = Camera.main;

        NMAgent.speed = data.Speed;
        NMAgent.SetDestination(transform.position);
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
