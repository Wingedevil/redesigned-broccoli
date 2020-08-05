using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomText : MonoBehaviour {
    public float InitialVarX;

    private Vector3 pos;

    private void Start() {
        pos = transform.position;
        pos.x = Formula(InitialVarX);
    }
    private void Update() {
        InitialVarX += Time.deltaTime * 5;
        pos.x = Formula(InitialVarX);
        transform.position = pos;
    }
    private float Formula(float x) {
        x *= 0.75f;
        return x * x * x;
    }
}
