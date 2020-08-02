using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable {
    public abstract class KeyMasherReceiver : MonoBehaviour {
        public abstract void OnKey(float doneness);
        public abstract void OnCompleteSequence();
    }
}