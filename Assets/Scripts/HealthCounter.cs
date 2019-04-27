using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class HealthCounter : MonoBehaviour {

    float elapsed = 0f;
    public float TickRate = 1;
    public Slider HealthSlider;
    public Text RegenLabel;
    private ParticleSystem particles;

    void Awake() {
        particles = GetComponent<ParticleSystem>();
        Singleton<GameState>.Instance.AddMaxHealth(10, HealthSlider);
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

    public void AddOneHealth() {
        Singleton<GameState>.Instance.AddOneHealth(HealthSlider, particles);
    }

    public void SpendHealth(int cost) {
        var health = Singleton<GameState>.Instance.Health;
        if(health < cost) {
            Debug.LogError($"Cost: {cost} is less than Health: {health}. This should never happen.");
            return;
        }
        Singleton<GameState>.Instance.UpdateHealth(HealthSlider, particles, -cost);
    }

    void Update() {
        RegenLabel.text = Singleton<GameState>.Instance.GetRegen() + " HP/s";
    }
}
}