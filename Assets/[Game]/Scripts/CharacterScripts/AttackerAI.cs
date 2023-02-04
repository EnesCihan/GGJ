using UnityEngine;
using UnityEngine.AI;

public class AttackerAI : MonoBehaviour,IAIBrain
{
    #region Params
    Camera myCam;
    NavMeshAgent myAgent;
    public CharacterData data;
    [SerializeField]
    private LayerMask ground;

    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NMAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    #endregion
    #region MyMethods
    #endregion
    #region MonoBehaviourFunctions
    void Awake()
    {
        NMAgent.speed = data.Speed;
    }
    private void OnEnable()
    {
	  
    }
    private void OnDisable()
    {
	  
    }
    void Start()
    {
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (isSelected == false)
        {
            myAgent.SetDestination(transform.position);
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
                print("get");
            }
        }
    }


    #endregion
    #region AIMethods

    public void Initialize()
    {
        throw new System.NotImplementedException();
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
