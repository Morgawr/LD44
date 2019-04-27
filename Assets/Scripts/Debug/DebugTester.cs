using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace LD44 {
public class DebugTester : MonoBehaviour {

    public ParticleSystem particles;

    public void PlusOneRegen() {
        Singleton<GameState>.Instance.UpdateRegen(1);
    }
    public void MinusOneRegen() {
        Singleton<GameState>.Instance.UpdateRegen(-1);
    }

    public void Emit() {
        particles.Emit(1);
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
        if(GUILayout.Button("Emit")){
            functions.Emit();
        }
    }
}
#endif
}