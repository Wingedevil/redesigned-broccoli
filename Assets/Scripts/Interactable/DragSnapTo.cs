using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Quest;

namespace Interactable {
    public class DragSnapTo : MonoBehaviour {
        public Transform AnchorPoint;
        public float DistToSnap = 1f;
        public string Key;

        private void Awake() {
            InteractableManager.Instance.AnchorPoints.Add(this);
        }
        public void Snapped(GameObject other) {
            if (TryGetComponent<ProgressLock>(out ProgressLock target)) {
                if (other.TryGetComponent<ProgressKey>(out ProgressKey key)) {
                    key.Unlock(target);
                }
            } else if (TryGetComponent<ProgressKey>(out ProgressKey key)) {
                if (other.TryGetComponent<ProgressLock>(out ProgressLock tar)) {
                    key.Unlock(tar);
                }
            }
        }
    }
}