using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD44 {
public class PreloadSceneLoader : MonoBehaviour {

    void Start() {
        var gameState = Singleton<GameState>.Instance;
        gameState.AddMaxHealth(10, null);
        // TEMPORARY
        //gameState.AddMaxHealth(100, null);
        //gameState.UpdateHealth(null, null, 100);
        //var b = new GameState.Buff();
        //b.Attack = 10;
        //b.Defense = 5;
        //gameState.Buffs.Add(b);
        //SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        // END TEMPORARY
        SceneManager.LoadSceneAsync("IdleScene", LoadSceneMode.Additive);
    }

}
}