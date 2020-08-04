using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Interactable;

namespace Quest {
    public class ProgressKey : MonoBehaviour {
        public float Key;
        public bool OneTimeUse;
        private bool used = false;

        public bool Unlock(ProgressLock @lock) {
            if (!used && !@lock.Unlocked && @lock.KeyExpected == this.Key) {
                if (@lock.RequiredStage.Length <= 0) {
                    goto unlocking;
                }

                int curStage = QuestManager.Instance.CurrentQuestStage;
                foreach (int i in @lock.RequiredStage) {
                    if (i == curStage) {
                        goto unlocking;
                    }
                }
                return false;


                unlocking:
                // unlock stall
                if (@lock.TryGetComponent<ProgressStall>(out ProgressStall stall)) {
                    stall.StopStalling();
                    @lock.Unlocked = true;
                    if (OneTimeUse) {
                        used = true;
                    }
                }

                if (@lock.TryGetComponent<Draggable>(out Draggable drag)) {
                    Destroy(drag);
                }
                if (@lock.TryGetComponent<Clickable>(out Clickable click)) {
                    Destroy(click);
                }

                bool x = QuestManager.Instance.UpdateStage(@lock.StageOnComplete);
                if (x) {
                    // successful unlocking
                    @lock.Unlocked = true;
                    Instantiate(@lock.PrefabToSpawn, @lock.transform.position, @lock.transform.rotation);
                    if (OneTimeUse) {
                        used = true;
                    }
                    // end successful unlocking
                    return true;
                }
                return false;
            } else {
                return false;
            }
        }
    }
}