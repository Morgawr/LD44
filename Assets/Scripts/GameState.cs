using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class GameState : MonoBehaviour {
    public int Regen;
    public int Health;
    public int MaxHealth;

    public void TickHealth(Slider slider) {
        Health = Mathf.Clamp(Health + Regen, 0, MaxHealth);
        if(slider == null) {
            Debug.LogWarning("Health Slider value is missing, cannot update UI.");
            return;
        }
        slider.value = Health;
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