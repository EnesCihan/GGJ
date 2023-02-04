using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    Camera myCam;
    NavMeshAgent myAgent;
    [SerializeField]
    private LayerMask ground;

    private void Start()
    {
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
            }
        }
    }
}
