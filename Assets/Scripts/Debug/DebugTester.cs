using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

namespace LD44 {
public class DebugTester : MonoBehaviour {

    public ParticleSystem particles;
    public ChestOpener Chest;

    public void PlusOneRegen() {
        Singleton<GameState>.Instance.UpdateRegen(1);
    }
    public void MinusOneRegen() {
        Singleton<GameState>.Instance.UpdateRegen(-1);
    }

    public void Emit() {
        particles.Emit(1);
    }

    public void ChangeSceneToIdle() {
        SceneManager.UnloadSceneAsync("MapScene");
        SceneManager.LoadSceneAsync("IdleScene", LoadSceneMode.Additive);
    }

    public void OpenChest() {
        Chest.OnOpen();
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
        if(GUILayout.Button("Change Scene To Idle")){
            functions.ChangeSceneToIdle();
        }
        if(GUILayout.Button("Open Chest")){
            functions.OpenChest();
        }
    }
}
#endif
}