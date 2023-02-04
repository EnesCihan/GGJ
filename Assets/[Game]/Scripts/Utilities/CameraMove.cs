using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float horizontalMove;
    private float verticalMove;
    [SerializeField]
    private CinemachineVirtualCamera cmv;
    private float cameraDistance;
    private const float MAX_ZOOM = 20f;
    private CinemachineComponentBase componentBase;
    [SerializeField]
    private float sensitivity;

    private void Start()
    {
        componentBase = cmv.GetCinemachineComponent(CinemachineCore.Stage.Body);
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
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            if(componentBase is CinemachineFramingTransposer)
            {
                (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                float currentDistance = (componentBase as CinemachineFramingTransposer).m_CameraDistance;
                if (currentDistance < 20f)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = 20f;
                }
                if (currentDistance > 60f)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = 60f;
                }
            }
        }
    }
}
