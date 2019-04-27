using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class HealthCounter : MonoBehaviour {

    public int Health;
    public int MaxHealth;

    float elapsed = 0f;
    public float TickRate = 1;

    public Slider HealthSlider;

    void Awake() {
        if(HealthSlider) {
            HealthSlider.maxValue = MaxHealth;
            HealthSlider.value = Health;
        }
    }

    void FixedUpdate() {
        elapsed += Time.deltaTime;
        if(elapsed < TickRate) {
            return;
        }
        elapsed -= TickRate;

        // Apply idle regen rate
        var regen = Singleton<GameState>.Instance.Regen;
        ChangeHealth(Health + regen);
    }

    public void ChangeHealth(int newValue) {
        Health = Mathf.Clamp(newValue, 0, MaxHealth);
        if(HealthSlider == null) {
            Debug.LogWarning("Health Slider value is missing, cannot update UI.");
            return;
        }
        HealthSlider.value = Health;
    }
}
}