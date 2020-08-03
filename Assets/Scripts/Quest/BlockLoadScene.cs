using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.SceneManagement;

namespace Quest {
    public class BlockLoadScene : MonoBehaviour {
        public string SceneToLoad;
        public int[] StageEnabled;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;
        }

        public void StageUpdate(int stage) {
            foreach (int i in StageEnabled) {
                if (i == stage) {
                    SceneManager.LoadScene(SceneToLoad);
                    return;
                }
            }
        }
    }
}