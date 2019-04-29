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
    public bool IsFinalScene = false;

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
        if(IsFinalScene) {
            DialogMessage.text = "Congratulations! You have defeated the king!";
            DialogMessage.transform.parent.gameObject.SetActive(true);
            yield return new WaitForSeconds(4.5f);
            DialogMessage.transform.parent.gameObject.SetActive(false);
            DialogMessage.text = "I hope you have enjoyed this short prototype game.";
            DialogMessage.transform.parent.gameObject.SetActive(true);
            yield return new WaitForSeconds(4.5f);
            DialogMessage.transform.parent.gameObject.SetActive(false);
            DialogMessage.text = "I had so much more content in mind but I could not finish this in 48 hours.";
            DialogMessage.transform.parent.gameObject.SetActive(true);
            yield return new WaitForSeconds(6f);
            DialogMessage.transform.parent.gameObject.SetActive(false);
            DialogMessage.text = "I had to cut off all the backstory on why our hero has become a skeleton and why the king is a bad guy.";
            DialogMessage.transform.parent.gameObject.SetActive(true);
            yield return new WaitForSeconds(7f);
            DialogMessage.transform.parent.gameObject.SetActive(false);
            DialogMessage.text = "Hopefully I will update the game to have more content and areas in the future.\n";
            DialogMessage.text += "In the meantime, please let me know if you enjoyed it, so I can improve it and make it even better!";
            DialogMessage.transform.parent.gameObject.SetActive(true);
            yield return new WaitForSeconds(15f);
            DialogMessage.transform.parent.gameObject.SetActive(false);
            NextScene = "IdleScene";
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