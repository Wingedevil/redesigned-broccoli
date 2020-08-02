using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable {
    [RequireComponent(typeof(KeyMasherReceiver))]
    public class KeyMasher : MonoBehaviour {
        public KeyCode[] Keys;
        public bool Loop = true;

        private KeyMasherReceiver receiver;
        private int index = 0;

        private void Start() {
            receiver = GetComponent<KeyMasherReceiver>();
        }

        private void Update() {
            if (Input.GetKeyDown(Keys[index])) {
                receiver.OnKey(index / Keys.Length);
                index = (index + 1) % Keys.Length;
                if (index == 0) {
                    receiver.OnCompleteSequence();
                    if (!Loop) {
                        index = Keys.Length - 1;
                    }
                }
            }
        }
    }
}