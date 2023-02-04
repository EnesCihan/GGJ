using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    private PanelBase panelBase;
    public PanelBase PanelBase { get { return (panelBase == null) ? panelBase = GetComponent<PanelBase>() : panelBase; } }

    private void OnEnable()
    {
        PanelBase.ShowPanel();
        EventManager.OnMenu.AddListener(()=> PanelBase.ShowPanel());

    }
    private void OnDisable()
    {
        EventManager.OnMenu.RemoveListener(() => PanelBase.ShowPanel());

    }
    public void StartGame()
    {
        PanelBase.HidePanel();
        EventManager.OnLevelStart.Invoke();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
