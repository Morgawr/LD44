using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class UpgradeStore : MonoBehaviour {

    public IdleSceneInitializer SceneInitializer;
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GetHealthBar() {
        SceneInitializer.HealthBar.gameObject.SetActive(true);
    }

    public void GetRegenLvl1() {
        Singleton<GameState>.Instance.UpdateRegen(1);
        SceneInitializer.RegenLabel.SetActive(true);
    }

    public void UpgradeRegenSmall() {
        Singleton<GameState>.Instance.UpdateRegen(5);
    }

    public void UpgradeRegenMedium() {
        Singleton<GameState>.Instance.UpdateRegen(15);
    }

    public void UpgradeMaxHealthSmall() {
        Singleton<GameState>.Instance.AddMaxHealth(10, SceneInitializer.HealthBar);
    }

    public void UpgradeMaxHealthMedium() {
        Singleton<GameState>.Instance.AddMaxHealth(30, SceneInitializer.HealthBar);
    }

    public void GetBackground() {
        SceneInitializer.Background.SetActive(true);
    }

    public void GetHat() {
        SceneInitializer.Hat.SetActive(true);
        var buff = new GameState.Buff();
        buff.Regen += 5;
        buff.from = "Normal Hat";
        buff.GearSlot = "Hat";
        buff.Level = 1;
        Singleton<GameState>.Instance.Buffs.Add(buff);
    }

    public void GetCape() {
        SceneInitializer.Cape.SetActive(true);
        var buff = new GameState.Buff();
        buff.MaxHealth += 50;
        buff.Defense += 2;
        buff.from = "Normal Cape";
        buff.GearSlot = "Body";
        buff.Level = 1;
        Singleton<GameState>.Instance.Buffs.Add(buff);
    }

    public void GetSword() {
        SceneInitializer.Sword.SetActive(true);
        var buff = new GameState.Buff();
        buff.Attack += 5;
        buff.from = "Short Sword";
        buff.GearSlot = "Sword";
        buff.Level = 1;
        Singleton<GameState>.Instance.Buffs.Add(buff);
    }

    public void GetMap() {
        SceneInitializer.Map.SetActive(true);
    }

    public void HideHealUp() {
        SceneInitializer.HealUpButton.SetActive(false);
    }
}
}
