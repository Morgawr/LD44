using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LD44 {
public class CombatSceneFinisher : MonoBehaviour {


    public Text DialogMessage;
    public string CurrentScene = "VillageScene";
    public int DialogTransitionTime = 3;
    private string NextScene = "MapScene";
    private bool ShouldAdvanceToNextScene = false;
    private bool SceneAdvanced = false;

    public void PlayerDied() {
        GameObject.FindGameObjectWithTag("FXPlayer").GetComponent<SoundPlayer>().PlayLoss();
        ShouldAdvanceToNextScene = true;
    }

    public void SceneFinished(List<GameState.Buff> Rewards, List<string> CompletedAreas) { 
        var tilter = GetComponentInChildren<SpriteTilter>();
        tilter.Disable();
        GameObject.FindGameObjectWithTag("FXPlayer").GetComponent<SoundPlayer>().PlayVictory();
        foreach(var area in CompletedAreas) {
            Singleton<GameState>.Instance.CompletedAreas.Add(area);
        }
        StartCoroutine(RewardReaderLabel(Rewards));
    }

    private IEnumerator RewardReaderLabel(List<GameState.Buff> Rewards) {
        foreach(var buff in Rewards) {
            DialogMessage.text = $"Obtained {buff.from}!\n\n";
            DialogMessage.text += buff.GetText();
            DialogMessage.transform.parent.gameObject.SetActive(true);
            Singleton<GameState>.Instance.AddBuff(buff);
            yield return new WaitForSeconds(DialogTransitionTime);
            DialogMessage.transform.parent.gameObject.SetActive(false);
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