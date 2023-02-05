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
        for (int i = 0; i < SelectedCharacters.Count; i++)
        {
            if (SelectedCharacters[i] == selectable)
                SelectedCharacters.RemoveAt(i);
        }
        AllSelectableCharacters.Remove(selectable);
    }
    private void ListClear()
    {
        AllSelectableCharacters.Clear();
        SelectedCharacters.Clear();
    }
    private void CheckClick(Vector3 clickPos)
    {
        if (!InputManager.Instance.onGame)
            return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, rtsCharacterLayer))
        {
            if (hit.collider.gameObject.GetComponent<DefenderAI>())
                return;
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
        EventManager.OnMenu.AddListener(ListClear);
    }
    private void OnDisable()
    {
        InputManager.OnMouseClick.RemoveListener(CheckClick);
        EventManager.OnMenu.RemoveListener(ListClear);

    }
    void Start()
    {

    }
    void Update()
    {

    }
    #endregion

}
