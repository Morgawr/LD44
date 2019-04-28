using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LD44 {
public class DamageResolver : MonoBehaviour {

    public bool IsPlayer;
    private bool canAttack = true;

    private Slider HealthBar;

    private SoundPlayer player;

    void OnCollisionEnter2D(Collision2D collision) {
        HandleDamageCollision(collision);
    }

    void OnCollisionStay2D(Collision2D collision) {
        HandleDamageCollision(collision);
    }

    void HandleDamageCollision(Collision2D collision) {
        if(!canAttack)
            return;
        if(IsPlayer && collision.collider.gameObject.tag == "Enemy") {
            player.PlayHit();
            DoAttack(collision.collider.gameObject, Singleton<GameState>.Instance.GetAttack());
        } else if(collision.collider.gameObject.tag == "Player") {
            player.PlayHit();
            DoAttack(collision.collider.gameObject, GetComponent<EnemyStats>().Attack);
        }
    }

    private IEnumerator AttackCooldown() { 
        canAttack = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
    }

    void DoAttack(GameObject target, int damage) {
        StartCoroutine(AttackCooldown());
        target.GetComponent<DamageResolver>().GetDamaged(damage);
    }

    void GetDamaged(int damage) {
        var body = GetComponent<Rigidbody2D>();
        if(IsPlayer) {
            body.AddForce(new Vector2(-250, 100));
            damage = Mathf.Clamp(damage - Singleton<GameState>.Instance.GetDefense(), 0, damage);
            Debug.Log($"Player received {damage} damage.");
            if(Singleton<GameState>.Instance.ReceiveDamage(damage)) {
                GetComponent<CombatSceneFinisher>().PlayerDied();
            }
        } else {
            body.AddForce(new Vector2(250, 100));
            var stats = GetComponent<EnemyStats>();
            damage = Mathf.Clamp(damage - stats.Defense, 0, damage);
            stats.CurrentHealth -= damage;
            Debug.Log($"Enemy received {damage} damage (HP: {stats.CurrentHealth}).");
            if(stats.CurrentHealth <= 0) {
                GameObject.Destroy(gameObject);
            }
        }
    }

    void Start() {
        HealthBar = GetComponentInChildren<Slider>();
        player = GameObject.FindGameObjectWithTag("FXPlayer").GetComponent<SoundPlayer>();
    }
    
    void Update() {
        if(IsPlayer) {
            HealthBar.maxValue = Singleton<GameState>.Instance.GetMaxHealth();
            HealthBar.value = Singleton<GameState>.Instance.Health;
        } else {
            var stats = GetComponent<EnemyStats>();
            HealthBar.maxValue = stats.MaxHealth;
            HealthBar.value = stats.CurrentHealth;
        }
    }

}
}