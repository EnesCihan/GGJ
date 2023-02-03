using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    #region Params
    bool onGame;
    bool onMenu;
    #endregion

    #region MyMethods
    private void MenuOpen()
    {
        onGame = false;
        onMenu = true;
    }
    private void OnGameOpen()
    {
        onGame = true;
        onMenu = false;
    }
    #endregion
    #region MonoBehaviourFunctions
    void Awake()
    {
         
    }
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(OnGameOpen);
        EventManager.OnOpenMenu.AddListener(MenuOpen);
        EventManager.OnCloseMenu.AddListener(OnGameOpen);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(OnGameOpen);
        EventManager.OnOpenMenu.RemoveListener(MenuOpen);
        EventManager.OnCloseMenu.RemoveListener(OnGameOpen);

    }

    void Update()
    {
        if (!onGame && !onMenu)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.OnLevelStart.Invoke();
            }
        }
    }
    #endregion

}
