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
        EventManager.OnMenu.Invoke();
    }
    public void GoBackMenu()
    {
        PanelBase.HidePanel();
        EventManager.OnGameStart.Invoke();

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
    }
    private void OnDisable()
    {
        EventManager.OpenSettingsMenu.RemoveListener(OpenSettings);

    }

    #endregion

}
