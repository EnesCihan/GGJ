using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSControl : MonoBehaviour,ISelectable
{
    private IAIBrain aIBrain;
    public IAIBrain AIBrain { get { return (aIBrain == null) ? aIBrain = GetComponent<IAIBrain>() : aIBrain; } }
    private RTSGraphic rtsGraphic;
    public RTSGraphic RTSGraphic { get { return (rtsGraphic == null) ? rtsGraphic = GetComponent<RTSGraphic>() : rtsGraphic; } }
    public void Deselected()
    {
        AIBrain.SelectAI(false);
        RTSGraphic.Deselected();
    }
    public void Selected()
    {
        AIBrain.SelectAI(true);
        RTSGraphic.Selected();
    }
}
