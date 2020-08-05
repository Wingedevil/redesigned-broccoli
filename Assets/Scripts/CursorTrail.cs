using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrail : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        var coord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        coord.z = 0;
        transform.position = coord;
    }
}
