using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {
public class EnemyStats : MonoBehaviour {
    public int CurrentHealth;
    public int MaxHealth;
    public int Attack;
    public int Defense;

    void Awake() {
        CurrentHealth = MaxHealth;
    }
}
}