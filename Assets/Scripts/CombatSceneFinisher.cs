using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD44 {
public class CombatSceneFinisher : MonoBehaviour {


    public string CurrentScene = "VillageScene";
    private string NextScene = "MapScene";
    private bool ShouldAdvanceToNextScene = false;
    private bool SceneAdvanced = false;

    public void PlayerDied() {
        ShouldAdvanceToNextScene = true;
    }

    public void SceneFinished(List<GameState.Buff> Rewards, List<string> CompletedAreas) { 
        var tilter = GetComponentInChildren<SpriteTilter>();
        tilter.Disable();
        foreach(var area in CompletedAreas) {
            Singleton<GameState>.Instance.CompletedAreas.Add(area);
        }
        StartCoroutine(RewardReaderLabel(Rewards));
    }

    private IEnumerator RewardReaderLabel(List<GameState.Buff> Rewards) {
        foreach(var buff in Rewards) {
            // Set Text 
            // Display label
            Debug.Log($"We got {buff.from}!");
            Singleton<GameState>.Instance.AddBuff(buff);
            yield return new WaitForSeconds(2);
            // Hide label
        }
        ShouldAdvanceToNextScene = true;
    }

    void LateUpdate() {
        if(ShouldAdvanceToNextScene && !SceneAdvanced) {
            SceneManager.LoadSceneAsync(NextScene, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(CurrentScene);
            SceneAdvanced = true;
        }
    }

    
}
}