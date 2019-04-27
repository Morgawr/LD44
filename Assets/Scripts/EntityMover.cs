using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {
public class EntityMover : MonoBehaviour {

    Rigidbody2D body;

    public float speed;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        body.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.Self);
    }
}
}