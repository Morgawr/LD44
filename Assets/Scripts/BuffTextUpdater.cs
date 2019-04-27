using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class BuffTextUpdater : MonoBehaviour {
    private Text label;

    void Start() {
        label = GetComponent<Text>();
    }

    void Update() {
        label.text = Singleton<GameState>.Instance.GetBuffListAsText();
    }
}
}