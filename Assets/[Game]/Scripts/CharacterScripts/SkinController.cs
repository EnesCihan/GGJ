using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public List<GameObject> Skins;
    public void SetSkin(Factions currentFaction)
    {
        switch (currentFaction)
        {
            case Factions.Pigs:
                Skins[0].SetActive(true);
                Skins[1].SetActive(false);
                break;
            case Factions.Tree:
                Skins[1].SetActive(true);
                Skins[0].SetActive(false);
                break;

            default:
                break;
        }
    }

}
