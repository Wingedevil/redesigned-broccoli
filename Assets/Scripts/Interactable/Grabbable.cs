using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quest;
using Managers;

namespace Interactable {
    public class Grabbable : MonoBehaviour {
        public string Key;
        public float DistToGrab = 1f;
        public Transform SnapPoint;

        private void Awake() {
            InteractableManager.Instance.GrabPoints.Add(this);
        }
        public void Grabbed(GameObject other) {
            ProgressLock[] locks = GetComponents<ProgressLock>();
            ProgressKey[] keys = other.GetComponents<ProgressKey>();
            foreach (ProgressLock @lock in locks) {
                foreach (ProgressKey key in keys) {
                    key.Unlock(@lock);
                }
            }
            locks = other.GetComponents<ProgressLock>();
            keys = GetComponents<ProgressKey>();
            foreach (ProgressLock @lock in locks)
            {
                foreach (ProgressKey key in keys)
                {
                    key.Unlock(@lock);
                }
            }
        }
    }
}
