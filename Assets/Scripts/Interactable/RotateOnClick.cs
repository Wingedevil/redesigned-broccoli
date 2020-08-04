using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable {
    public class RotateOnClick : MonoBehaviour {
        public float RotationOnClick;
        public void Rotate() {
            var temp = transform.rotation.eulerAngles;
            temp.z += RotationOnClick;
            transform.rotation = Quaternion.Euler(temp);
        }
    }
}