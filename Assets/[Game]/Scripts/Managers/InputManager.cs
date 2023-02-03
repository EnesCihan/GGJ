using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    #region Params
    bool onGame;
    bool onMenu;
    bool onOptions;
    #endregion

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
            if(Input.GetButton("ESC"))
            {
                EventManager.OpenSettingsMenu.Invoke();
            }
        }
        if (onOptions)
        {
            if (Input.GetButton("ESC"))
            {
                EventManager.CloseSettingsMenu.Invoke();
            }
        }
    }
    #endregion

}
