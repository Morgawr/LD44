using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {
public class ChestOpener : MonoBehaviour {
    public GameObject Open;
    public GameObject Closed;

    public List<GameState.Buff> Rewards = new List<GameState.Buff>();
    public List<string> CompletedAreas = new List<string>();


    void Start() {
        Open.SetActive(false);
        Closed.SetActive(true);
    }

    public void OnOpen() {
        Open.SetActive(true);
        Closed.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            OnOpen();
            collider.gameObject.GetComponent<EntityMover>().speed = 0;
            collider.gameObject.GetComponent<CombatSceneFinisher>().SceneFinished(Rewards, CompletedAreas);
        }
    }
}
}