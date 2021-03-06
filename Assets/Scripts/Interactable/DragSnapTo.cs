﻿using System.Collections;
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