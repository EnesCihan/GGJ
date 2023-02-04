using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerAI : MonoBehaviour,IAIBrain
{
    #region Params

    #endregion
    #region MyMethods
    #endregion
    #region MonoBehaviourFunctions
    void Awake()
    {
        
    }
    private void OnEnable()
    {
	  
    }
    private void OnDisable()
    {
	  
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }


    #endregion
    #region AIMethods

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void SetTarget()
    {
        throw new System.NotImplementedException();
    }

    public void ArriveTarget()
    {
        throw new System.NotImplementedException();
    }

    public void SelectAI(bool status)
    {
        isSelected = status;
    }
    private bool isSelected;
    #endregion
}
