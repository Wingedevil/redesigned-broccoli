using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    [RequireComponent(typeof(Collider2D))]
    public class BlockCollider : MonoBehaviour {
        public int[] StageEnabled;

        private Collider2D enableCollider;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;

            if (StageEnabled.Length <= 0) {
                return;
            }
            enableCollider = GetComponent<Collider2D>();
            StageUpdate(0);
        }

        public void StageUpdate(int stage) {
            foreach (int i in StageEnabled) {
                if (i == stage) {
                    enableCollider.enabled = true;
                    return;
                }
            }
            if (enableCollider != null) {
                enableCollider.enabled = false;
            }
        }
    }
}