using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    [RequireComponent(typeof(AudioSource))]
    public class PlayOnStage : MonoBehaviour {
        public int[] StageEnabled;

        private AudioSource sauce;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;

            sauce = GetComponent<AudioSource>();

            if (StageEnabled.Length <= 0) {
                return;
            }
            StageUpdate(0);
        }

        public void StageUpdate(int stage) {
            foreach (int i in StageEnabled) {
                if (i == stage) {
                    sauce.Play();
                    return;
                }
            }
        }
    }
}