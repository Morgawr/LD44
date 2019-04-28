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
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetCape() {
        SceneInitializer.Cape.SetActive(true);
        var buff = new GameState.Buff();
        buff.MaxHealth += 50;
        buff.Defense += 15;
        buff.from = "Normal Cape";
        buff.GearSlot = "Body";
        buff.Level = 1;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetSword() {
        SceneInitializer.Sword.SetActive(true);
        var buff = new GameState.Buff();
        buff.Attack += 20;
        buff.from = "Short Sword";
        buff.GearSlot = "Sword";
        buff.Level = 1;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetMap() {
        SceneInitializer.Map.SetActive(true);
    }

    public void HideHealUp() {
        SceneInitializer.HealUpButton.SetActive(false);
    }

    public void GetSound() {
        Singleton<GameState>.Instance.PlayIdleMusic();
    }

    public void GetSoundDisabler() {
        GameObject.FindGameObjectWithTag("SoundButton").GetComponent<SoundToggler>().Toggle();
    }

    public void GetHeavyArmor() {
        var buff = new GameState.Buff();
        buff.MaxHealth += 200;
        buff.Defense += 30;
        buff.from = "Heavy Armor";
        buff.GearSlot = "Body";
        buff.Level = 2;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetBattleAxe() {
        var buff = new GameState.Buff();
        buff.Attack += 70;
        buff.from = "Battle Axe";
        buff.GearSlot = "Sword";
        buff.Level = 3;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetNecromancyBracelet() {
        var buff = new GameState.Buff();
        buff.Regen += 100;
        buff.Defense += 50;
        buff.from = "Bracelet of Necromancy";
        buff.GearSlot = "Necromancy Bracelet";
        buff.Level = 1;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetArmorOfFire() {
        var buff = new GameState.Buff();
        buff.Defense += 140;
        buff.MaxHealth += 500;
        buff.from = "Armor of Fire";
        buff.GearSlot = "Body";
        buff.Level = 5;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetCurseOfProtection() {
        var buff = new GameState.Buff();
        buff.MaxHealth += 1700;
        buff.Regen += 50;
        buff.from = "Curse of Protection";
        buff.GearSlot = "Curse";
        buff.Level = 1;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetBiteOfTheSnake() {
        var buff = new GameState.Buff();
        buff.MaxHealth += 2000;
        buff.Regen -= 200;
        buff.from = "Snake Venom";
        buff.GearSlot = "Venom";
        buff.Level = 1;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetClaymore() {
        var buff = new GameState.Buff();
        buff.Attack = 200;
        buff.from = "Claymore";
        buff.GearSlot = "Sword";
        buff.Level = 6;
        Singleton<GameState>.Instance.AddBuff(buff);
    }

    public void GetArmorOfGods() {
        var buff = new GameState.Buff();
        buff.MaxHealth = 500;
        buff.Defense = 220;
        buff.from = "Armor of Gods";
        buff.GearSlot = "Body";
        buff.Level = 10;
        Singleton<GameState>.Instance.AddBuff(buff);
    }
}
}
