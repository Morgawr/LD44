using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD44 {
public class PreloadSceneLoader : MonoBehaviour {

    void Start() {
        var gameState = Singleton<GameState>.Instance;
        //gameState.AddMaxHealth(10, null);
        // TEMPORARY
        gameState.AddMaxHealth(350, null);
        //gameState.UpdateHealth(null, null, 400);
        gameState.Regen = 101;
        GameState.Buff b;
        b = new GameState.Buff();
        b.Regen = 5;
        b.from = "Normal Hat";
        b.GearSlot = "Hat";
        b.Level = 1;
        gameState.Buffs.Add(b);
        b = new GameState.Buff();
        b.MaxHealth = 50;
        b.Defense = 15;
        b.from = "Normal Cape";
        b.GearSlot = "Body";
        b.Level = 1;
        gameState.Buffs.Add(b);
        b = new GameState.Buff();
        b.Attack = 20;
        b.from = "Short Sword";
        b.GearSlot = "Sword";
        b.Level = 1;
        gameState.Buffs.Add(b);
        gameState.PurchasedUpgrades = new Dictionary<string, int>(){
            {"Health Bar", 1},
            {"Regen Lvl 1", 1},
            {"+5 HP/s", 5},
            {"+10 Max Hp", 10},
            {"Hat", 1},
            {"Cape", 1},
            {"Sword", 1},
            {"Map", 1},
            {"+30 Max Hp", 8},
            {"+15 HP/s", 5},
        };
        SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        // END TEMPORARY
        SceneManager.LoadSceneAsync("IdleScene", LoadSceneMode.Additive);
    }

}
}