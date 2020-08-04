using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable {
    public class RotateOnDrag : MonoBehaviour {
        public float RotationOnDrag;
        public void Rotate() {
            var temp = transform.rotation.eulerAngles;
            temp.z += RotationOnDrag;
            transform.rotation = Quaternion.Euler(temp);
        }
        public void Unrotate() {
            var temp = transform.rotation.eulerAngles;
            temp.z -= RotationOnDrag;
            transform.rotation = Quaternion.Euler(temp);
        }
    }
}