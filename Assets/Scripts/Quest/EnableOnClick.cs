using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class EnableOnClick : MonoBehaviour {
    public TrailRenderer enableComponent;

    private void Update() {
        if (Input.GetMouseButton(0)) {
            enableComponent.time = 0.2f;
        } else {
            enableComponent.time = 0f;
        }
    }
    private void OnDisable() {
        enableComponent.time = 0f;
    }
}