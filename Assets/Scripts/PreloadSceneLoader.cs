using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD44 {
public class PreloadSceneLoader : MonoBehaviour {

    void Start() {
        var gameState = Singleton<GameState>.Instance;
        gameState.AddMaxHealth(10, null);
        SceneManager.LoadSceneAsync("IdleScene", LoadSceneMode.Additive);
    }

}
}