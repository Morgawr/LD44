using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {
public class SpriteTilter : MonoBehaviour {

    public int wobbleIntensity = 10;

    public float duration = 30;
    public float startOffset = 0;
    public float startTime = 0f;

    public Vector3 PivotPoint = Vector3.zero;

    void Start() {
        startTime = Time.time;
    }

    public void Disable() {
        SetZAngle(0);
        this.enabled = false;
    }

    void FixedUpdate() {
        var timeDiff = (Time.time - startTime) * 1000;
        if(startOffset > timeDiff)
            return;
		float value = Mathf.Sin((((timeDiff - startOffset) % duration) / duration) * Mathf.PI * 2);
        SetZAngle(wobbleIntensity * value);
    }

    void SetZAngle(float value) {
        var z_value = transform.localRotation.eulerAngles.z;
        transform.RotateAround(transform.TransformPoint(PivotPoint), transform.forward, value - z_value);
    }
}
}