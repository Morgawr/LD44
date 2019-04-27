using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class GameState : MonoBehaviour {
    public int Regen;
    public int Health;
    public int MaxHealth;
    public int Strength;
    public int Defense;

    [System.Serializable]
    public class Buff {
        public int Regen;
        public int MaxHealth;
        public int Attack;
        public int Defense;
        public string GearSlot;
        public int Level;
        public string from;

        public string GetText() {
            var text = from + ":\n";
            bool changed = false;
            if(Regen != 0) {
                text += $"\tRegen: {Regen.ToString("+0;-#")}\n";
                changed = true;
            }
            if(MaxHealth != 0) {
                text += $"\tMaxHP: {MaxHealth.ToString("+0;-#")}\n";
                changed = true;
            }
            if(Attack != 0) {
                text += $"\tAtk: {Attack.ToString("+0;-#")}\n";
                changed = true;
            }
            if(Defense != 0) {
                text += $"\tDef: {Defense.ToString("+0;-#")}\n";
                changed = true;
            }
            if(changed)
                return text;
            return from;
        }
    }

    public Dictionary<string, int> PurchasedUpgrades = new Dictionary<string, int>();
    public List<Buff> Buffs = new List<Buff>();

    public void TickHealth(Slider slider, ParticleSystem particles) {
        UpdateHealth(slider, particles, Regen + Buffs.Select(x => x.Regen).Sum());
    }

    public void AddOneHealth(Slider slider, ParticleSystem particles) {
        UpdateHealth(slider, particles, 1);
    }

    public void UpdateHealth(Slider slider, ParticleSystem particles, int value) {
        var newHealth = Mathf.Clamp(Health + value, 0, GetMaxHealth());
        var changed = false;
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

    public void UpdateRegen(int value) {
        Regen += value;
    }

    public void AddMaxHealth(int value, Slider slider) {
        if(slider == null) {
            Debug.LogWarning("Health Slider value is missing, cannot update MaxHealth UI.");
            return;
        }
        MaxHealth += value;
        slider.maxValue = GetMaxHealth();
    }

    public int GetMaxHealth() {
        return MaxHealth + Buffs.Select(x => x.MaxHealth).Sum();
    }

    public int GetRegen() {
        return Regen + Buffs.Select(x => x.Regen).Sum();
    }

    public string GetBuffListAsText() {
        return string.Concat(Buffs.Select(x => x.GetText()));
    }

    public void ReplaceBuff(string slot, Buff newBuff) {
        for(var i = 0; i < Buffs.Count; i++) {
            var buff = Buffs[i];
            if(buff.GearSlot == slot && buff.Level < newBuff.Level) {
                Buffs[i] = newBuff;
                return;
            }
        } 
    }
}
}