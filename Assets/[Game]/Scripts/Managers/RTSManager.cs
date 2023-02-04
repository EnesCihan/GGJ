using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSManager : MonoBehaviour
{
    #region Params
    public LayerMask rtsCharacterLayer;
    public List<GameObject> SelectedCharacters;
    #endregion

    #region MyMethods
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
    private void ShiftSelect(GameObject selectedObject)
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
    void Awake()
    {

    }
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
