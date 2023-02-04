using UnityEngine;
using UnityEngine.Events;
public class InputManager : Singleton<InputManager>
{
    #region Params
    //[HideInInspector]
    public bool onGame;
    [HideInInspector]
    public bool onMenu;
    [HideInInspector]
    public bool onOptions;
    #endregion
    #region Events
    public static Vector3Event OnMouseClick = new Vector3Event();
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

    #endregion
    #region MonoBehaviourFunctions

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(OnGameOpen);
        EventManager.OnMenu.AddListener(OnMenu);
        EventManager.OnResumeGame.AddListener(OnGameOpen);
        EventManager.OpenSettingsMenu.AddListener(SettingsMenu);
        EventManager.CloseSettingsMenu.AddListener(OnGameOpen);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(OnGameOpen);
        EventManager.OnMenu.RemoveListener(OnMenu);
        EventManager.OpenSettingsMenu.RemoveListener(SettingsMenu);
        EventManager.OnResumeGame.RemoveListener(OnGameOpen);
        EventManager.CloseSettingsMenu.RemoveListener(OnGameOpen);

    }
    void Update()
    {
        if (onGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ESCKeyCheck();
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseClick.Invoke(Input.mousePosition);
            }

        }
    }

    private void ESCKeyCheck()
    {
        if (!onOptions)
        {
            EventManager.OpenSettingsMenu.Invoke();
        }
    }
    #endregion
}
