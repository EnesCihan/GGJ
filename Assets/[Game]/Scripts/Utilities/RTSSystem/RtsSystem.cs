using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsSystem : MonoBehaviour
{
    public LayerMask layerMask;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 middlePosition;
    public Collider[] inspectorCollider;
    public LayerMask characterMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = CursorPoint();
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = CursorPoint();
            middlePosition = (startPosition + endPosition) / 2;
            float radiusValue = Vector3.Distance(endPosition, startPosition);
        }
    }

    private Vector3 CursorPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, layerMask))
        {

            Vector3 newPos = hitInfo.point;
            return newPos;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
