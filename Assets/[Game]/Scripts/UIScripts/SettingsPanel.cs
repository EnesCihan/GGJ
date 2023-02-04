using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    #region Params
    private PanelBase panelBase;
    public PanelBase PanelBase { get { return (panelBase == null) ? panelBase = GetComponent<PanelBase>() : panelBase; } }
    #endregion

    #region MyMethods
    public void ResumeGame()
    {
        PanelBase.HidePanel();

        EventManager.OnResumeGame.Invoke();

    }
    public void GoBackMenu()
    {
        PanelBase.HidePanel();

        EventManager.OnMenu.Invoke();

    }
    private void OpenSettings()
    {
        PanelBase.ShowPanel();

    }
    #endregion
    #region MonoBehaviourFunctions

    private void OnEnable()
    {
        EventManager.OpenSettingsMenu.AddListener(OpenSettings);
        EventManager.CloseSettingsMenu.AddListener(ResumeGame);
    }
    private void OnDisable()
    {
        EventManager.OpenSettingsMenu.RemoveListener(OpenSettings);
        EventManager.CloseSettingsMenu.RemoveListener(ResumeGame);
    }

    #endregion

}
