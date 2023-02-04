using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PanelBase))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PanelBase myScript = (PanelBase)target;
        if (GUILayout.Button("Show Panel"))
        {
            myScript.ShowPanel();
        }
        if (GUILayout.Button("Hide Panel"))
        {
            myScript.HidePanel();
        }
    }
}