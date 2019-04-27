using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class HealthCounter : MonoBehaviour {

    float elapsed = 0f;
    public float TickRate = 1;
    public Slider HealthSlider;
    private ParticleSystem particles;

    void Awake() {
        particles = GetComponent<ParticleSystem>();
        Singleton<GameState>.Instance.SetMaxHealth(10, HealthSlider);
        Singleton<GameState>.Instance.TickHealth(HealthSlider, null);
    }

    void FixedUpdate() {
        elapsed += Time.deltaTime;
        if(elapsed < TickRate) {
            return;
        }
        elapsed -= TickRate;
        ChangeHealth();
    }

    public void ChangeHealth() {
        Singleton<GameState>.Instance.TickHealth(HealthSlider, particles);
    }
}
}