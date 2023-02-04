using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float horizontalMove;
    private float verticalMove;
    public CinemachineVirtualCamera cmv;
    private float currentZoom;
    private const float MAX_ZOOM = 20f;

    private void Start()
    {
        currentZoom = cmv.m_Lens.FieldOfView;
    }
    void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(horizontalMove, 0f, verticalMove);
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);
    }

    private void Zoom()
    {
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            //cmv.m_Lens.FieldOfView = Mathf.Lerp(currentZoom, MAX_ZOOM, Time.deltaTime * 20f);
            currentZoom = 20f;
            cmv.m_Lens.FieldOfView = currentZoom;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            cmv.m_Lens.FieldOfView = Mathf.Lerp(currentZoom, 60f, Time.deltaTime * 20f);
        }
    }
}
