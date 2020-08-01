using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    public class QuestKey : MonoBehaviour {
        public float Key;
        public bool OneTimeUse;
        private bool used = false;

        public bool Unlock(QuestTarget target) {
            if (!used && !target.Unlocked && target.KeyExpected == this.Key) {
                bool x = QuestManager.Instance.UpdateStage(target.StageOnComplete);
                if (x) {
                    target.Unlocked = true;
                    Instantiate(target.PrefabToSpawn, target.transform.position, target.transform.rotation);
                    if (OneTimeUse) {
                        used = true;
                    }
                    return true;
                }
                return false;
            } else {
                return false;
            }
        }
    }
}