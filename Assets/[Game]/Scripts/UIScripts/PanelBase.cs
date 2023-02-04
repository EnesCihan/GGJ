using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    protected CanvasGroup CanvasGroup { get { return (canvasGroup == null) ? canvasGroup = GetComponent<CanvasGroup>() : canvasGroup; } }

    [HideInInspector]
    public UnityEvent OnPanelShown = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnPanelHide = new UnityEvent();
    
    public virtual void ShowPanel()
    {
        if (CanvasGroup.alpha > 0)
            return;

        else SetPanel(1, true, true);
    }
    public virtual void HidePanel()
    {
        if (CanvasGroup.alpha == 0)
            return;
        else SetPanel(0, false, false);

    }
    public void SetPanel(float alpha, bool interactable, bool blocksRaycast)
    {
        CanvasGroup.alpha = alpha;
        CanvasGroup.interactable = interactable;
        CanvasGroup.blocksRaycasts = blocksRaycast;
    }
}
