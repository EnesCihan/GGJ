using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICam : MonoBehaviour
{
    Camera cam;

    #region MyMethods
    private void CameraOff()
    {
        cam.enabled = false;
    }
    private void CameraOn()
    {
        cam.enabled = true;

    }
    #endregion
    #region MonoBehaviourFunctions

    private void Awake()
    {
        cam=GetComponent<Camera>();
    }
    private void OnEnable()
    {
        EventManager.OnMenu.AddListener(CameraOn);
        EventManager.OnLevelStart.AddListener(CameraOff);
    }
    private void OnDisable()
    {
        EventManager.OnMenu.RemoveListener(CameraOff);
        EventManager.OnLevelStart.RemoveListener(CameraOff);

    }

    #endregion

}
