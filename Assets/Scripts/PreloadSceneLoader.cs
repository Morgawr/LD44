using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD44 {
public class PreloadSceneLoader : MonoBehaviour {

    void Start() {
        var _ = Singleton<GameState>.Instance;
        SceneManager.LoadSceneAsync("IdleScene", LoadSceneMode.Additive);
    }

}
}