using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    #region Params
    public bool stopGame;
    #endregion
    #region Events
    public static UnityEvent OnGameWin = new UnityEvent();
    public static UnityEvent OnGameLoose = new UnityEvent();
    #endregion
    #region MyMethods
    private void StopGame()
    {
        stopGame = true;
    }
    private void ResumeGame()
    {
        stopGame = false;

    }
    private void WinGame()
    {

    }
    private void LooseGame()
    {

    }
    #endregion  
    #region MonoBehaviourFunctions

    private void OnEnable()
    {
        EventManager.OnResumeGame.AddListener(ResumeGame);
        EventManager.OpenSettingsMenu.AddListener(StopGame);
        OnGameWin.AddListener(WinGame);
        OnGameLoose.AddListener(LooseGame);

    }
    private void OnDisable()
    {
        EventManager.OnResumeGame.RemoveListener(ResumeGame);
        EventManager.OpenSettingsMenu.RemoveListener(StopGame);
        OnGameWin.RemoveListener(WinGame);
        OnGameLoose.RemoveListener(LooseGame);

    }

    #endregion

}
