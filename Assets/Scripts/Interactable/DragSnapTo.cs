using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Quest;

namespace Interactable {
    public class DragSnapTo : MonoBehaviour {
        public Transform AnchorPoint;
        public float DistToSnap = 1f;
        private void Awake() {
            InteractableManager.Instance.AnchorPoints.Add(this);
        }
        public void Snapped(GameObject other) {
            if (TryGetComponent<QuestTarget>(out QuestTarget target)) {
                if (other.TryGetComponent<QuestKey>(out QuestKey key)) {
                    key.Unlock(target);
                }
            }
        }
    }
}