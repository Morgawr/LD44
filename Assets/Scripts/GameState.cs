﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class GameState : MonoBehaviour {
    public int Regen;
    public int Health;
    public int MaxHealth;

    public Dictionary<string, int> PurchasedUpgrades = new Dictionary<string, int>();

    public void TickHealth(Slider slider, ParticleSystem particles) {
        UpdateHealth(slider, particles, Regen);
    }

    public void AddOneHealth(Slider slider, ParticleSystem particles) {
        UpdateHealth(slider, particles, 1);
    }

    public void UpdateHealth(Slider slider, ParticleSystem particles, int value) {
        bool changed = false;
        var newHealth = Mathf.Clamp(Health + value, 0, MaxHealth);
        if(newHealth != Health) {
            Health = newHealth;
            changed = true;
        }
        if(slider == null) {
            Debug.LogWarning("Health Slider value is missing, cannot update UI.");
            return;
        }
        slider.value = Health;
        if(particles && changed && value > 0)
            particles.Emit(value);
    }

    public void UpdateRegen(int value, Text label) {
        Regen += value;
        label.text = Regen + " HP/s";
    }

    public void SetMaxHealth(int value, Slider slider) {
        if(slider == null) {
            Debug.LogWarning("Health Slider value is missing, cannot update MaxHealth UI.");
            return;
        }
        MaxHealth = value;
        slider.maxValue = MaxHealth;
    }

}
}