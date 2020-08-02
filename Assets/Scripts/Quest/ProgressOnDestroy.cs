using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    public class ProgressOnDestroy : MonoBehaviour {
        public int StageOnComplete;

        private void OnDestroy() {
            QuestManager.Instance.UpdateStage(StageOnComplete);
        }
    }
}