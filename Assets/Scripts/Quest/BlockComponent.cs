using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    public class BlockComponent : MonoBehaviour {
        public int[] StageEnabled;
        public MonoBehaviour enableComponent;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;

            if (StageEnabled.Length <= 0) {
                return;
            }
            StageUpdate(0);
        }

        public void StageUpdate(int stage) {
            foreach (int i in StageEnabled) {
                if (i == stage) {
                    enableComponent.enabled = true;
                    return;
                }
            }
            if (enableComponent != null) {
                enableComponent.enabled = false;
            }
        }
    }
}