using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class MaxHealthChecker : MonoBehaviour {

    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    void Update() {
        slider.maxValue = Singleton<GameState>.Instance.GetMaxHealth();
    }
}
}