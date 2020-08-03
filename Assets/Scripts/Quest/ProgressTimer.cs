using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    public class ProgressTimer : MonoBehaviour {
        public float Timer;
        public int[] RequiredStage;
        public int StageOnComplete;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;
        }

        public void StageUpdate(int stage) {
            foreach (int i in RequiredStage) {
                if (i == stage) {
                    Invoke("AdvanceStage", Timer);
                }
            }
        }

        private void AdvanceStage() {
            QuestManager.Instance.UpdateStage(StageOnComplete);
        }
    }
}