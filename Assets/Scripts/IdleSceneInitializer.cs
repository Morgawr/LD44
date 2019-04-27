using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class IdleSceneInitializer : MonoBehaviour {

    public GameObject Background;
    public Slider HealthBar;
    public GameObject RegenLabel;
    public GameObject Hat;
    public GameObject Cape;
    public GameObject Sword;
    public GameObject Map;
    public GameObject HealUpButton;

    void Awake() {
        // Check what we have unlocked
        var Upgrades = new HashSet<string>(Singleton<GameState>.Instance.PurchasedUpgrades.Keys);
        if(Upgrades.Contains("Health Bar")) 
            HealthBar.gameObject.SetActive(true);
        if(Upgrades.Contains("Regen Lvl 1"))
            RegenLabel.SetActive(true);
        if(Upgrades.Contains("Room")) 
            Background.SetActive(true);
        if(Upgrades.Contains("Hat")) 
            Hat.SetActive(true);
        if(Upgrades.Contains("Cape")) 
            Cape.SetActive(true);
        if(Upgrades.Contains("Sword"))
            Sword.SetActive(true);
        if(Upgrades.Contains("Map"))
            Map.SetActive(true);
        if(Upgrades.Contains("Hide Heal Up"))
            HealUpButton.SetActive(false);
    }

}
}