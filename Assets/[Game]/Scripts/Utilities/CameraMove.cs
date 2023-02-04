using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float horizontalMove;
    private float verticalMove;

    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(horizontalMove, 0f, verticalMove);
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);
    }
}
