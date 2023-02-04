using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    private PanelBase panelBase;
    public PanelBase PanelBase { get { return (panelBase == null) ? panelBase = GetComponent<PanelBase>() : panelBase; } }

    private void OnEnable()
    {
        PanelBase.ShowPanel();
    }
    public void StartGame()
    {
        EventManager.OnGameStart.Invoke();
        PanelBase.HidePanel();
    }
    public void ExitGame()
    {
        Application.Quit();

    }

}
