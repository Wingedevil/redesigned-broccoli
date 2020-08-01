using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Quest {
    [RequireComponent(typeof(SpriteRenderer))]
    public class QuestVisible : MonoBehaviour {
        public int[] StageEnabled;

        private SpriteRenderer sprite;

        private void Start() {
            QuestManager.Instance.OnStageUpdate += StageUpdate;

            if (StageEnabled.Length <= 0) {
                return;
            }
            sprite = GetComponent<SpriteRenderer>();
            StageUpdate(0);
        }

        public void StageUpdate(int stage) {
            foreach (int i in StageEnabled) {
                if (i == stage) {
                    sprite.enabled = true;
                    return;
                }
            }
            sprite.enabled = false;
        }
    }
}