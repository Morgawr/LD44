using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace LD44 {
public class DebugTester : MonoBehaviour {

    public Text regenLabel;

    public void PlusOneRegen() {
        Singleton<GameState>.Instance.UpdateRegen(1, regenLabel);
    }
    public void MinusOneRegen() {
        Singleton<GameState>.Instance.UpdateRegen(-1, regenLabel);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(DebugTester))]
public class CardEditorFunctionLayout : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        DebugTester functions = (DebugTester)target;
        if(GUILayout.Button("+1 Regen")){
            functions.PlusOneRegen();
        }
        if(GUILayout.Button("-1 Regen")){
            functions.MinusOneRegen();
        }
    }
}
#endif
}