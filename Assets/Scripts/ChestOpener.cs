using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {
public class ChestOpener : MonoBehaviour {
    public GameObject Open;
    public GameObject Closed;

    void Start() {
        Open.SetActive(false);
        Closed.SetActive(true);
    }

    public void OnOpen() {
        Open.SetActive(true);
        Closed.SetActive(false);
    }
}
}