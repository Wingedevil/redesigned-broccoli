using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    [RequireComponent(typeof(Collider2D))]
    public class QuestGate : MonoBehaviour {
        public int[] StageEnabled;

        private Collider2D collider;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;

            if (StageEnabled.Length <= 0) {
                return;
            }
            collider = GetComponent<Collider2D>();
            StageUpdate(0);
        }

        public void StageUpdate(int stage) {
            foreach (int i in StageEnabled) {
                if (i == stage) {
                    collider.enabled = true;
                    return;
                }
            }
            collider.enabled = false;
        }
    }
}