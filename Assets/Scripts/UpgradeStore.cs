using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class UpgradeStore : MonoBehaviour {

    public Slider HealthBar;
    public GameObject RegenLabel;
    private GameObject player;
    private Text realRegenLabel;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        var labels = RegenLabel.GetComponentsInChildren<Text>();
        foreach(var label in labels) {
            if(label.transform.parent != RegenLabel)
                realRegenLabel = label;
        }
    }

    public void GetHealthBar() {
        HealthBar.gameObject.SetActive(true);
    }

    public void GetRegenLvl1() {
        Singleton<GameState>.Instance.UpdateRegen(1, realRegenLabel);
        RegenLabel.SetActive(true);
    }

    public void UpgradeRegen() {
        Singleton<GameState>.Instance.UpdateRegen(5, realRegenLabel);
    }

    public void UpgradeMaxHealthSmall() {
        var currentMaxHealth = Singleton<GameState>.Instance.MaxHealth;
        Singleton<GameState>.Instance.SetMaxHealth(currentMaxHealth + 10, HealthBar);
    }
}
}
