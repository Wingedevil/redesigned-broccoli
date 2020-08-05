using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CustomUtils;
using Quest;

namespace Managers {
    public class QuestManager : Manager<QuestManager> {
        [HideInInspector]
        public int CurrentQuestStage;
        public Action<int> OnStageUpdate = (int x) => {};

        private int stagnate;

        private void Start() {
            Invoke("Init", 0.02f);
        }

        private void Init() {
            OnStageUpdate(0);
        }

        public bool UpdateStage(int stage) {
            if (stagnate > 0) {
                return false;
            }
            Debug.Log("Advance Stage to: " + stage);

            CurrentQuestStage = stage;
            OnStageUpdate(stage);
            return true;
        }

        public int StagnateLevel() {
            return stagnate;
        }

        public void Stagnate(int b) {
            stagnate += b;
            Debug.Log("Stagnate Level: " + stagnate);   
        }
    }
}
