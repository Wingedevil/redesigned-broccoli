using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Interactable;

namespace Quest {
    public class BlockSnap : MonoBehaviour {
        public int[] StageEnabled;
        public DragSnapTo enableSnap;

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
                    InteractableManager.Instance.AnchorPoints.Add(enableSnap);
                    return;
                }
            }
            if (enableSnap != null) {
                InteractableManager.Instance.AnchorPoints.Remove(enableSnap);
            }
        }
    }
}