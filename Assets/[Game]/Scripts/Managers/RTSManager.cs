using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSManager : Singleton<RTSManager>
{
    #region Params
    public LayerMask rtsCharacterLayer;
    public List<GameObject> SelectedCharacters;
    public List<GameObject> AllSelectableCharacters;
    #endregion
    #region MyMethods
    public void AddSelectable(GameObject selectable)
    {
        AllSelectableCharacters.Add(selectable);
    }
    public void RemoveSelectable(GameObject selectable)
    {
        AllSelectableCharacters.Remove(selectable);
    }
    private void CheckClick(Vector3 clickPos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, rtsCharacterLayer))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ShiftSelect(hit.collider.gameObject);
            }
            else
            {
                Select(hit.collider.gameObject);
            }
        }
        else
        {
            ClearList();
        }
    }
    
    private void ClearList()
    {
        for (int i = 0; i < SelectedCharacters.Count; i++)
        {
            SelectedCharacters[i].GetComponent<ISelectable>().Deselected();
        }
        SelectedCharacters.Clear();
    }
    private void Select(GameObject selectedObject)
    {
        ClearList();
        SelectedCharacters.Add(selectedObject);
        selectedObject.GetComponent<ISelectable>().Selected();
    }
    public void ShiftSelect(GameObject selectedObject)
    {
        Debug.Log("select");

        if (!SelectedCharacters.Contains(selectedObject))
        {
            SelectedCharacters.Add(selectedObject);
            selectedObject.GetComponent<ISelectable>().Selected();
        }
        else
        {
            SelectedCharacters.Remove(selectedObject);
            selectedObject.GetComponent<ISelectable>().Deselected();
        }
    }
    #endregion
    #region MonoBehaviourFunctions
    private void OnEnable()
    {
        InputManager.OnMouseClick.AddListener(CheckClick);
    }
    private void OnDisable()
    {
        InputManager.OnMouseClick.RemoveListener(CheckClick);

    }
    void Start()
    {

    }
    void Update()
    {

    }
    #endregion

}
