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
                GetComponent<CharacterAnimationController>().Animator = Skins[0].GetComponent<Animator>();
                break;
            case Factions.Tree:
                Skins[1].SetActive(true);
                Skins[0].SetActive(false);
                GetComponent<CharacterAnimationController>().Animator = Skins[1].GetComponent<Animator>();
                break;

            default:
                break;
        }
    }

}
