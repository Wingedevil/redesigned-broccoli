using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    public class ProgressStall : MonoBehaviour {
        public int StallStage;
        public bool DeleteOnUnstall = false;
        public GameObject PrefabToSpawn;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StartStalling;
        }

        public void StartStalling(int a) {
            if (a == StallStage) {
                QuestManager.Instance.Stagnate(1);
            }
        }

        public void StopStalling() {
            Instantiate(PrefabToSpawn, transform.position, transform.rotation);
            if (QuestManager.Instance.StagnateLevel() > 0) {
                QuestManager.Instance.Stagnate(-1);
                if (DeleteOnUnstall) {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}