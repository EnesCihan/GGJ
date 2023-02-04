using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTSGraphic : MonoBehaviour
{
    public Image image;
    public void Deselected()
    {
        image.enabled = false;
    }

    public void Selected()
    {
        image.enabled = true;
    }
}
