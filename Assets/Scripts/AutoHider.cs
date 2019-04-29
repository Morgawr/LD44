using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {

public class AutoHider : MonoBehaviour {
    public float HideTimeInSec;

    private bool started = false;

    void Start() {
    }

    private IEnumerator HideMeAfterTime(float time) {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    void Update() {
        if(!started) {
            started = true;
            StartCoroutine(HideMeAfterTime(HideTimeInSec));
        }
    }
}
}
