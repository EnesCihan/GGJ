using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
public class InputManager : MonoBehaviour
{
    #region Params
    bool onGame;
    bool onMenu;
    bool onOptions;
    #endregion
    public static Vector3Event OnMouseClick = new Vector3Event();
    #region MyMethods
    private void SettingsMenu()
    {
        onGame = false;
        onMenu = false;
        onOptions = true;
    }
    private void OnMenu()
    {
        onGame = false;
        onOptions = false;
        onMenu = true;
    }
    private void OnGameOpen()
    {
        onMenu = false;
        onOptions = false;
        onGame = true;
    }
    private void OnStartGame()
    {
        onMenu = false;
        onOptions = false;
        onGame = false;
    }
    #endregion
    #region MonoBehaviourFunctions

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(OnGameOpen);
        EventManager.OnMenu.AddListener(OnMenu);
        EventManager.OnGameStart.AddListener(OnStartGame);
        EventManager.OpenSettingsMenu.AddListener(SettingsMenu);
        EventManager.CloseSettingsMenu.AddListener(OnGameOpen);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(OnGameOpen);
        EventManager.OnMenu.RemoveListener(OnMenu);
        EventManager.OnGameStart.RemoveListener(OnStartGame);
        EventManager.OpenSettingsMenu.RemoveListener(SettingsMenu);
        EventManager.CloseSettingsMenu.RemoveListener(OnGameOpen);

    }
    public LayerMask selectableLayer;
    void Update()
    {
        if (!onGame && !onMenu && !onOptions)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.OnLevelStart.Invoke();
            }
        }
        if(onGame)
        {
            ShiftKeyCheck();
            ESCKeyCheck();
            if(Input.GetMouseButtonDown(0))
            {
                OnMouseClick.Invoke(Input.mousePosition);
            }
        }

        if (onOptions)
        {
            ESCKeyCheck();
        }
    }
    private void UnitSelection()
    {

    }
    private void ShiftKeyCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }
    }
    private void ESCKeyCheck()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if(onOptions)
                EventManager.CloseSettingsMenu.Invoke();
            else
                EventManager.OpenSettingsMenu.Invoke();
        }
    }
    #endregion

}
