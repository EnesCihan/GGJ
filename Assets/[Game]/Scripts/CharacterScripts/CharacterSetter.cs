using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetter : MonoBehaviour
{
    public Factions Faction;
    public LayerMask ground;
    public List<CharacterData> Datas;
    private SkinController skinController;
    public SkinController SkinController { get { return (skinController == null) ? skinController = GetComponentInChildren<SkinController>() : skinController; } }
    public void SetCharacter()
    {
        SetAI();
        SkinController.SetSkin(Faction);

    }
    private void SetAI()
    {
        if (Faction == Factions.Pigs)
        {
            gameObject.AddComponent<AttackerAI>();
            gameObject.AddComponent<RTSControl>();
            GetComponent<AttackerAI>().data = Datas[(int)Faction];
            GetComponent<AttackerAI>().groundLayer = ground;
            GetComponent<RTSControl>();
            GetComponent<AttackerAI>().Initialize();


        }
        else
        {
            gameObject.AddComponent<DefenderAI>();
            Destroy(gameObject.GetComponent<RTSGraphic>());

        }

    }
}
